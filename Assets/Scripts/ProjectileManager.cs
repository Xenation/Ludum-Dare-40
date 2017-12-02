using UnityEngine;

namespace LD40 {
	public class ProjectileManager : Singleton<ProjectileManager> {

		public GameObject fireballProjPrefab;

		public Projectile CreateProjectile(ProjectileType type) {
			switch (type) {
				case ProjectileType.Fireball:
					GameObject go = Instantiate(fireballProjPrefab, transform);
					return go.GetComponent<Projectile>();
				default:
					return null;
			}
		}

	}
}
