using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpCube : MonoBehaviour
{
    float cubeRotate = 100.0f;
   // public GameObject sand;
   public Image sand;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(gameObject);
            sand.gameObject.SetActive(true);

        }

       


    }
    

    void Update()
    {
        transform.Rotate(new Vector3(cubeRotate * Time.deltaTime, cubeRotate * Time.deltaTime, cubeRotate * Time.deltaTime));
    }
}
