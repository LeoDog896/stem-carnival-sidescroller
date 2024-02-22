using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MovingPlatform))]
public class MovingPlatformEditor : Editor
{
	void OnSceneGUI()
	{
		MovingPlatform movingPlatform = (MovingPlatform)target;
		Handles.color = Color.white;

		var origin = movingPlatform.transform.position - new Vector3(0, 0.5f, 0);

		Handles.DrawLine(origin, origin + Vector3.left * movingPlatform.lowerBound);
		Handles.DrawLine(origin, origin + Vector3.right * movingPlatform.upperBound);
	}
}
