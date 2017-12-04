using UnityEngine;

namespace LD40 {
	public enum CollectibleType {
		Health,
	}

	public class Collectible : MonoBehaviour {

		public CollectibleType type;
		public float rotationSpeed;
		public GameObject collectEffect;

		public void FixedUpdate() {
			transform.rotation *= Quaternion.Euler(0f, rotationSpeed * Time.fixedDeltaTime, 0f);
		}

		public void OnTriggerEnter(Collider other) {
			Player player = other.gameObject.GetComponentInParent<Player>();
			if (player == null) return;
			switch (type) {
				case CollectibleType.Health:
					player.Heal(1f);
					break;
			}
			Instantiate(collectEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}

	}
}
