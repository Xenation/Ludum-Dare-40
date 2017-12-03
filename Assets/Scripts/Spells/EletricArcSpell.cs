using UnityEngine;

namespace LD40 {
	[System.Serializable]
	public class EletricArcSpell : Spell {

		public override SpellType GetSpellType() {
			return SpellType.ElectricArc;
		}

		public override void InitFactories() {
			ProjectileFactory projectile = ProjectileFactory.CreateFactory(ProjectileType.ElectricArc);
			projectile.heading = Vector3.forward;
			AddFactory(projectile);
		}

	}
}
