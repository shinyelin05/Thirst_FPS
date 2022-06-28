using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Machine : MonoBehaviour
{

    private const string playerTag = "PLAYER";
    public Text MerchineEsc;
    public GameObject MarchinPanel;

    public GameObject Number1_Drink;
    public GameObject Number2_Drink;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerTag)
        {
            //Esc키를 누르세요 켜기
            MerchineEsc.gameObject.SetActive(true);

           
        }
    }


    private void Update()
    {
        //Esc키를 누르세요 끄기
        if (Input.GetKeyDown(KeyCode.H))
        {
            MerchineEsc.gameObject.SetActive(false);
        }

        //Esc키를 누르면 esc키 안내 텍스트가 없어지고 음료수 나타남
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MarchinPanel.gameObject.SetActive(true);
            MerchineEsc.gameObject.SetActive(false);
        }

        //f1번을 누르면 음료수 패널 없어짐.
        if (Input.GetKeyDown(KeyCode.F1))
        {
            MarchinPanel.gameObject.SetActive(false);
        }



        //코인이 10이면 10에너지가 더 높아짐
        if (Coin.coinCountscore >= 10)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Number1_Drink.gameObject.SetActive(false);
                //갈증게이지가 10씩 높아짐
                Damage.ggcurrHp += 10;
                Debug.Log("음");
                Coin.coinCountscore -= 10;
            }
        }

        //코인이 20이면 20에너지가 더 높아짐
        if (Coin.coinCountscore>=20)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Number2_Drink.gameObject.SetActive(false);
                Damage.ggcurrHp += 20;
               
                Coin.coinCountscore -= 20;
            }
        }
       else
        {

        }
    }
}
