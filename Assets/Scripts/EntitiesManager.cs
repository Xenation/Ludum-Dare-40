namespace LD40 {
	public class EntitiesManager : Singleton<EntitiesManager> {

		public Player player;

		public void Awake() {
			player = FindObjectOfType<Player>();
		}

	}
}
