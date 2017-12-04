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
		[SerializeField]
		private float cooldown;
		public bool isToggle = false;
		[HideInInspector]
		public Vector3 target;

		protected Caster caster;
		private List<ProjectileFactory> projectileFactories;
		protected Vector3 mainHeading;

		public bool IsActive { get; private set; }
		protected float activationTime;
		public float Cooldown { get; protected set; }

		[SerializeField]
		private int _instability = 0;
		public int Instability {
			get {
				return _instability;
			}
			set {
				_instability = value;
				ClearFactories();
				InitFactories();
			}
		}

		public Spell() {
			
		}

		public void Init() {
			Cooldown = cooldown;
			type = GetSpellType();
			InitFactories();
		}

		public abstract SpellType GetSpellType();
		protected abstract void InitFactories();

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

		public virtual void OnPreFire() { }

		public virtual void Fire() {
			OnPreFire();
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
