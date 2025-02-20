using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");

    public Animator playerAnimator;
    public Animator ridingAnimator;

    private void Awake()
    {
        
        ridingAnimator = transform.GetChild(0).GetComponent<Animator>();
        playerAnimator = transform.GetChild(1).GetComponent<Animator>();
    }

    public void SetPlayerAnimator(GameObject go)
    {
        playerAnimator = go.GetComponent<Animator>();
    }

    public void Move(Vector2 obj, bool isRide)
    {
        bool flag = obj.magnitude > .5f;
        playerAnimator.SetBool(IsMoving, flag);
        if (isRide)
        {
            ridingAnimator.SetBool(IsMoving, flag);
        }
    }
}
