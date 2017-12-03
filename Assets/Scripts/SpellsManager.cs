﻿namespace LD40 {
	public class SpellsManager : Singleton<SpellsManager> {

		public void Awake() {
			DataCenter.I.playerSpells.InitAllFactories();
		}

		public void OnDestroy() {
			DataCenter.I.playerSpells.ClearAllFactories();
		}

	}
}
