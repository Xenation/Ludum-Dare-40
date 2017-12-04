using UnityEngine;

namespace LD40 {
	public abstract class LivingEntity : MonoBehaviour {

		public delegate void OnDeath();
		public event OnDeath OnDeathEvent;

		public float health = 10f;
		private float maxHealth;

		private void Awake() {
			maxHealth = health;
		}

		public float GetMaxHealth() {
			return maxHealth;
		}

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

		protected virtual void OnPreHeal() { }

		public void Heal(float h) {
			OnPreHeal();
			health += h;
			if (health > maxHealth) {
				health = maxHealth;
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
