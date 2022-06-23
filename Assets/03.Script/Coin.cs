using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    int coinCount = 0;
    float coinRotate = 100.0f;
    private void OnTriggerEnter(Collider other)
    {
        

        if(other.gameObject.name == "Player")
        {
           
           
            Destroy(gameObject);
            Getcoin();
        }
    }

    void Getcoin()
    {
        coinCount++;
        Debug.Log("coin" + coinCount);
    }

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0, coinRotate * Time.deltaTime));
    }
}
