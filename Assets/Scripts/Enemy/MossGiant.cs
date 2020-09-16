using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    Vector3 currentTarget;
    float step;
    private bool _switch;
    private Animator anim;
    private SpriteRenderer mossGiantSprite;
    bool flip;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        mossGiantSprite = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            return;

        Movement();
    }


    void Movement()
    {
        Flip(flip);
        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");
            flip = false;
        }
        if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");
            flip = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

    }

    void Flip(bool flipRight)
    {
        if (flipRight)
        {
            mossGiantSprite.flipX = true;
        }
        else if (!flipRight)
        {
            mossGiantSprite.flipX = false;
        }

    }

}
