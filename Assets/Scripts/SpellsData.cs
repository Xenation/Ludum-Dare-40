using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace LD40 {
	[CreateAssetMenu(fileName = "Spells", menuName = "Spells Data", order = 100)]
	public class SpellsData : ScriptableObject {

		public FireballSpell fireballSpell;
		public IceSpikeSpell iceSpikeSpell;
		public TornadoSpell tornadoSpell;
		public EletricArcSpell eletricArcSpell;
		public BeamSpell beamSpell;

		private List<Spell> spells;

		public void OnEnable() {
			spells = new List<Spell>();
			foreach (FieldInfo field in GetType().GetFields()) {
				if (!field.IsPublic) continue;
				spells.Add((Spell) field.GetValue(this));
			}
		}

		public void OnDisable() {
			if (spells != null) {
				spells.Clear();
			}
		}

		public Spell GetSpell(SpellType type) {
			foreach (Spell spell in spells) {
				if (spell.type == type) return spell;
			}
			return null;
		}

		public void InitAllFactories() {
			foreach (Spell spell in spells) {
				spell.InitFactories();
			}
		}

		public void ClearAllFactories() {
			foreach (Spell spell in spells) {
				spell.ClearFactories();
			}
		}

	}
}
