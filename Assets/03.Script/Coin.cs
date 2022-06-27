using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    
    float coinRotate = 100.0f;

   public static int coinCountscore = 0;

    public Text coinText;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Player")
        {
            Destroy(gameObject);
            coinCountscore += 1;
            coinText.text = "Count: " + coinCountscore;
        }
    }
    void Getcoin()
    {
       
    }
    void Start()
    {
      
    }
    void Update()
    {
        
        transform.Rotate(new Vector3(0,0, coinRotate * Time.deltaTime));
        // coinText.text = string.Format($"Coin : {0}", coinCountscore);
        
    }
}
