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
		public List<ProjectileFactory> projectileFactories;
		public Vector3 target;

		public Spell() {
			type = GetSpellType();
		}

		public abstract SpellType GetSpellType();
		public abstract void InitFactories();

		public void ClearFactories() {
			projectileFactories.Clear();
		}

		public abstract void Fire();

		public void Fire2() {
			InstantiateProjectiles(caster.transform.position, (target - caster.transform.position).normalized);
		}

		public void AddFactory(ProjectileFactory proj) {
			if (projectileFactories == null) {
				projectileFactories = new List<ProjectileFactory>();
			}
			projectileFactories.Add(proj);
		}

		public List<Projectile> InstantiateProjectiles(Vector3 position, Vector3 heading) {
			List<Projectile> instantiated = new List<Projectile>();
			foreach (ProjectileFactory fact in projectileFactories) {
				Projectile inst = fact.CreateInstance();
				Vector3 relativeHeading = Quaternion.FromToRotation(Vector3.forward, fact.heading) * heading;
				inst.heading = relativeHeading;
				inst.transform.position = position + inst.heading;
				instantiated.Add(inst);
			}
			return instantiated;
		}

		public static Spell GetSpell(SpellType type, Caster caster) {
			Spell spell;
			switch (type) {
				case SpellType.Fireball:
					spell = DataCenter.I.playerSpells.fireballSpell;
					spell.caster = caster;
					return spell;
				case SpellType.IceSpike:
					spell = DataCenter.I.playerSpells.iceSpikeSpell;
					spell.caster = caster;
					return spell;
				default:
					return null;
			}
		}

	}
}
