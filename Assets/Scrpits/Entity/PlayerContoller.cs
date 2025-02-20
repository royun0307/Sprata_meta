using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private GameManager gameManager;

    [SerializeField] private SpriteRenderer ridingRenderer;
    [SerializeField][Range(0f, 10f)] public float ridingSpeed = 5f; //ž�¹��� �ִ� �߰� �ӵ�
    protected bool isRiding = false;

    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    protected override void Movement(Vector2 direction)
    {

        if (isRiding)//ž�����϶�
        {
            direction *= (speed + ridingSpeed);
            animationHandler.RidingMove(direction);
        }
        else
        {
            direction *= speed;
        }
        base.Movement(direction);
    }

    protected override void Rotate(Vector2 direction)
    {
        base.Rotate(direction);
        if (isRiding)//ž�¹��� �¿����
        {
            ridingRenderer.flipX = isLeft;
        }
    }

    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }

    void OnRiding()
    {
        GameObject riding = transform.GetChild(0).gameObject;
        riding.SetActive(!isRiding);
        isRiding = !isRiding;
    }

}
