using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Hoseok{
public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 0.3f);
        transform.LookAt(Camera.main.transform.position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0); 
    }
}
}