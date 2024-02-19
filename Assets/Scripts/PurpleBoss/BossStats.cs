using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;

public class BossStats : Enemy
{
    [SerializeField] private BossController bossController;
    public override void HurtSequence()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Dmg"))
            return;

        anim.SetTrigger("Damage");

        base.HurtSequence();
    }

    public override void DeathSequence()
    {

        base.DeathSequence();
        bossController.ChangeState(BossState.death);
        Instantiate(explosionPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
    }

   private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            collision.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
        }
    }
}
