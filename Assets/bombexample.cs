using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombexample : MonoBehaviour
{
    public ParticleSystem explosionPaticle;
    public AudioSource explosionSound;

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
        
        explosionPaticle.Play();
        explosionSound.Play();
        Destroy(gameObject);
    }
}
