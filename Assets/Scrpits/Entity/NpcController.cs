using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : BaseController
{
    public GameObject player;

    bool isPlayer = false;//플레이어가 접근했는지 여부

    protected override void Awake()
    {
        characterRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void FixedUpdate()
    {
        
    }

    protected override void Update()
    {
        base.Update();
        if (isPlayer)//보는 방향 계싼
        {
            lookDirection = player.gameObject.transform.position - transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))//플레이어가 접근하면
        {
            isPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))//플레이어가 멀어지면
        {
            UIManager.Instance.SetHomeUI();
            isPlayer = false;
        }
    }
}
