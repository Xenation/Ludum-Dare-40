namespace LD40 {
	public class SpellsManager : Singleton<SpellsManager> {

		public void Awake() {
			DataCenter.I.playerSpells.fireballSpell.InitFactories();
			DataCenter.I.playerSpells.iceSpikeSpell.InitFactories();
		}

		public void OnDestroy() {
			DataCenter.I.playerSpells.fireballSpell.ClearFactories();
			DataCenter.I.playerSpells.iceSpikeSpell.ClearFactories();
		}

	}
}
