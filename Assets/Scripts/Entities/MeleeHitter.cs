using UnityEngine;

namespace LD40 {
	public class MeleeHitter : MonoBehaviour {

		public float damage;
		public float cooldown;

		private Enemy enemy;
		private float lastHitTime;
		private HitCollider hitCollider;

		public void Start() {
			enemy = GetComponent<Enemy>();
			hitCollider = transform.Find("HitCollider").GetComponent<HitCollider>();
		}

		private void UpdateAI() {
			if (enemy.SeesTarget && hitCollider.HasEntitiesInside) {
				Hit();
			}
		}

		private void Hit() {
			if (lastHitTime + cooldown > Time.time) return;
			lastHitTime = Time.time;
			// TODO take in account anim
			enemy.Anim.SetTrigger("attack");
			foreach (LivingEntity ent in hitCollider.EntitiesInside) {
				ent.TakeDamage((ent.transform.position - transform.position).normalized, damage);
			}
		}

	}
}
