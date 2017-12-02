using UnityEngine;

namespace LD40 {
	public enum ProjectileType {
		Fireball,
	}

	[AddComponentMenu("_LD40/Projectile")]
	public class Projectile : MonoBehaviour {

		public Vector3 heading;
		public float speed;
		public bool dieOnCollision;
		public float lifeTime;

		public delegate void OnDeath();
		public event OnDeath OnDeathEvent;

		private Rigidbody rb;

		private float creationTime;

		private void Start() {
			rb = GetComponent<Rigidbody>();
			creationTime = Time.time;
		}

		private void Update() {
			if (creationTime + lifeTime <= Time.time) {
				Die();
			}
		}

		protected void FixedUpdate() {
			rb.velocity = GetVelocity();
		}

		protected virtual Vector3 GetVelocity() {
			return Vector3.zero;
		}

		private void OnCollisionEnter(Collision collision) {
			if (dieOnCollision) {
				Die();
			}
		}

		private void Die() {
			if (OnDeathEvent != null) {
				OnDeathEvent.Invoke();
			}
			Destroy(gameObject);
		}

	}
}
