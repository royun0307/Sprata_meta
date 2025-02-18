using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    [Range(0f, 10f)][SerializeField] private float speed = 5f;

    protected Rigidbody2D _rigidbody;

    [SerializeField] protected SpriteRenderer characterRenderer;


    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
    }

    protected virtual void HandleAction()
    {

    }
    private void Movement(Vector2 direction)
    {
        direction *= speed;

        _rigidbody.velocity = direction;
        lookDirection = direction.normalized;
        //animationHandler.Move(direction);
    }

    protected virtual void Rotate(Vector2 direction)
    {
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotz) > 90f;

        characterRenderer.flipX = isLeft;
    }
}
