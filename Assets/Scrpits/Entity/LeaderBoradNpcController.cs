using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoradNpcController : NpcController
{
    [SerializeField] public Tuple<string, string>[] game = { 
        new Tuple<string, string>("TheStack", "Stack_BestScore") };
    protected override void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {

        }
    }
}
