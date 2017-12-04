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
		public int instability = 0;

		public delegate void OnDeath();
		public event OnDeath OnDeathEvent;

		protected Rigidbody rb;

		protected float creationTime;
		protected float distanceTravelled = 0;

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
			Vector3 vel = GetVelocity();
			rb.velocity = vel;
			distanceTravelled += vel.magnitude * Time.fixedDeltaTime;
			UpdatePhysics();
		}

		protected abstract Vector3 GetVelocity();
		protected abstract void UpdatePhysics();

		private void OnCollisionEnter(Collision collision) {
			OnCollision(collision);
		}

		protected virtual void OnCollision(Collision collision) {
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
