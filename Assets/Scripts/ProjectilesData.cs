using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace LD40 {
	[CreateAssetMenu(fileName = "Projectiles", menuName = "Projectiles Data", order = 101)]
	public class ProjectilesData : ScriptableObject {
		
		public ProjectileFactory fireballFactory;
		public ProjectileFactory iceSpikeFactory;
		public ProjectileFactory arrowFactory;
		public ProjectileFactory tornadoFactory;
		public ProjectileFactory electricArcFactory;
		public ProjectileFactory beamFactory;

		private List<ProjectileFactory> factories;

		public void OnEnable() {
			factories = new List<ProjectileFactory>();
			foreach (FieldInfo field in GetType().GetFields()) {
				if (!field.IsPublic) continue;
				factories.Add((ProjectileFactory) field.GetValue(this));
			}
		}

		public void OnDisable() {
			if (factories != null) {
				factories.Clear();
			}
		}

		public ProjectileFactory CreateFactory(ProjectileType type) {
			foreach (ProjectileFactory fact in factories) {
				if (fact.type == type) return fact.Copy();
			}
			return null;
		}

	}
}
