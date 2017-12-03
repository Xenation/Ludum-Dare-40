using System.Collections.Generic;
using UnityEngine;

namespace LD40 {
	public enum SpellType {
		Fireball,
		IceSpike,
		Tornado,
		ElectricArc,
		Beam
	}

	[System.Serializable]
	public abstract class Spell {

		public SpellType type;
		public float cooldown;
		public bool isToggle = false;
		[HideInInspector]
		public Caster caster;
		[HideInInspector]
		public List<ProjectileFactory> projectileFactories;
		[HideInInspector]
		public Vector3 target;
		[HideInInspector]
		public Vector3 mainHeading;

		public bool IsActive { get; private set; }
		protected float activationTime;

		public Spell() {
			type = GetSpellType();
		}

		public abstract SpellType GetSpellType();
		public abstract void InitFactories();

		public void ClearFactories() {
			projectileFactories.Clear();
		}

		public void Activate() {
			IsActive = true;
			mainHeading = (target - caster.transform.position).normalized;
			activationTime = Time.time;
			OnActivate();
		}

		public void Deactivate() {
			IsActive = false;
			mainHeading = (target - caster.transform.position).normalized;
			OnDeactivate();
		}

		public virtual void OnActivate() { }
		public virtual void OnDeactivate() { }

		public virtual void Fire() {
			InstantiateProjectiles(caster.transform.position, mainHeading);
		}

		public virtual void Update() {
			mainHeading = (target - caster.transform.position).normalized;
		}

		public void AddFactory(ProjectileFactory proj) {
			if (projectileFactories == null) {
				projectileFactories = new List<ProjectileFactory>();
			}
			projectileFactories.Add(proj);
		}

		public Dictionary<ProjectileFactory, Projectile> InstantiateProjectiles(Vector3 position, Vector3 heading) {
			Dictionary<ProjectileFactory, Projectile> instantiated = new Dictionary<ProjectileFactory, Projectile>();
			foreach (ProjectileFactory fact in projectileFactories) {
				Projectile inst = fact.CreateInstance();
				Vector3 relativeHeading = Quaternion.FromToRotation(Vector3.forward, fact.heading) * heading;
				inst.heading = relativeHeading;
				inst.transform.position = position + inst.heading;
				instantiated.Add(fact, inst);
			}
			return instantiated;
		}

		public static Spell GetSpell(SpellType type, Caster caster) {
			Spell spell = DataCenter.I.playerSpells.GetSpell(type);
			spell.caster = caster;
			return spell;
		}

	}
}
