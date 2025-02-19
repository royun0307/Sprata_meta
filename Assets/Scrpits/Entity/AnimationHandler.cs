using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");

    protected Animator playerAnimator;
    protected Animator ridingAnimator;

    protected virtual void Awake()
    {
        playerAnimator = transform.GetChild(0).GetComponent<Animator>();
        ridingAnimator = transform.GetChild(1).GetComponent<Animator>();
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
