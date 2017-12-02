using System.Collections.Generic;
using UnityEngine;

namespace LD40 {
	public enum SpellType {
		Fireball,
		IceSpike
	}

	[System.Serializable]
	public abstract class Spell {

		public SpellType type;
		public float cooldown;
		public Caster caster;
		public List<Projectile> projectiles;
		public Vector3 target;

		public Spell() {
			type = GetSpellType();
		}

		public abstract SpellType GetSpellType();

		public abstract void Fire();

		public void AddProjectile(Projectile proj) {
			if (projectiles == null) {
				projectiles = new List<Projectile>();
			}
			proj.heading = (target - caster.transform.position).normalized;
			proj.transform.position = caster.transform.position + proj.heading;
			projectiles.Add(proj);
		}

		public static Spell GetSpell(SpellType type, Caster caster) {
			Spell spell;
			switch (type) {
				case SpellType.Fireball:
					spell = DataManager.I.playerSpells.fireballSpell;
					spell.caster = caster;
					return spell;
				case SpellType.IceSpike:
					spell = DataManager.I.playerSpells.iceSpikeSpell;
					spell.caster = caster;
					return spell;
				default:
					return null;
			}
		}

	}
}
