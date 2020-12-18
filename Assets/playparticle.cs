using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playparticle : MonoBehaviour
{
    public ParticleSystem a;
    public AudioSource b;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        a.transform.parent = null;
        a.Play();
        b.Play();
        Destroy(a.gameObject,a.duration);
        Destroy(gameObject);
    }
}
