using UnityEngine;

namespace LD40 {
	public abstract class LivingEntity : MonoBehaviour {

		public delegate void OnDeath();
		public event OnDeath OnDeathEvent;

		public float health = 10f;

		protected virtual void OnPreTakeDamage() { }

		public void TakeDamage(float dmg) {
			OnPreTakeDamage();
			health -= dmg;
			if (health <= 0f) {
				health = 0f;
				Die();
			} else {
				// TODO Take in account anim
			}
		}

		protected void TriggerDeathEvent() {
			if (OnDeathEvent != null) {
				OnDeathEvent.Invoke();
			}
		}

		protected abstract void Die();

	}
}
