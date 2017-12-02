using UnityEngine;

namespace LD40 {
	public class FixedEnemy : Enemy {

		protected override void InitAI() {
			
		}

		protected override void UpdateAI() {
			if (SeesTarget) {
				transform.LookAt(new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z));
			}
		}

		protected override void TargetSeen() {
			
		}

		protected override void TargetLost() {
			
		}

	}
}
