using System.Collections.Generic;
using UnityEngine;

namespace LD40 {
	[HideInInspector]
	public abstract class Caster : LivingEntity {

		public delegate void OnSpellSelected(SpellType t);
		public event OnSpellSelected OnSpellSelectedEvent;

		public Spell SelectedSpell { get; private set; }

		public Dictionary<SpellType, float> lastShotTimes;

		private bool isFiring = false;

		public Caster() {
			InitShotTimes();
		}

		public void InitShotTimes() {
			lastShotTimes = new Dictionary<SpellType, float>();
			foreach (SpellType type in System.Enum.GetValues(typeof(SpellType))) {
				lastShotTimes.Add(type, 0f);
			}
		}

		protected virtual void PreSpellFired() { }

		public void FireSpell() {
			if (SelectedSpell == null) return;
			if (lastShotTimes[SelectedSpell.type] + SelectedSpell.Cooldown > Time.time) return;
			PreSpellFired();
			lastShotTimes[SelectedSpell.type] = Time.time;
			SelectedSpell.Fire();
		}

		public void StartFiring() {
			isFiring = true;
			if (SelectedSpell.isToggle && lastShotTimes[SelectedSpell.type] + SelectedSpell.Cooldown <= Time.time) {
				lastShotTimes[SelectedSpell.type] = Time.time;
				SelectedSpell.Activate();
			}
		}

		public void StopFiring() {
			isFiring = false;
			if (SelectedSpell.isToggle) {
				SelectedSpell.Deactivate();
			}
		}

		public void SelectSpell(Spell spell) {
			if (SelectedSpell != null && SelectedSpell.isToggle && SelectedSpell.IsActive) {
				SelectedSpell.Deactivate();
			}
			SelectedSpell = spell;
			if (OnSpellSelectedEvent != null) {
				OnSpellSelectedEvent.Invoke(spell.type);
			}
		}

		private void Update() {
			SelectedSpell.Update();
			if (isFiring && !SelectedSpell.isToggle) {
				FireSpell();
			}
			PerformUpdate();
		}

		protected abstract void PerformUpdate();

	}
}
