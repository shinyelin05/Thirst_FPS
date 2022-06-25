using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float damage = 10.0f;
    public float speed = 1000.0f;
    void Start()
    {
      GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed * Time.deltaTime);
       // GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
     // Invoke("Destroy", 1f); ;
    }

    void Update()
    {
        
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
    
  

}
