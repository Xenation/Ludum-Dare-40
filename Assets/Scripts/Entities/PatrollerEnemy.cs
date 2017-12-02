using UnityEngine;

namespace LD40 {
	public class PatrollerEnemy : Enemy {

		public Vector3[] points;
		public float patrolStopRange;
		public float waitTime;

		protected override void InitAI() {
			agent.stoppingDistance = patrolStopRange;
		}

		protected override void UpdateAI() {
			if (seesTarget) {
				agent.SetDestination(lastTargetPosition);
			} else if (agent.remainingDistance <= agent.stoppingDistance) {
				agent.SetDestination(points[0]);
				ShiftPoints();
			}
		}

		protected override void TargetSeen() {
			agent.stoppingDistance = stopRange;
		}

		protected override void TargetLost() {
			agent.stoppingDistance = patrolStopRange;
		}

		private void ShiftPoints() {
			if (points.Length < 2) return;
			Vector3 first = points[0];
			for (int i = 0; i < points.Length - 1; i++) {
				points[i] = points[i + 1];
			}
			points[points.Length - 1] = first;
		}

	}
}
