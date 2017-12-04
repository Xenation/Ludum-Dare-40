using UnityEngine;

namespace LD40 {
	public class ArrowProjectile : Projectile {

		protected override void Init() {
			
		}

		protected override Vector3 GetVelocity() {
			return heading * speed;
		}

		protected override void UpdatePhysics() {
			transform.LookAt(transform.position + heading);
		}

		protected override void InflictDamage(LivingEntity entity) {
			entity.TakeDamage(heading, damage);
		}

		protected override void OnPreDeath() {
			
		}

	}
}
