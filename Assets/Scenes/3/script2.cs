using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.velocity = new Vector3(3,3,3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void asd()
    {
        Debug.Log("12345");
    }

    public void asdf()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.velocity = new Vector3(3,3,3);
    }

}
