using System.Collections.Generic;
using UnityEngine;

namespace LD40 {
	[System.Serializable]
	public class FireballSpell : Spell {

		public override SpellType GetSpellType() {
			return SpellType.Fireball;
		}

		public override void InitFactories() {
			ProjectileFactory projectile = ProjectileFactory.CreateFactory(ProjectileType.Fireball);
			projectile.heading = Vector3.forward;
			AddFactory(projectile);
			ProjectileFactory p2 = ProjectileFactory.CreateFactory(ProjectileType.Fireball);
			p2.heading = Quaternion.AngleAxis(-45, Vector3.up) * Vector3.forward;
			AddFactory(p2);
			ProjectileFactory p3 = ProjectileFactory.CreateFactory(ProjectileType.Fireball);
			p3.heading = Quaternion.AngleAxis(45, Vector3.up) * Vector3.forward;
			AddFactory(p3);
		}
	}
}
