using UnityEngine;

namespace LD40 {
	public class Door : MonoBehaviour {
		
		public Transform door;
		public Vector3 center;
		public Vector3 size;
		public float rotationSpeed = 40f;
		
		public bool hasEnemies = true; // TODO reprivate
		private float targetRotation = 0f;
		private float currentRotation = 0f;

		public void Update() {
			if (!hasEnemies) {
				currentRotation -= rotationSpeed * Time.deltaTime;
				if (currentRotation < targetRotation) {
					currentRotation = targetRotation;
				}
				door.localRotation = Quaternion.Euler(0f, 0f, currentRotation);
			} else {
				Collider[] cols = Physics.OverlapBox(center, size);
				Enemy curEnemy;
				hasEnemies = false;
				for (int i = 0; i < cols.Length; i++) {
					curEnemy = cols[i].GetComponentInParent<Enemy>();
					if (curEnemy != null) {
						hasEnemies = true;
					}
				}
				if (hasEnemies) {
					targetRotation = 0f;
				} else {
					targetRotation = -90f;
				}
			}
		}

	}
}
