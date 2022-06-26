using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
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
