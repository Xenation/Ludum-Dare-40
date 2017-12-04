using UnityEngine;

namespace LD40 {
	public class PlayerCamera : MonoBehaviour {

		public Transform toFollow;
		public float lerpMult = 1f;
		public bool follow = true;

		private Vector3 offset = new Vector3(0, 9.57f, -4.17f);

		public void Start() {
			//offset = transform.position - toFollow.position;
		}

		public void FixedUpdate() {
			if (follow && toFollow != null) {
				transform.position = Vector3.Lerp(transform.position, toFollow.position + offset, Time.deltaTime * lerpMult);
			}
		}

	}
}
