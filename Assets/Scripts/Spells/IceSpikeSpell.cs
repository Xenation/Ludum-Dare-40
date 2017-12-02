using UnityEngine;

namespace LD40 {
	[System.Serializable]
	public class IceSpikeSpell : Spell {

		public override SpellType GetSpellType() {
			return SpellType.IceSpike;
		}

		public override void InitFactories() {
			ProjectileFactory projectile = ProjectileFactory.CreateFactory(ProjectileType.IceSpike);
			projectile.heading = Vector3.forward;
			AddFactory(projectile);
		}

		public override void Fire() {
			
		}
	}
}
