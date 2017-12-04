namespace LD40 {
	public class SpellsManager : Singleton<SpellsManager> {

		public int generalInstability = 0;

		public void Awake() {
			DataCenter.I.playerSpells.InitAll();
			UpdateInstability();
		}

		public void OnDestroy() {
			DataCenter.I.playerSpells.ClearAllFactories();
		}

		public void IncreaseInstability() {
			generalInstability++;
			UpdateInstability();
		}

		private void UpdateInstability() {
			int fireballInstab = 0;
			int iceSpikeInstab = 0;
			int electricArcInstab = 0;
			int tornadoInstab = 0;
			
			for (int i = 0; i <= generalInstability; i++) {
				switch (i) {
					case 4:
						tornadoInstab++;
						goto case 3;
					case 3:
						electricArcInstab++;
						goto case 2;
					case 2:
						iceSpikeInstab++;
						goto case 1;
					case 1:
						fireballInstab++;
						break;
					default:
						break;
				}
			}

			DataCenter.I.playerSpells.tornadoSpell.Instability = tornadoInstab;
			DataCenter.I.playerSpells.eletricArcSpell.Instability = electricArcInstab;
			DataCenter.I.playerSpells.iceSpikeSpell.Instability = iceSpikeInstab;
			DataCenter.I.playerSpells.fireballSpell.Instability = fireballInstab;
		}

	}
}
