using System.Collections.Generic;
using UnityEngine;

namespace LD40 {
	public class ElectricArcProjectile : Projectile {

		public float angle;
		public float range;

		public float centerDeadAngle = 10f;

		protected override void Init() {
			transform.LookAt(transform.position + heading);
		}

		protected override Vector3 GetVelocity() {
			return Vector3.zero;
		}

		protected override void UpdatePhysics() {
			List<LivingEntity> touched = CollisionUtil.EntitiesInCone(transform.position, heading, angle, range);
			touched.Remove(EntitiesManager.I.player);
			foreach (LivingEntity ent in touched) {
				InflictDamage(ent);
			}
			Die();
		}

		protected override void InflictDamage(LivingEntity entity) {
			entity.TakeDamage(heading, damage);
		}

		protected override void OnPreDeath() {
			
		}

	}
}
