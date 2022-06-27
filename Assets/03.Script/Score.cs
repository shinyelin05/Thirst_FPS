using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //public Text Cointext;
    public Text PlayerScoretext;

    //public static int coinCountscore = 0;
    public static int Playerscore = 0;

    void Start()
    {
        //Cointext = GetComponent<Text>();
        PlayerScoretext = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Playerscore);
        //text.text = coinCountscore.ToString();
        

    }
}
