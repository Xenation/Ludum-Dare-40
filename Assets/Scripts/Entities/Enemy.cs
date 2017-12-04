using UnityEngine;
using UnityEngine.AI;

namespace LD40 {
	public abstract class Enemy : LivingEntity {
		
		public float range;
		public float stopRange;
		public float dieDelay = 1.2f;

		protected NavMeshAgent agent;
		public Caster Target { get; protected set; }
		protected Vector3 lastTargetPosition;
		public bool SeesTarget { get; protected set; }

		public Animator Anim { get; private set; }

		private bool isDying = false;

		private void Start() {
			SeesTarget = false;
			agent = GetComponent<NavMeshAgent>();
			agent.stoppingDistance = stopRange;
			Target = EntitiesManager.I.player;
			Anim = GetComponent<Animator>();
			InitAI();
		}

		public void Update() {
			if (isDying || Target == null) return;
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
			Anim.SetFloat("speed", agent.velocity.magnitude);
			//UpdateAI();
			SendMessage("UpdateAI");
		}

		protected override void Die() {
			TriggerDeathEvent();
			// TODO take in account a delay for anim
			Anim.SetTrigger("die");
			Invoke("PostDieAnim", dieDelay);
			isDying = true;
			agent.isStopped = true;
		}

		private void PostDieAnim() {
			Destroy(gameObject);
		}

		protected abstract void InitAI();

		protected abstract void UpdateAI();

		protected abstract void TargetSeen();
		protected abstract void TargetLost();

	}
}
