using UnityEngine;

namespace LD40 {
	public class FireballProjectile : Projectile {

		protected override void Init() {
			if (instability == 3) {
				heading = Quaternion.Euler(0f, Random.Range(-20f, 20f), 0f) * heading;
			}
		}

		protected override Vector3 GetVelocity() {
			switch (instability) {
				default:
				case 0:
					return heading * speed;
				case 1:
				case 2:
				case 3:
				case 4:
					return Quaternion.Euler(0, Mathf.Sin(distanceTravelled * 0.57f) * 45f * 1.5f, 0) * heading * speed;
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
