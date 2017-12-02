using UnityEditor;
using UnityEngine;

namespace LD40 {
	[CustomEditor(typeof(PatrollerEnemy))]
	public class PatrollerEditor : Editor {

		private static GUIStyle style = new GUIStyle();

		private PatrollerEnemy targ;

		private void OnEnable() {
			targ = target as PatrollerEnemy;
			style.normal.textColor = Color.cyan;
			style.fontSize = 42;
		}

		private void OnSceneGUI() {
			for (int i = 0; i < targ.points.Length; i++) {
				targ.points[i] = Handles.DoPositionHandle(targ.points[i] + Vector3.up, Quaternion.identity) - Vector3.up;
				Handles.Label(targ.points[i] + Vector3.up * 2, new GUIContent("" + i), style);
			}
			EditorUtility.SetDirty(targ);
		}

	}
}
