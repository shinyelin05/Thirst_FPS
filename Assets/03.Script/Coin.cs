using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    
    float coinRotate = 100.0f;

    private void OnTriggerEnter(Collider other)
    {
        Score.coinCountscore = +1;

        if (other.gameObject.name == "Player")
        {
           
           
            Destroy(gameObject);
            



        }
    }

    void Getcoin()
    {
        
        //Debug.Log(coinCountscore);
        
    }

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
           // coinCountscore = coinCountscore + 1;
              

        transform.Rotate(new Vector3(0,0, coinRotate * Time.deltaTime));
       // coinCount.text = string.Format($"Coin : {coinCountscore}");

    }
}
