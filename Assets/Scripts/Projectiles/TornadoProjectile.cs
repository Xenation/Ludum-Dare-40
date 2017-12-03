using UnityEngine;

namespace LD40 {
	public class TornadoProjectile : Projectile {

		public float buildUpTime;

		protected override void Init() {
			
		}

		protected override Vector3 GetVelocity() {
			if (creationTime + buildUpTime > Time.time) {
				return Vector3.zero;
			} else {
				return heading * speed;
			}
		}

		protected override void UpdatePhysics() {
			
		}

		protected override void InflictDamage(LivingEntity entity) {
			entity.TakeDamage(damage);
		}

		protected override void OnPreDeath() {
			
		}

	}
}
