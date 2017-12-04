using System.Collections.Generic;
using UnityEngine;

namespace LD40 {
	public class TornadoProjectile : Projectile {

		public float buildUpTime;
		public float hitRange;
		public float hitCooldown;

		public int maxBounces = 2;

		private int bounces = 0;
		private Dictionary<LivingEntity, float> lastHitTimes;

		protected override void Init() {
			lastHitTimes = new Dictionary<LivingEntity, float>();
		}

		protected override Vector3 GetVelocity() {
			if (creationTime + buildUpTime > Time.time) {
				return Vector3.zero;
			} else {
				return heading * speed;
			}
		}

		protected override void UpdatePhysics() {
			List<LivingEntity> touched = CollisionUtil.EntitiesInSphere(transform.position, hitRange);
			if (bounces == 0) {
				touched.Remove(EntitiesManager.I.player);
			}
			foreach (LivingEntity ent in touched) {
				float lastHitTime;
				if (lastHitTimes.TryGetValue(ent, out lastHitTime)) {
					if (lastHitTime + hitCooldown <= Time.time) {
						lastHitTimes[ent] = Time.time;
						InflictDamage(ent);
					}
				} else {
					lastHitTimes.Add(ent, Time.time);
					InflictDamage(ent);
				}
			}
		}

		protected override void OnCollision(Collision collision) {
			if (instability >= 1) {
				if (bounces < maxBounces) {
					heading = Vector3.Reflect(heading, new Vector3(collision.contacts[0].normal.x, 0f, collision.contacts[0].normal.z).normalized);
					bounces++;
				} else {
					Die();
				}
			} else {
				if (dieOnCollision) {
					Die();
				}
			}
		}

		protected override void InflictDamage(LivingEntity entity) {
			entity.TakeDamage(heading, damage);
		}

		protected override void OnPreDeath() {
			
		}

	}
}
