using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("GunPlay", true);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            animator.SetBool("GunPlay", false);
        }
    }
}
