using System.Collections.Generic;

namespace LD40 {
	[System.Serializable]
	public class FireballSpell : Spell {

		public FireballSpell() {
			type = SpellType.Fireball;
		}

		public override void Fire() {
			Projectile projectile = ProjectileManager.I.CreateProjectile(ProjectileType.Fireball);
			AddProjectile(projectile);
		}

	}
}
