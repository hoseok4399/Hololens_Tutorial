using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hoseok {
public class collisionWithCamera : MonoBehaviour
{

    public bool zombieIsThere;
    float timer;
    int timerBetweenAttack;
    AudioSource attackSound;
    GameManager gameController;
    // Start is called before the first frame update
    void Start()
    {
            timerBetweenAttack = 2;
        GameObject gameControllerObject = GameObject.FindWithTag("GameManager");
        if (gameControllerObject!= null)
        {
            gameController = gameControllerObject.GetComponent<GameManager>();
        }

        AudioSource[] audios = GetComponents<AudioSource>();
        attackSound = audios[0];
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
     

        if(zombieIsThere && timer >= timerBetweenAttack)
        {
            Attack();
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "MainCamera")
        {
            zombieIsThere = true;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "MainCamera")
        {
            zombieIsThere = false;
        }
    }
    void Attack()
    {
        timer = 0;
        GetComponent<Animator>().Play("attack");
        gameController.zombieAttack(zombieIsThere);
        attackSound.Play();
       
    }

   
 }


}