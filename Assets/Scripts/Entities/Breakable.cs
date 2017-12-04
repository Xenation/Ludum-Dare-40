using UnityEngine;

namespace LD40 {
	public class Breakable : LivingEntity {

		public GameObject collectiblePrefab;
		public GameObject breakEffect;
		public float dropChance;

		protected override void Die() {
			if (Random.value <= dropChance) {
				Instantiate(collectiblePrefab, transform.position, Quaternion.identity);
			}
			Instantiate(breakEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
