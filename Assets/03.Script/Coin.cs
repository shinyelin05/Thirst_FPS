using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    
    float coinRotate = 100.0f;

    int coinCountscore = 0;

    public Text coinText;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Player")
        {
           
           
            Destroy(gameObject);
            coinCountscore += 1;
            //Debug.Log(coinCountscore);
            coinText.text = "Count: " + coinCountscore;
            
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
        
        transform.Rotate(new Vector3(0,0, coinRotate * Time.deltaTime));
        // coinText.text = string.Format($"Coin : {0}", coinCountscore);
        
    }
}
