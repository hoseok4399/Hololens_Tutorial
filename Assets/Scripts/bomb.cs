using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Hoseok{
public class bomb : MonoBehaviour
{
    public LayerMask whatIsEnemy;
    public ParticleSystem explosionParticle;
    public AudioSource explosionAudio;

    public float maxDamage = 100f;
    public float explosionForce = 1000f;
    public float lifeTime = 5f;
    public float explosionRadius = 20f;

    void Start()
    {
        Destroy(gameObject,lifeTime); 
    }

    private void OnTriggerEnter(Collider order)
    {  
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, whatIsEnemy);
        for (int i = 0; i< colliders.Length ; i++) 
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
            targetRigidbody.AddExplosionForce(explosionForce, transform.position,explosionRadius);

            
            if ( colliders[i].GetComponent<Boss>() != null )
            {
                Boss targetBoss = colliders[i].GetComponent<Boss>();
                float damage = CalculateDamage(colliders[i].transform.position);
                Debug.Log(damage);
                targetBoss.TakeDamage(damage);
            }
            else
            {
                Enemy targetEnemy = colliders[i].GetComponent<Enemy>();
                float damage = CalculateDamage(colliders[i].transform.position);
                Debug.Log(damage);
                targetEnemy.TakeDamage(damage);
            }
            
        }

        
        var effect = Instantiate(explosionParticle, transform.position, transform.rotation);
        Destroy(effect.gameObject, effect.duration);

        Destroy(gameObject);
        }

        private float CalculateDamage(Vector3 targetPosition)
        {
            Vector3 explosionToTarget = targetPosition - transform.position;
            float distance = explosionToTarget.magnitude;
            float edgeToCenterDistance = explosionRadius - distance;
            float percentage = edgeToCenterDistance / explosionRadius;

            float damage = maxDamage * percentage;
            damage = Mathf.Max(0,damage);
            return damage;
        }
}
}

    
