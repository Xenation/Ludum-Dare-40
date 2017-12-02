using UnityEngine;

namespace LD40 {
	public class IceSpikeProjectile : Projectile {

		protected override Vector3 GetVelocity() {
			return heading * speed;
		}

	}
}
