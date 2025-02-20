using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");

    public Animator playerAnimator;//플레이어
    public Animator ridingAnimator;//탑승물

    private void Awake()
    {        
        ridingAnimator = transform.GetChild(0).GetComponent<Animator>();
        playerAnimator = transform.GetChild(1).GetComponent<Animator>();
    }

    public void SetPlayerAnimator(GameObject go)
    {
        playerAnimator = go.GetComponent<Animator>();
    }

    public void Move(Vector2 obj)
    {
        bool flag = obj.magnitude > .5f;
        playerAnimator.SetBool(IsMoving, flag);//벡터가 0.5보다 크면 ture, 그렇지 않으면 false
    }

    public void RidingMove(Vector2 obj)//탑승물 움직임 애니메싱션
    {
        bool flag = obj.magnitude > .5f;
        ridingAnimator.SetBool(IsMoving, flag);//벡터가 0.5보다 크면 ture, 그렇지 않으면 false
    }
}
