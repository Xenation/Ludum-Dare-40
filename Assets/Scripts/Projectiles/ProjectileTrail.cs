using UnityEngine;

namespace LD40 {
	public class ProjectileTrail : MonoBehaviour {

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
				Die();
			}
		}

		private void ProjectileDeath() {
			transform.SetParent(ProjectileManager.I.transform);
			system.Stop();
			isDying = true;
		}

		private void Die() {
			Destroy(gameObject);
		}

	}
}
