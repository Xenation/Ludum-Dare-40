using UnityEngine;

namespace LD40 {
	public class ProjectileManager : Singleton<ProjectileManager> {

		public GameObject fireballProjPrefab;
		public GameObject iceSpikePrefab;

		public Projectile CreateProjectile(ProjectileType type) {
			GameObject go;
			switch (type) {
				case ProjectileType.Fireball:
					go = Instantiate(fireballProjPrefab, transform);
					return go.GetComponent<Projectile>();
				case ProjectileType.IceSpike:
					go = Instantiate(iceSpikePrefab, transform);
					return go.GetComponent<Projectile>();
				default:
					return null;
			}
		}

	}
}
