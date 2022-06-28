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
            //EscŰ�� �������� �ѱ�
            MerchineEsc.gameObject.SetActive(true);

           
        }
    }


    private void Update()
    {
        //EscŰ�� �������� ����
        if (Input.GetKeyDown(KeyCode.H))
        {
            MerchineEsc.gameObject.SetActive(false);
        }

        //EscŰ�� ������ escŰ �ȳ� �ؽ�Ʈ�� �������� ����� ��Ÿ��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MarchinPanel.gameObject.SetActive(true);
            MerchineEsc.gameObject.SetActive(false);
        }

        //f1���� ������ ����� �г� ������.
        if (Input.GetKeyDown(KeyCode.F1))
        {
            MarchinPanel.gameObject.SetActive(false);
        }



        //������ 10�̸� 10�������� �� ������
        if (Coin.coinCountscore >= 10)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Number1_Drink.gameObject.SetActive(false);
                //������������ 10�� ������
                Damage.ggcurrHp += 10;
                Debug.Log("��");
                Coin.coinCountscore -= 10;
            }
        }

        //������ 20�̸� 20�������� �� ������
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
