using System.Collections.Generic;
using UnityEngine;

namespace LD40 {
	public class HitCollider : MonoBehaviour {

		public bool HasEntitiesInside { get; private set; }
		public List<LivingEntity> EntitiesInside { get; private set; }

		public void Start() {
			EntitiesInside = new List<LivingEntity>();
		}

		public void OnTriggerEnter(Collider other) {
			LivingEntity entity = other.GetComponent<LivingEntity>();
			if (entity == null) return;
			EntitiesInside.Add(entity);
			HasEntitiesInside = true;
		}

		public void OnTriggerExit(Collider other) {
			LivingEntity entity = other.GetComponent<LivingEntity>();
			if (entity == null) return;
			EntitiesInside.Remove(entity);
			if (EntitiesInside.Count == 0) {
				HasEntitiesInside = false;
			}
		}

	}
}
