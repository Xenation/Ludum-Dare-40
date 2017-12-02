using UnityEngine;
using UnityEngine.AI;

namespace LD40 {
	public abstract class Enemy : MonoBehaviour {

		public float range;
		public float stopRange;

		protected NavMeshAgent agent;
		public Caster Target { get; protected set; }
		protected Vector3 lastTargetPosition;
		public bool SeesTarget { get; protected set; }

		private void Start() {
			SeesTarget = false;
			agent = GetComponent<NavMeshAgent>();
			agent.stoppingDistance = stopRange;
			Target = EntitiesManager.I.player;
			InitAI();
		}

		public void Update() {
			RaycastHit hit;
			if (Physics.Raycast(transform.position, (Target.transform.position - transform.position).normalized, out hit, range, 1 << LayerMask.NameToLayer("Player"))) {
				lastTargetPosition = Target.transform.position;
				if (!SeesTarget) {
					SeesTarget = true;
					TargetSeen();
				}
			} else if (SeesTarget) {
				SeesTarget = false;
				TargetLost();
			}
			//UpdateAI();
			SendMessage("UpdateAI");
		}

		protected abstract void InitAI();

		protected abstract void UpdateAI();

		protected abstract void TargetSeen();
		protected abstract void TargetLost();

	}
}
