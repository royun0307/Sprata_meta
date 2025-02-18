using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private Camera camera;
    private GameManager gameManager;

    [SerializeField] public SpriteRenderer ridingRenderer;
    private bool isRiding;

    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
        camera = Camera.main;
    }

    protected override void HandleAction()
    {


    }

    protected override void Rotate(Vector2 direction)
    {
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotz) > 90f;

        characterRenderer.flipX = isLeft;
        if (isRiding)
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
        GameObject riding = transform.GetChild(1).gameObject;
        riding.SetActive(!isRiding);
        isRiding = !isRiding;
    }

    void OnInteration()
    {

    }
}
