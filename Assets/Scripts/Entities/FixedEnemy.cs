using UnityEngine;

namespace LD40 {
	public class FixedEnemy : Enemy {

		protected override void InitAI() {
			
		}

		protected override void UpdateAI() {
			if (seesTarget) {
				transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
			}
		}

		protected override void TargetSeen() {
			
		}

		protected override void TargetLost() {
			
		}

	}
}
