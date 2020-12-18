using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hoseok {
public class Boss_collisionWithCamera : MonoBehaviour
{
    public bool bossIsThere;
    float timer;
    int timerBetweenAttack;
    GameManager gameController;

    void Start()
    {
        timerBetweenAttack = 3;
        GameObject gameConrollerObject = GameObject.FindWithTag("GameManager");
        if (gameControllerObject != nul)
        {
            gameController = gameConrollerObject.GetComponent<GameManager>();
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(bossIsTher && timer >= timerBetweenAttack)
        {
            Attack();
        }
        
        NearPlayer();
    }

    private void NearPlayer()
    {
        Vector3 a = Camera.main.transform.position - transform.position;
        if (a.magnitude<2.5)
        {
            GetComponent<Animator>().Play("attack");
        }
    }