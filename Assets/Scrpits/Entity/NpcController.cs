using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    private SpriteRenderer npcSpriteRenderer;

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }


    public void Awake()
    {
        npcSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        Rotate(lookDirection);
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            lookDirection = collision.gameObject.transform.position - transform.position;
        }
    }

    private void Rotate(Vector2 direction)
    {
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotz) > 90f;

        npcSpriteRenderer.flipX = isLeft;
    }
}
