using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hoseok{
    public class Enemy : MonoBehaviour
    {
        public float health = 30f;
        AudioSource bloodSound;
        GameManager gameController;
        // Start is called before the first frame update
        void Start()
        {
            GameObject gameControllerObject = GameObject.FindWithTag("GameManager");
            if (gameControllerObject!= null)
            {
                gameController = gameControllerObject.GetComponent<GameManager>();
            }
            AudioSource[] audios = GetComponents<AudioSource>();
            bloodSound = audios[1];
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        virtual public void  TakeDamage(float damage)
        {
            //bloodSound.Play();
            health -= damage;
            print(health);

            if(health<=0f)
            {
                Die();
            }
        }

        void Die()
        {
            Destroy(gameObject, 1f);
        }
    }
}