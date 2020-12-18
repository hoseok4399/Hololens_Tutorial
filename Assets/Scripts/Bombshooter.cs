using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Hoseok{
public class Bombshooter : MonoBehaviour
{
    public Rigidbody bomb;
    public Transform firePos;
    public AudioSource shootingAudio;
    public AudioClip fireClip;
    public float Force = 15f;
    
    private bool fired;
    
    private void OnEnable()
    {
        fired = false;
    }

    private void Start()
    {
        Fire();
    }

    private void Update()
    {
        
    }
     
    private void Fire()
    {
        fired = true;
        Rigidbody bombInstance = Instantiate(bomb, firePos.position, firePos.rotation);
        bombInstance.velocity = Force * firePos.forward;
        shootingAudio.clip = fireClip;
        shootingAudio.Play();
    }
}
}