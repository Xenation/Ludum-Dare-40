using System.Collections.Generic;
using UnityEngine;

namespace LD40 {
	[System.Serializable]
	public class FireballSpell : Spell {

		public float minCooldown;
		public float maxCooldown;

		public override SpellType GetSpellType() {
			return SpellType.Fireball;
		}

		protected override void InitFactories() {
			ProjectileFactory p1, p2, p3;
			switch (Instability) {
				default:
				case 0:
				case 1:
				case 2:
				case 3:
					p1 = ProjectileFactory.CreateFactory(ProjectileType.Fireball, Instability);
					p1.heading = Vector3.forward;
					AddFactory(p1);
					break;
				case 4:
					p1 = ProjectileFactory.CreateFactory(ProjectileType.Fireball, Instability);
					p1.heading = Vector3.forward;
					AddFactory(p1);
					p2 = ProjectileFactory.CreateFactory(ProjectileType.Fireball, 3);
					p2.heading = Quaternion.Euler(0f, -20f, 0f) * Vector3.forward;
					AddFactory(p2);
					p3 = ProjectileFactory.CreateFactory(ProjectileType.Fireball, 3);
					p3.heading = Quaternion.Euler(0f, 20f, 0f) * Vector3.forward;
					AddFactory(p3);
					break;
			}
		}

		public override void OnPreFire() {
			if (Instability >= 2) {
				Cooldown = Random.Range(minCooldown, maxCooldown);
			}
		}
	}
}
