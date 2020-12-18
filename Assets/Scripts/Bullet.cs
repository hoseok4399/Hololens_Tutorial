
using UnityEngine;

namespace Hoseok{
    public class Bullet : MonoBehaviour {
        private const float speed = 3f;
        public float damage = 0.5f;
        public GameObject bloodEffect;

        public GameObject explosionPrefab;

        void Start() {
            Destroy(this.gameObject, 8.0f);
        }

        void Update() {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        void OnCollisionEnter(Collision collision) {
            
            if ( collision.gameObject.tag != "UI") {
                ContactPoint contact = collision.contacts[0];
                Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
                Vector3 position = contact.point;
                Enemy target = collision.gameObject.GetComponent<Enemy>();

            if(target!=null)
                {
                    Debug.Log("20 데미지");
                    target.TakeDamage(damage);
                    GameObject bloodG0 = Instantiate(bloodEffect, position, rotation);
                        Destroy(bloodG0, 0.2f);
                }

                GameObject explosionObject = Instantiate(explosionPrefab, position, rotation) as GameObject;
                Destroy(explosionObject, 4.0f);

                Destroy(this.gameObject);
            }
        }
    }
}