using UnityEngine;

namespace LD40 {
	[System.Serializable]
	public class TornadoSpell : Spell {

		public override SpellType GetSpellType() {
			return SpellType.Tornado;
		}

		protected override void InitFactories() {
			instantiateDistanceMult = 3f;
			ProjectileFactory projectile = ProjectileFactory.CreateFactory(ProjectileType.Tornado, Instability);
			projectile.heading = Vector3.forward;
			AddFactory(projectile);
		}

	}
}
