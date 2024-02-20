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

		Handles.DrawLine(movingPlatform.transform.position, movingPlatform.transform.position + Vector3.left * movingPlatform.lowerBound);
		Handles.DrawLine(movingPlatform.transform.position, movingPlatform.transform.position + Vector3.right * movingPlatform.upperBound);
	}
}
