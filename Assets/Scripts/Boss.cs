using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hoseok{
public class Boss : Enemy
{
    public Animator anim;
    GameManager gameController;
    void Start()
    {
            float a = health;
            GameObject gameControllerObject = GameObject.FindWithTag("GameManager");
            if (gameControllerObject!= null)
            {
                gameController = gameControllerObject.GetComponent<GameManager>();
            }
    }

    void Update()
    {
     
    }

    public override void TakeDamage(float damage)
    {
        health -= damage;
        print(health);
        if(health < 100)
            {
                anim.SetBool("rage", true);
            }
        
        if (health<= 0)
        {
            gameController.bossdie();
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject, 1f);
    }

    void initrage()
    {
        anim.SetBool("rage", true);
    }
        }
    }

