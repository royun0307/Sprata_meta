using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private GameManager gameManager;



    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    protected override void HandleAction()
    {


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
