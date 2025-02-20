using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");

    public Animator playerAnimator;//�÷��̾�
    public Animator ridingAnimator;//ž�¹�

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
        playerAnimator.SetBool(IsMoving, flag);//���Ͱ� 0.5���� ũ�� ture, �׷��� ������ false
    }

    public void RidingMove(Vector2 obj)//ž�¹� ������ �ִϸ޽̼�
    {
        bool flag = obj.magnitude > .5f;
        ridingAnimator.SetBool(IsMoving, flag);//���Ͱ� 0.5���� ũ�� ture, �׷��� ������ false
    }
}
