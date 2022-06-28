using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    //int playerScore = 0;

    //public Text playerScoreText;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("À½");
            GameQuit();
        }
    }
    public void GameQuit()
    {
        Application.Quit();
    }
    void Start()
    {
        
    }

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("CUBE"))
		{


		}
	}
}
