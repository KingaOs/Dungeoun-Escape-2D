﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }


    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public void Damage()
    {
        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        if (Health < 1)
            Destroy(this.gameObject);
    }

}
