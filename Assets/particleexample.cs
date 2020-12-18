using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleexample : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public AudioSource explosionSound;

        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        explosionParticle.transform.parent = null;
        explosionParticle.Play();
        explosionSound.Play();
        Destroy(explosionParticle.gameObject,explosionParticle.duration);
        Destroy(gameObject);
    }
}
