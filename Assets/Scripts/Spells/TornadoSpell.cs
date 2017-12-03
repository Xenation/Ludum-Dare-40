using UnityEngine;

namespace LD40 {
	[System.Serializable]
	public class TornadoSpell : Spell {

		public override SpellType GetSpellType() {
			return SpellType.Tornado;
		}

		public override void InitFactories() {
			ProjectileFactory projectile = ProjectileFactory.CreateFactory(ProjectileType.Tornado);
			projectile.heading = Vector3.forward;
			AddFactory(projectile);
		}

	}
}
