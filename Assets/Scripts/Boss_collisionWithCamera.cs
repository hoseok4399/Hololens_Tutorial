using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hoseok {
public class Boss_collisionWithCamera : MonoBehaviour
{
    public float attackspeed;
    float timer;
    int timerBetweenAttack;
    GameManager gameController;
    public GameObject meleearea;

    void Start() 
    {
        attackspeed = 1;
        timerBetweenAttack = 6;
        GameObject gameConrollerObject = GameObject.FindWithTag("GameManager");
        if (gameConrollerObject != null)
        {
            gameController = gameConrollerObject.GetComponent<GameManager>();
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        
        NearPlayer();
        
    }

    private void NearPlayer()
    {
        Vector3 a = Camera.main.transform.position - transform.position;
        if (a.magnitude<2.5)
        {
            if(timer >= timerBetweenAttack)
            {
            StartCoroutine("Attack");
            }
        }
    }

    IEnumerator Attack()
    {
        timer = 0;
        Debug.Log("보스 공격");
        GetComponent<Animator>().Play("attack");
        yield return new WaitForSeconds(0.8f / attackspeed);
        meleearea.SetActive(true);
        yield return new WaitForSeconds(1f / attackspeed);
        meleearea.SetActive(false); 
    }
}

}