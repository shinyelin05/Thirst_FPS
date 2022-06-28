using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject sandWind;

    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Player")
        {
            sandWind.gameObject.SetActive(false);
            EnemyMove.Playerscore += 50;
        }
    }
}
