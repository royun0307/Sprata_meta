using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : BaseController
{
    public GameObject player;

    bool isPlayer = false;//�÷��̾ �����ߴ��� ����

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
        if (isPlayer)//���� ���� ���
        {
            lookDirection = player.gameObject.transform.position - transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))//�÷��̾ �����ϸ�
        {
            isPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))//�÷��̾ �־�����
        {
            UIManager.Instance.SetHomeUI();
            isPlayer = false;
        }
    }
}
