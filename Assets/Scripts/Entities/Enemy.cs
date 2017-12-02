using UnityEngine;
using UnityEngine.AI;

namespace LD40 {
	public abstract class Enemy : MonoBehaviour {

		public float range;
		public float stopRange;

		protected NavMeshAgent agent;
		protected Caster target;
		protected Vector3 lastTargetPosition;
		protected bool seesTarget = false;

		private void Start() {
			agent = GetComponent<NavMeshAgent>();
			agent.stoppingDistance = stopRange;
			target = EntitiesManager.I.player;
			InitAI();
		}

		public void Update() {
			RaycastHit hit;
			if (Physics.Raycast(transform.position, (target.transform.position - transform.position).normalized, out hit, range, 1 << LayerMask.NameToLayer("Player"))) {
				lastTargetPosition = target.transform.position;
				if (!seesTarget) {
					seesTarget = true;
					TargetSeen();
				}
			} else if (seesTarget) {
				seesTarget = false;
				TargetLost();
			}
			UpdateAI();
		}

		protected abstract void InitAI();

		protected abstract void UpdateAI();

		protected abstract void TargetSeen();
		protected abstract void TargetLost();

	}
}
