using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Adapted from https://github.com/SebLague/Field-of-View/blob/master/Episode%2003/FieldOfView.cs
public class FieldOfView : MonoBehaviour
{
	public float viewRadius;
	[Range(0, 360)]
	public float viewAngle;

	public LayerMask targetMask;
	public LayerMask obstacleMask;

	public float meshResolution;
	public int edgeResolveIterations;
	public float edgeDstThreshold;

	public float maskCutawayDst = .1f;

	public MeshFilter viewMeshFilter;
	Mesh viewMesh;

	public CountdownManager countdownManager;

	void Start()
	{
        viewMesh = new Mesh
        {
            name = "View Mesh"
        };
        viewMeshFilter.mesh = viewMesh;
	}


	void LateUpdate()
	{
		DrawFieldOfView();
	}

	void DrawFieldOfView()
	{
		int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
		float stepAngleSize = viewAngle / stepCount;
		List<Vector3> viewPoints = new();
		ViewCastInfo oldViewCast = new();

		bool targetVisible = false;

		for (int i = 0; i <= stepCount; i++)
		{
			float angle = transform.eulerAngles.z - viewAngle / 2 + stepAngleSize * i;
			ViewCastInfo newViewCast = ViewCast(angle);

			if (i > 0)
			{
				bool edgeDstThresholdExceeded = Mathf.Abs(oldViewCast.dst - newViewCast.dst) > edgeDstThreshold;
				if (oldViewCast.hit != newViewCast.hit || (oldViewCast.hit && newViewCast.hit && edgeDstThresholdExceeded))
				{
					EdgeInfo edge = FindEdge(oldViewCast, newViewCast);
					if (edge.pointA != Vector2.zero)
					{
						viewPoints.Add(edge.pointA);
					}
					if (edge.pointB != Vector2.zero)
					{
						viewPoints.Add(edge.pointB);
					}
				}

			}

			if (newViewCast.rigidbody && newViewCast.rigidbody.gameObject.CompareTag("Player"))
			{
                targetVisible = true;
            }

			viewPoints.Add(newViewCast.point);
			oldViewCast = newViewCast;
		}

		int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
		int[] triangles = new int[(vertexCount - 2) * 3];

		vertices[0] = Vector2.zero;
		for (int i = 0; i < vertexCount - 1; i++)
		{
			vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]) + Vector3.forward * maskCutawayDst;

			if (i < vertexCount - 2)
			{
				triangles[i * 3] = 0;
				triangles[i * 3 + 1] = i + 1;
				triangles[i * 3 + 2] = i + 2;
			}
		}

		viewMesh.Clear();

		viewMesh.vertices = vertices;
		viewMesh.triangles = triangles;
		viewMesh.RecalculateNormals();

		countdownManager.noticedByCamera = targetVisible;
	}


	EdgeInfo FindEdge(ViewCastInfo minViewCast, ViewCastInfo maxViewCast)
	{
		float minAngle = minViewCast.angle;
		float maxAngle = maxViewCast.angle;
        Vector2 minPoint = Vector2.zero;
        Vector2 maxPoint = Vector2.zero;

		for (int i = 0; i < edgeResolveIterations; i++)
		{
			float angle = (minAngle + maxAngle) / 2;
			ViewCastInfo newViewCast = ViewCast(angle);

			bool edgeDstThresholdExceeded = Mathf.Abs(minViewCast.dst - newViewCast.dst) > edgeDstThreshold;
			if (newViewCast.hit == minViewCast.hit && !edgeDstThresholdExceeded)
			{
				minAngle = angle;
				minPoint = newViewCast.point;
			}
			else
			{
				maxAngle = angle;
				maxPoint = newViewCast.point;
			}
		}

		return new EdgeInfo(minPoint, maxPoint);
	}


	ViewCastInfo ViewCast(float globalAngle)
	{
		Vector3 dir = DirFromAngle(globalAngle, true);
		RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, viewRadius, obstacleMask);

        if (hit)
		{
			return new ViewCastInfo(true, hit.point, hit.distance, globalAngle, hit.rigidbody);
		}
		else
		{
			return new ViewCastInfo(false, transform.position + dir * viewRadius, viewRadius, globalAngle);
		}
	}

	public Vector2 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
	{
		if (!angleIsGlobal)
		{
			angleInDegrees += transform.eulerAngles.z;
		}
		return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
	}

	public struct ViewCastInfo
	{
		public bool hit;
		public Vector2 point;
		public float dst;
		public float angle;
		public Rigidbody2D rigidbody;

		public ViewCastInfo(bool _hit, Vector2 _point, float _dst, float _angle, Rigidbody2D _rigidbody = null)
		{
			hit = _hit;
			point = _point;
			dst = _dst;
			angle = _angle;
			rigidbody = _rigidbody;
		}
	}

	public struct EdgeInfo
	{
		public Vector2 pointA;
		public Vector2 pointB;

		public EdgeInfo(Vector2 _pointA, Vector2 _pointB)
		{
			pointA = _pointA;
			pointB = _pointB;
		}
	}
}
