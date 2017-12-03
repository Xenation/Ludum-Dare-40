using UnityEngine;

namespace LD40 {
	public class RangedShooter : MonoBehaviour {

		public float cooldown;

		private Enemy enemy;
		private float lastShotTime;

		private ProjectileFactory projectileFactory;

		public void Start() {
			enemy = GetComponent<Enemy>();
			projectileFactory = ProjectileFactory.CreateFactory(ProjectileType.Arrow, 0);
		}

		private void UpdateAI() {
			if (enemy.SeesTarget) {
				Shoot(enemy.Target.transform.position, transform.position + (enemy.Target.transform.position - transform.position).normalized);
			}
		}

		public void Shoot(Vector3 target, Vector3 spawnPoint) {
			if (lastShotTime + cooldown > Time.time) return;
			lastShotTime = Time.time;
			Projectile proj = projectileFactory.CreateInstance();
			proj.heading = (target - transform.position).normalized;
			proj.transform.position = spawnPoint;
		}

	}
}
