using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float damage = 10.0f;
    public float speed = 1000.0f;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * speed *Time.deltaTime);
    }

    void Update()
    {
        
    }
}
