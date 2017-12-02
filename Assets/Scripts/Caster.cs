using System.Collections.Generic;
using UnityEngine;

namespace LD40 {
	[HideInInspector]
	public class Caster : MonoBehaviour {

		public Spell selectedSpell;

		public Dictionary<SpellType, float> lastShotTimes;

		public Caster() {
			InitShotTimes();
		}

		public void InitShotTimes() {
			lastShotTimes = new Dictionary<SpellType, float>();
			foreach (SpellType type in System.Enum.GetValues(typeof(SpellType))) {
				lastShotTimes.Add(type, 0f);
			}
		}

		public void FireSpell() {
			if (selectedSpell == null) return;
			if (lastShotTimes[selectedSpell.type] + selectedSpell.cooldown > Time.time) return;
			lastShotTimes[selectedSpell.type] = Time.time;
			selectedSpell.Fire();
		}

	}
}
