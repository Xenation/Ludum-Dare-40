using UnityEngine;

namespace LD40 {
	public class OneShotParticle : MonoBehaviour {

		private ParticleSystem system;
		
		public void Awake() {
			system = GetComponent<ParticleSystem>();
		}

		public void Update() {
			if (system.time >= system.main.duration) {
				Destroy(gameObject);
			}
		}

	}
}
