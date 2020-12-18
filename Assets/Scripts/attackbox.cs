using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hoseok{
public class attackbox : MonoBehaviour
{
    GameManager gameController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameConrollerObject = GameObject.FindWithTag("GameManager");
        if (gameConrollerObject != null)
        {
            gameController = gameConrollerObject.GetComponent<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "MainCamera")
        {
            Debug.Log("보스의 공격성공");
            gameController.bossAttack();
            }
        }
    }
}