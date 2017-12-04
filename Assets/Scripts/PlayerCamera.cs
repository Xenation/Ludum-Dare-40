using UnityEngine;

namespace LD40 {
	public class PlayerCamera : MonoBehaviour {

		public Transform toFollow;
		public float lerpMult = 1f;

		private Vector3 offset;

		public void Start() {
			offset = transform.position - toFollow.position;
		}

		public void LateUpdate() {
			transform.position = Vector3.Lerp(transform.position, toFollow.position + offset, Time.deltaTime * lerpMult);
		}

	}
}
