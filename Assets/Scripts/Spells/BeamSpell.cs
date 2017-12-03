using System.Collections.Generic;
using UnityEngine;

namespace LD40 {
	[System.Serializable]
	public class BeamSpell : Spell {

		public float castTime = 1f;

		private Dictionary<ProjectileFactory, Projectile> projectiles;

		public override SpellType GetSpellType() {
			return SpellType.Beam;
		}

		public override void InitFactories() {
			ProjectileFactory projectile = ProjectileFactory.CreateFactory(ProjectileType.Beam, Instability);
			projectile.heading = Vector3.forward;
			AddFactory(projectile);
		}

		public override void OnActivate() {
			projectiles = InstantiateProjectiles(caster.transform.position, mainHeading);
			foreach (Projectile proj in projectiles.Values) {
				proj.transform.LookAt(proj.transform.position + proj.heading);
			}
		}

		public override void Update() {
			base.Update();
			if (projectiles == null) return;
			foreach (KeyValuePair<ProjectileFactory, Projectile> proj in projectiles) {
				Vector3 relativeHeading = Quaternion.FromToRotation(Vector3.forward, proj.Key.heading) * mainHeading;
				proj.Value.heading = relativeHeading;
				proj.Value.transform.position = caster.transform.position + relativeHeading;
			}
			if (activationTime + castTime <= Time.time) {
				Deactivate();
			}
		}

		public override void OnDeactivate() {
			foreach (Projectile proj in projectiles.Values) {
				proj.Kill();
			}
			projectiles.Clear();
		}

	}
}
