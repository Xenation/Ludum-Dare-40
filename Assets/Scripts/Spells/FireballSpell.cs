using System.Collections.Generic;

namespace LD40 {
	[System.Serializable]
	public class FireballSpell : Spell {

		public override SpellType GetSpellType() {
			return SpellType.Fireball;
		}

		public override void Fire() {
			Projectile projectile = ProjectileManager.I.CreateProjectile(ProjectileType.Fireball);
			AddProjectile(projectile);
		}

	}
}
