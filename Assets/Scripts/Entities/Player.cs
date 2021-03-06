﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD40 {
	[AddComponentMenu("_LD40/Player")]
	public class Player : Caster {

		public float speed = 5f;
		public float maxSlope = 45f;
		public float gravity = -5f;
		public float dieDelay = 1.2f;
		public float knockMult = 5f;
		public float genVelDampen = 4f;

		[HideInInspector]
		public bool hasControl = true;

		private Rigidbody rb;
		private Vector3 vel = Vector3.zero;
		private bool isGrounded = false;
		private Vector3 groundNormal = Vector3.up;
		private Vector3 horizTangent = Vector3.right;
		private Vector3 vertTangent = Vector3.forward;
		private Vector3 genVel = Vector3.zero;

		private Vector3 target;

		private Animator animator;

		private void Start() {
			rb = GetComponent<Rigidbody>();
			SelectSpell(Spell.GetSpell(SpellType.Fireball, this));
			animator = GetComponentInChildren<Animator>();
		}

		protected override void OnPreTakeDamage(Vector3 hitDir, float dmg) {
			genVel = hitDir * knockMult;
			animator.SetTrigger("hit");
		}

		protected override void Die() {
			TriggerDeathEvent();
			// TODO take in account Gameover and anim
			animator.SetTrigger("die");
			Invoke("PostDieAnim", dieDelay);
		}

		private void PostDieAnim() {
			Destroy(gameObject);
		}

		protected override void PerformUpdate() {
			if (!hasControl) {
				vel = Vector3.zero;
				animator.SetFloat("speed", 0f);
				if (isFiring) {
					StopFiring();
				}
				return;
			}

			// Movement
			if (!isGrounded) {
				horizTangent = Vector3.right;
				vertTangent = Vector3.forward;
			}
			Debug.DrawLine(transform.position, transform.position + horizTangent, Color.red);
			Debug.DrawLine(transform.position, transform.position + vertTangent, Color.blue);
			vel = horizTangent * Input.GetAxisRaw("Horizontal") + vertTangent * Input.GetAxisRaw("Vertical");
			vel.Normalize();
			vel *= speed;
			animator.SetFloat("speed", vel.magnitude);

			// Heading
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			Debug.DrawLine(ray.origin, ray.origin + ray.direction * 1000f, Color.green);
			if (Physics.Raycast(ray, out hit, 100f, 1 << LayerMask.NameToLayer("Ground"))) {
				target = hit.point + Vector3.up;
				Debug.DrawLine(transform.position, target, Color.red);
			} else {
				Plane playerPlane = new Plane(transform.position, transform.position + Vector3.forward, transform.position + Vector3.right);
				float distance;
				playerPlane.Raycast(ray, out distance);
				target = ray.origin + ray.direction * distance;
			}
			transform.LookAt(new Vector3(target.x, transform.position.y, target.z));

			// Actions
			if (Input.GetButton("Select Spell 1")) {
				SelectSpell(Spell.GetSpell(SpellType.Fireball, this));
			}
			if (Input.GetButton("Select Spell 2") && SpellsManager.I.generalInstability > 0) {
				SelectSpell(Spell.GetSpell(SpellType.IceSpike, this));
			}
			if (Input.GetButton("Select Spell 3") && SpellsManager.I.generalInstability > 1) {
				SelectSpell(Spell.GetSpell(SpellType.ElectricArc, this));
			}
			if (Input.GetButton("Select Spell 4") && SpellsManager.I.generalInstability > 2) {
				SelectSpell(Spell.GetSpell(SpellType.Tornado, this));
			}
			if (Input.GetButton("Select Spell 5") && SpellsManager.I.generalInstability > 3) {
				SelectSpell(Spell.GetSpell(SpellType.Beam, this));
			}

			if (Input.GetButtonDown("Fire1")) {
				StartFiring();
			}
			if (Input.GetButton("Fire1")) {
				SelectedSpell.target = target;
			}
			if (Input.GetButtonUp("Fire1")) {
				StopFiring();
			}
		}

		protected override void PreSpellFired() {
			animator.SetTrigger("attack");
		}

		private void FixedUpdate() {
			if (!isGrounded) {
				vel.y += gravity;
			}
			rb.velocity = vel + genVel;
			genVel -= genVel * genVelDampen * Time.fixedDeltaTime;
		}

		private void OnCollisionEnter(Collision collision) {
			if (collision.gameObject.layer != LayerMask.NameToLayer("Ground")) return;
			isGrounded = true;
			groundNormal = collision.contacts[0].normal;
			horizTangent = Vector3.Cross(groundNormal, Vector3.forward).normalized;
			vertTangent = Vector3.Cross(groundNormal, Vector3.left).normalized;
			Vector3 tang = (horizTangent + vertTangent).normalized;
			if (Vector3.Angle(tang, new Vector3(1f, 0f, 1f)) > maxSlope) {
				horizTangent = Vector3.right;
				vertTangent = Vector3.forward;
			}
		}

		private void OnCollisionStay(Collision collision) {
			if (collision.gameObject.layer != LayerMask.NameToLayer("Ground")) return;
			isGrounded = true;
			groundNormal = collision.contacts[0].normal;
			horizTangent = Vector3.Cross(groundNormal, Vector3.forward).normalized;
			vertTangent = Vector3.Cross(groundNormal, Vector3.left).normalized;
			Vector3 tang = (horizTangent + vertTangent).normalized;
			if (Vector3.Angle(tang, new Vector3(1f, 0f, 1f)) > maxSlope) {
				horizTangent = Vector3.right;
				vertTangent = Vector3.forward;
			}
		}

		private void OnCollisionExit(Collision collision) {
			if (collision.gameObject.layer != LayerMask.NameToLayer("Ground")) return;
			isGrounded = false;
		}

	}
}
