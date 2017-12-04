using UnityEngine;

namespace LD40 {
	[CreateAssetMenu(fileName = "DataCenter", menuName = "Data Center", order = 99)]
	public class DataCenter : ScriptableObject {

		private static DataCenter instance;
		public static DataCenter I {
			get {
				return instance;
			}
		}

		public SpellsData playerSpells;
		public ProjectilesData projectiles;

		public void OnEnable() {
			instance = this;

		}

	}
}
