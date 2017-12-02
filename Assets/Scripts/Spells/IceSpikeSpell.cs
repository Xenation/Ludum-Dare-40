namespace LD40 {
	[System.Serializable]
	public class IceSpikeSpell : Spell {

		public override SpellType GetSpellType() {
			return SpellType.IceSpike;
		}

		public override void Fire() {
			Projectile projectile = ProjectileManager.I.CreateProjectile(ProjectileType.IceSpike);
			AddProjectile(projectile);
		}

	}
}
