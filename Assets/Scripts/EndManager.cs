using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

namespace LD40 {
	public class EndManager : Singleton<EndManager> {

		public PlayableDirector director;
		public string nextLevel;

		public void OnTriggerEnter(Collider other) {
			Player player = other.gameObject.GetComponentInParent<Player>();
			if (player == null) return;
			player.hasControl = false;
			director.Play();
			Invoke("NextScene", (float) director.duration);
		}

		private void NextScene() {
			SceneManager.LoadScene(nextLevel);
		}

	}
}
