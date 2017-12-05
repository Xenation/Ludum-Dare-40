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

		public float knockbackMult = 5f;
		public float genVelDampen = 6f;

		private Vector3 genVel = Vector3.zero;

		private void Start() {
			SeesTarget = false;
			agent = GetComponent<NavMeshAgent>();
			agent.stoppingDistance = stopRange;
			Target = EntitiesManager.I.player;
			Anim = GetComponentInChildren<Animator>();
			if (Anim == null) {
				Debug.Log("NULL ANIM");
			}
			if (agent == null) {
				Debug.Log("NULL AGENT");
			}
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

		private void FixedUpdate() {
			//agent.velocity += genVel * Time.fixedDeltaTime;
			//genVel -= genVel * genVelDampen * Time.fixedDeltaTime;
		}

		protected override void OnPreTakeDamage(Vector3 hitDir, float dmg) {
			//genVel = hitDir * knockbackMult;
			agent.velocity = hitDir * knockbackMult;
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
