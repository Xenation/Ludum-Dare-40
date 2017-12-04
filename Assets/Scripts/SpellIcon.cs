using UnityEngine;
using UnityEngine.UI;

namespace LD40 {
	public class SpellIcon : MonoBehaviour {

		public SpellType type;
		public Image img;

		public void Start() {
			
		}

		public void Disable() {
			gameObject.SetActive(false);
		}

		public void Select() {
			img.color = UIManager.I.selectedTint;
		}

		public void Unselect() {
			img.color = UIManager.I.unselectedTint;
		}

	}
}
