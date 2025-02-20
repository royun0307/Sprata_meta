using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    [Range(0f, 10f)][SerializeField] protected float speed = 5f; //�̵��ӵ�

    protected Rigidbody2D _rigidbody;

    [SerializeField] public SpriteRenderer characterRenderer;


    protected Vector2 movementDirection = Vector2.zero; //�����̴� ����
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;//���� ����
    public Vector2 LookDirection { get { return lookDirection; } }

    protected AnimationHandler animationHandler;

    public bool isLeft = false;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    protected virtual void Update()
    {
        Rotate(lookDirection);//ȸ��
    }

    protected virtual void FixedUpdate()
    {
        Movement(MovementDirection);//������
    }

    protected virtual void Movement(Vector2 direction)//������
    {
        _rigidbody.velocity = direction;
        lookDirection = direction.normalized;
        animationHandler.Move(direction);//�ִϸ��̼� ����
    }

    protected virtual void Rotate(Vector2 direction)//ȸ��
    {
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        isLeft = Mathf.Abs(rotz) > 90f;

        characterRenderer.flipX = isLeft;//�¿����
    }
}
