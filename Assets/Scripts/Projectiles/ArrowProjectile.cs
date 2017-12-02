using UnityEngine;

namespace LD40 {
	public class ArrowProjectile : Projectile {

		protected override Vector3 GetVelocity() {
			return heading * speed;
		}

		protected override void UpdatePhysics() {
			transform.LookAt(transform.position + heading);
		}

	}
}
