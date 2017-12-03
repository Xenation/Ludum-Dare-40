using UnityEngine;

namespace LD40 {
	public class ProjectileTrail : MonoBehaviour {

		public bool instantStop = true;

		private Projectile projectile;
		private ParticleSystem system;
		private bool isDying = false;

		private void Start() {
			projectile = transform.GetComponentInParent<Projectile>();
			if (projectile != null) {
				projectile.OnDeathEvent += ProjectileDeath;
			}
			system = GetComponent<ParticleSystem>();
		}

		private void Update() {
			if (isDying && system.particleCount == 0) {
				Debug.Log("No particles");
				Die();
			}
		}

		private void ProjectileDeath() {
			transform.SetParent(ProjectileManager.I.transform);
			if (instantStop) {
				system.Stop();
			}
			isDying = true;
		}

		private void Die() {
			if (!instantStop) {
				system.Stop();
			}
			Destroy(gameObject);
		}

	}
}
