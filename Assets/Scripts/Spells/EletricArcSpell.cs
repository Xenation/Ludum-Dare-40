using UnityEngine;

namespace LD40 {
	[System.Serializable]
	public class EletricArcSpell : Spell {

		public float doubleAngle = 60f;

		public override SpellType GetSpellType() {
			return SpellType.ElectricArc;
		}

		protected override void InitFactories() {
			ProjectileFactory p1, p2;
			if (Instability >= 1) {
				p1 = ProjectileFactory.CreateFactory(ProjectileType.ElectricArc, Instability);
				p1.heading = Quaternion.Euler(0f, -doubleAngle, 0f) * Vector3.forward;
				AddFactory(p1);
				p2 = ProjectileFactory.CreateFactory(ProjectileType.ElectricArc, Instability);
				p2.heading = Quaternion.Euler(0f, doubleAngle, 0f) * Vector3.forward;
				AddFactory(p2);
			} else {
				p1 = ProjectileFactory.CreateFactory(ProjectileType.ElectricArc, Instability);
				p1.heading = Vector3.forward;
				AddFactory(p1);
			}
		}

	}
}
