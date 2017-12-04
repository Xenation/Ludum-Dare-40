using System.Collections.Generic;
using UnityEngine;

namespace LD40 {
	public static class CollisionUtil {

		public static List<LivingEntity> EntitiesInBeam(Vector3 origin, Vector3 heading, float width, float maxRange) {
			List<LivingEntity> inside = new List<LivingEntity>();
			Collider[] colliders = Physics.OverlapCapsule(origin, origin + heading * maxRange, width);
			LivingEntity cur;
			for (int i = 0; i < colliders.Length; i++) {
				cur = colliders[i].GetComponentInParent<LivingEntity>();
				if (cur != null && !inside.Contains(cur)) inside.Add(cur);
			}
			return inside;
		}

		public static List<LivingEntity> EntitiesInCone(Vector3 center, Vector3 coneHeading, float coneAngle, float range) {
			List<LivingEntity> inside = EntitiesInSphere(center, range);
			for (int i = 0; i < inside.Count; i++) {
				Vector3 toEnt = (inside[i].transform.position - center).normalized;
				if (Vector3.Angle(toEnt, coneHeading) > coneAngle) {
					inside.Remove(inside[i--]);
				}
			}
			return inside;
		}

		public static List<LivingEntity> EntitiesInSphere(Vector3 center, float range) {
			List<LivingEntity> inside = new List<LivingEntity>();
			Collider[] colliders = Physics.OverlapSphere(center, range);
			LivingEntity cur;
			for (int i = 0; i < colliders.Length; i++) {
				cur = colliders[i].GetComponentInParent<LivingEntity>();
				if (cur != null && !inside.Contains(cur)) inside.Add(cur);
			}
			return inside;
		}

	}
}
