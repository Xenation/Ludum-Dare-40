using UnityEngine;

namespace LD40 {
	[System.Serializable]
	public class ProjectileFactory {

		public Vector3 heading;
		public float speed;
		public bool dieOnCollision;
		public float lifeTime;
		public GameObject prefab;

		public ProjectileFactory(Vector3 heading, float speed, bool dieOnCollision, float lifeTime, GameObject prefab) {
			this.heading = heading;
			this.speed = speed;
			this.dieOnCollision = dieOnCollision;
			this.lifeTime = lifeTime;
			this.prefab = prefab;
		}

		public ProjectileFactory() : this(Vector3.forward, 0f, true, 3f, null) { }
		
		public Projectile CreateInstance() {
			GameObject go = Object.Instantiate(prefab, ProjectileManager.I.transform);
			Projectile proj = go.GetComponent<Projectile>();
			proj.heading = heading;
			proj.speed = speed;
			proj.dieOnCollision = dieOnCollision;
			proj.lifeTime = lifeTime;
			return proj;
		}

		public ProjectileFactory Copy() {
			return new ProjectileFactory(heading, speed, dieOnCollision, lifeTime, prefab);
		}

		public static ProjectileFactory CreateFactory(ProjectileType type) {
			switch (type) {
				case ProjectileType.Fireball:
					return DataCenter.I.projectiles.fireballFactory.Copy();
				case ProjectileType.IceSpike:
					return DataCenter.I.projectiles.iceSpikeFactory.Copy();
				case ProjectileType.Arrow:
					return DataCenter.I.projectiles.arrowFactory.Copy();
				default:
					return null;
			}
		}

	}
}
