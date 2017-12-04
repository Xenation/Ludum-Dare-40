using UnityEditor;
using UnityEngine;

namespace LD40 {
	[CustomEditor(typeof(Door))]
	public class DoorEditor : Editor {

		private Color rectInside = new Color(0f, 0f, 1f, .1f);
		private Color rectOutline = new Color(1f, 0f, 0f, .4f);

		private Door door;

		private void OnEnable() {
			door = target as Door;
		}

		private void OnSceneGUI() {
			door.center = Handles.DoPositionHandle(door.center, Quaternion.identity);
			float sizex = door.size.x;
			float sizey = door.size.y;
			float sizez = door.size.z;
			Vector3 arrx = door.center + Vector3.right * sizex;
			Vector3 arry = door.center + Vector3.up * sizey;
			Vector3 arrz = door.center + Vector3.forward * sizez;
			Vector3 oarrx = door.center - Vector3.right * sizex;
			Vector3 oarry = door.center - Vector3.up * sizey;
			Vector3 oarrz = door.center - Vector3.forward * sizez;
			Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;
			sizex = Handles.ScaleValueHandle(sizex, arrx, Quaternion.Euler(0f, 90f, 0f), HandleUtility.GetHandleSize(arrx) * 10f, Handles.ArrowHandleCap, 0f);
			sizey = Handles.ScaleValueHandle(sizey, arry, Quaternion.Euler(-90f, 0f, 0f), HandleUtility.GetHandleSize(arry) * 10f, Handles.ArrowHandleCap, 0f);
			sizez = Handles.ScaleValueHandle(sizez, arrz, Quaternion.identity, HandleUtility.GetHandleSize(arrz) * 10f, Handles.ArrowHandleCap, 0f);
			Handles.DrawSolidRectangleWithOutline(GetSideRect(arrx, Vector3.forward, Vector3.up, sizez, sizey), rectInside, rectOutline);
			Handles.DrawSolidRectangleWithOutline(GetSideRect(arry, Vector3.right, Vector3.forward, sizex, sizez), rectInside, rectOutline);
			Handles.DrawSolidRectangleWithOutline(GetSideRect(arrz, Vector3.right, Vector3.up, sizex, sizey), rectInside, rectOutline);
			Handles.DrawSolidRectangleWithOutline(GetSideRect(oarrx, Vector3.forward, Vector3.up, sizez, sizey), rectInside, rectOutline);
			Handles.DrawSolidRectangleWithOutline(GetSideRect(oarry, Vector3.right, Vector3.forward, sizex, sizez), rectInside, rectOutline);
			Handles.DrawSolidRectangleWithOutline(GetSideRect(oarrz, Vector3.right, Vector3.up, sizex, sizey), rectInside, rectOutline);
			door.size = new Vector3(sizex, sizey, sizez);
			EditorUtility.SetDirty(door);
		}

		private Vector3[] GetSideRect(Vector3 center, Vector3 side, Vector3 up, float width, float height) {
			Vector3[] verts = {
				center + side * width + up * height,
				center + side * width - up * height,
				center - side * width - up * height,
				center - side * width + up * height
			};
			return verts;
		}

	}
}
