using UnityEngine;

namespace LD40 {
	public class FireballProjectile : Projectile {

		protected override void Init() {

		}

		protected override Vector3 GetVelocity() {
			return heading * speed;
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
