using UnityEngine;

namespace LD40 {
	[System.Serializable]
	public class ProjectileFactory {

		public ProjectileType type;
		public Vector3 heading;
		public float speed;
		public bool dieOnCollision;
		public bool hasLifeTime;
		public float lifeTime;
		public GameObject prefab;

		public ProjectileFactory(Vector3 heading, float speed, bool dieOnCollision, bool hasLifeTime, float lifeTime, GameObject prefab) {
			this.heading = heading;
			this.speed = speed;
			this.dieOnCollision = dieOnCollision;
			this.hasLifeTime = hasLifeTime;
			this.lifeTime = lifeTime;
			this.prefab = prefab;
		}

		public ProjectileFactory() : this(Vector3.forward, 0f, true, true, 3f, null) { }
		
		public Projectile CreateInstance() {
			GameObject go = Object.Instantiate(prefab, ProjectileManager.I.transform);
			Projectile proj = go.GetComponent<Projectile>();
			proj.heading = heading;
			proj.speed = speed;
			proj.dieOnCollision = dieOnCollision;
			proj.hasLifeTime = hasLifeTime;
			proj.lifeTime = lifeTime;
			return proj;
		}

		public ProjectileFactory Copy() {
			return new ProjectileFactory(heading, speed, dieOnCollision, hasLifeTime, lifeTime, prefab);
		}

		public static ProjectileFactory CreateFactory(ProjectileType type) {
			return DataCenter.I.projectiles.CreateFactory(type);
			//switch (type) {
			//	case ProjectileType.Fireball:
			//		return DataCenter.I.projectiles.fireballFactory.Copy();
			//	case ProjectileType.IceSpike:
			//		return DataCenter.I.projectiles.iceSpikeFactory.Copy();
			//	case ProjectileType.Arrow:
			//		return DataCenter.I.projectiles.arrowFactory.Copy();
			//	case ProjectileType.Tornado:
			//		return DataCenter.I.projectiles.tornadoFactory.Copy();
			//	case ProjectileType.ElectricArc:
			//		return DataCenter.I.projectiles.electricArcFactory.Copy();
			//	default:
			//		return null;
			//}
		}

	}
}
