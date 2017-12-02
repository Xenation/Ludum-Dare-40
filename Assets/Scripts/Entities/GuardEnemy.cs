using UnityEngine;

namespace LD40 {
	public class GuardEnemy : Enemy {

		protected override void InitAI() {
			
		}

		protected override void UpdateAI() {
			if (seesTarget) {
				agent.SetDestination(lastTargetPosition);
			}
		}

		protected override void TargetSeen() {
			Debug.Log("SEEN");
		}

		protected override void TargetLost() {
			Debug.Log("LOST");
		}

	}
}
