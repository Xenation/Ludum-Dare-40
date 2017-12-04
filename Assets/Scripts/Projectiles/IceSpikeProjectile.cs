using System.Collections.Generic;
using UnityEngine;

namespace LD40 {
	public class IceSpikeProjectile : Projectile {

		public float minSplitDistance;
		public float maxSplitDistance;
		public float minSplitAngle;
		public float maxSplitAngle;
		public int maxSplits = 5;

		public float eraticAngle;

		private float nextSplitDistance = 0;
		private int splitDepth = 0;
		private List<LivingEntity> entitiesTouched;

		protected override void Init() {
			if (instability >= 2 && splitDepth == 0) {
				maxSplits++;
			}
			entitiesTouched = new List<LivingEntity>();
		}

		protected override Vector3 GetVelocity() {
			if (instability >= 2) {
				heading = Quaternion.Euler(0f, Random.Range(-eraticAngle, eraticAngle), 0f) * heading;
			}
			return heading * speed;
		}

		protected override void UpdatePhysics() {
			if (instability >= 1 && splitDepth < maxSplits) {
				if (nextSplitDistance == 0) {
					nextSplitDistance = Random.Range(minSplitDistance, maxSplitDistance);
				}
				if (nextSplitDistance <= distanceTravelled) {
					nextSplitDistance = 0;
					Split();
					splitDepth++;
				}
			}
			transform.LookAt(transform.position + heading);
		}

		protected override void OnCollision(Collision collision) {
			LivingEntity entity = collision.gameObject.GetComponentInParent<LivingEntity>();
			if (entity != null) {
				if (!entitiesTouched.Contains(entity)) {
					InflictDamage(entity);
					entitiesTouched.Add(entity);
				}
			} else {
				if (dieOnCollision) {
					Die();
				}
			}
			if (instability >= 3 && entitiesTouched.Count >= 2) {
				Die();
			}
		}

		protected override void InflictDamage(LivingEntity entity) {
			entity.TakeDamage(heading, damage);
		}

		protected override void OnPreDeath() {
			
		}

		private void Split() { // TODO fix weird split
			ProjectileFactory fact = ProjectileFactory.CreateFactory(ProjectileType.IceSpike, instability);
			float side = (Random.value >= .5f) ? 1f : -1f ;
			float angle = Random.Range(side * minSplitAngle, side * maxSplitAngle);
			fact.heading = Quaternion.Euler(0f, angle, 0f) * heading;
			heading = Quaternion.Euler(0f, -angle, 0f) * heading;
			IceSpikeProjectile proj = fact.CreateInstance() as IceSpikeProjectile;
			proj.transform.position = transform.position;
			proj.distanceTravelled = 0f;
			proj.splitDepth = splitDepth + 1;
			proj.minSplitDistance = minSplitDistance;
			proj.maxSplitDistance = maxSplitDistance;
			proj.minSplitAngle = minSplitAngle;
			proj.maxSplitAngle = maxSplitAngle;
			proj.maxSplits = maxSplits;
			proj.eraticAngle = eraticAngle;
		}

	}
}
