using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script1 : MonoBehaviour
{
    public float velocity;
    void Start()
    {
        //1. rigidbody를 생성하자

        // Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        
        // //2. 생성한 rigidbody를 rigidbody.velocity 명령어를 통해 속도를 초기화해주자.
        
        // rb.velocity = new Vector3(velocity, velocity, velocity);
        script2 aaa = new script2();
        aaa.asd();
        aaa.asdf();
    }

    void Update()
    {
        
    }

    void aaa()
    {
        Debug.Log("12345");
    }
}
