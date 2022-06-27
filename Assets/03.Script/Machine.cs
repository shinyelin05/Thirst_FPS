using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Machine : MonoBehaviour
{

    private const string playerTag = "PLAYER";
    public Text MerchineEsc;
    public GameObject MarchinPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerTag)
        {
           // Debug.Log("¿õ");

            MerchineEsc.gameObject.SetActive(true);

           
        }
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            MerchineEsc.gameObject.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MarchinPanel.gameObject.SetActive(true);
            MerchineEsc.gameObject.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MarchinPanel.gameObject.SetActive(false);
        }
    }





}
