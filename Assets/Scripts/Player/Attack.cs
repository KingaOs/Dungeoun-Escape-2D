using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool canAttack = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable hit = collision.GetComponent<IDamageable>();

        if(hit != null && canAttack)
        {
            Debug.Log(collision.name);
            hit.Damage();
            canAttack = false;
            StartCoroutine(CoolDown());
        }

    }


    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }
}
