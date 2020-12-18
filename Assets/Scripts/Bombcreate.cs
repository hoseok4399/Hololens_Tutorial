using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hoseok{
public class Bombcreate : MonoBehaviour
{
    public float Force = 13f;
    public GameObject bomb;
    private Transform target;
    private float timeAfterSpawn;
    private float timer;
    private float healtimer;
    private float healcooltime;
    public float bombcooltime;
    GameManager gameController;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        healtimer = 0f;
        bombcooltime = 1f;
        healcooltime = 5f;
        target = GameObject.FindWithTag("MainCamera").transform;
        GameObject gameControllerObject = GameObject.FindWithTag("GameManager");
        if (gameControllerObject!= null)
        {
            gameController = gameControllerObject.GetComponent<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        healtimer += Time.deltaTime;
    }

    public void create()
    {
        if(timer >= bombcooltime)
        {
            GameObject bombInstance = Instantiate(bomb,transform.position + new Vector3 (0f,2f,0.5f), transform.rotation);
            Rigidbody bombrigidbody = bombInstance.GetComponent<Rigidbody>();
            bombrigidbody.velocity = transform.forward * Force;
            Destroy(bombInstance, 4);
            timer = 0;
        }
        
    }

        public void heal()
    {
        if(timer >= healcooltime)
        {
            gameController.health = 100;
            healtimer = 0;
        }
        
    }
}
}