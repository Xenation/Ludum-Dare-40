using System.Collections.Generic;
using UnityEngine;

namespace LD40 {
	[CreateAssetMenu(fileName = "Projectiles", menuName = "Projectiles Data", order = 101)]
	public class ProjectilesData : ScriptableObject {
		
		public ProjectileFactory fireballFactory;
		public ProjectileFactory iceSpikeFactory;
		public ProjectileFactory arrowFactory;

	}
}
