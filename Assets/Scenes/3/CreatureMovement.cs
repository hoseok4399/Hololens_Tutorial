using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovement : MonoBehaviour
{
    public Animator anim;
    public float movespeed = 1.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = Camera.main.transform.position - transform.position;
        if (a.magnitude>2.5)     
        {transform.Translate(Vector3.forward * Time.deltaTime * movespeed);
        anim.SetFloat("speed", 1f);
        transform.LookAt(Camera.main.transform.position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0); 
        }
        
        else
        {
        anim.SetFloat("speed",0f);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0); 
        }
        
    }
}
