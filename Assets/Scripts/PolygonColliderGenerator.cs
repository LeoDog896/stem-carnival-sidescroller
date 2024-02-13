using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonColliderGenerator : MonoBehaviour
{
    private List<Vector2> points = new List<Vector2>();
    [SerializeField] private PolygonCollider2D polygonCollider2D;
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Start()
    {
        polygonCollider2D.pathCount = spriteRenderer.sprite.GetPhysicsShapeCount();
        for (int i = 0; i < polygonCollider2D.pathCount; i++)
        {
            spriteRenderer.sprite.GetPhysicsShape(i, points);
            polygonCollider2D.SetPath(i, points);
        }
    }
}
