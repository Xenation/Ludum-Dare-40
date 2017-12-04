using UnityEngine.SceneManagement;

namespace LD40 {
	public class MenuManager : Singleton<MenuManager> {

		public string level1;

		public void Play() {
			SceneManager.LoadScene(level1);
		}

	}
}
