using UnityEngine;

namespace LD40 {
	public class FireballProjectile : Projectile {

		protected override Vector3 GetVelocity() {
			return heading * speed;
		}

	}
}
