using System.Collections.Generic;
using UnityEngine;

namespace LD40 {
	public class BeamProjectile : Projectile {

		public float width;
		public float maxRange;
		public float pauseTime;
		public float hitCooldown;
		
		[HideInInspector]
		public ParticleSystem system;

		private float lastHitTime;

		protected override void Init() {
			system = GetComponentInChildren<ParticleSystem>();
			transform.LookAt(transform.position + heading);
		}

		protected override Vector3 GetVelocity() {
			return Vector3.zero;
		}

		protected override void UpdatePhysics() {
			if (creationTime + pauseTime <= Time.time) {
				system.Pause();
			}
			transform.LookAt(transform.position + heading);
			if (lastHitTime + hitCooldown <= Time.time) {
				List<LivingEntity> touched = CollisionUtil.EntitiesInBeam(transform.position, heading, width, maxRange);
				touched.Remove(EntitiesManager.I.player);
				if (touched.Count != 0) {
					lastHitTime = Time.time;
					Debug.Log("HIT");
					foreach (LivingEntity ent in touched) {
						InflictDamage(ent);
					}
				}
			}
		}

		protected override void InflictDamage(LivingEntity entity) {
			entity.TakeDamage(heading, damage);
		}

		protected override void OnPreDeath() {
			system.Play();
		}

	}
}
