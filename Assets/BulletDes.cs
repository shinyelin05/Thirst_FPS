using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDes : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
    }

    void OnTriggerEnter(Collider other)

    {

        if (other.gameObject.CompareTag("GROUND"))

        {

            Destroy(gameObject);
        }

    }
}
