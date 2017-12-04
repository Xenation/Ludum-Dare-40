using UnityEditor;
using UnityEngine;

namespace LD40 {
	public class TimeScaler : EditorWindow {

		public float timeScale = 1f;

		[MenuItem("Window/Time Scaler")]
		public static void Init() {
			GetWindow<TimeScaler>().Show();
		}

		public void OnGUI() {
			GUILayout.Label("Time Scale:");
			timeScale = EditorGUILayout.Slider(timeScale, 0.001f, 4f);
		}

		public void Update() {
			if (EditorApplication.isPlaying) {
				Time.timeScale = timeScale;
			} else {
				Time.timeScale = 1f;
			}
		}

	}
}
