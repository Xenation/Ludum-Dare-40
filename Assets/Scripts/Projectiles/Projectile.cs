using UnityEngine;

namespace LD40 {
	public enum ProjectileType {
		Fireball,
		IceSpike,
		Arrow,
		Tornado,
		ElectricArc,
		Beam
	}

	[HideInInspector]
	public abstract class Projectile : MonoBehaviour {

		public float damage = 1f;
		public Vector3 heading;
		public float speed;
		public bool dieOnCollision;
		public bool hasLifeTime;
		public float lifeTime;

		public delegate void OnDeath();
		public event OnDeath OnDeathEvent;

		protected Rigidbody rb;

		protected float creationTime;

		private void Start() {
			rb = GetComponent<Rigidbody>();
			creationTime = Time.time;
			Init();
		}

		protected abstract void Init();

		private void Update() {
			if (hasLifeTime && creationTime + lifeTime <= Time.time) {
				Die();
			}
		}

		protected void FixedUpdate() {
			rb.velocity = GetVelocity();
			UpdatePhysics();
		}

		protected abstract Vector3 GetVelocity();
		protected abstract void UpdatePhysics();

		private void OnCollisionEnter(Collision collision) {
			LivingEntity entity = collision.gameObject.GetComponent<LivingEntity>();
			if (entity != null) {
				InflictDamage(entity);
			}
			if (dieOnCollision) {
				Die();
			}
		}

		protected abstract void InflictDamage(LivingEntity entity);

		public void Kill() {
			Die();
		}

		protected void Die() {
			OnPreDeath();
			if (OnDeathEvent != null) {
				OnDeathEvent.Invoke();
			}
			Destroy(gameObject);
		}

		protected abstract void OnPreDeath();

	}
}
