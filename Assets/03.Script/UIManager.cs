using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
	int playerScore = 0;

	public Text playerScoreText;


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
