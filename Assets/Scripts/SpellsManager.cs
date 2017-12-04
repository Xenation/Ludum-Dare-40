namespace LD40 {
	public class SpellsManager : Singleton<SpellsManager> {

		public int generalInstability = 0;

		public void Awake() {
			DataCenter.I.playerSpells.InitAll();
		}

		public void OnDestroy() {
			DataCenter.I.playerSpells.ClearAllFactories();
		}

		public void IncreaseInstability() {
			switch (generalInstability) {
				case 3:
					DataCenter.I.playerSpells.tornadoSpell.Instability++;
					goto case 2;
				case 2:
					DataCenter.I.playerSpells.eletricArcSpell.Instability++;
					goto case 1;
				case 1:
					DataCenter.I.playerSpells.iceSpikeSpell.Instability++;
					goto case 0;
				case 0:
					DataCenter.I.playerSpells.fireballSpell.Instability++;
					generalInstability++;
					break;
				default:
					break;
			}
			
		}

	}
}
