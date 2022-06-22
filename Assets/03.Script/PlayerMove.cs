using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotationSpeed = 80.0f;

    private Transform playerTransform;
    private Animation playerAnim;

    //초기 생명 값
    private readonly float initHp = 100.0f;
    //현재 생명 값
    private float currentHp;


    IEnumerator Start()
    {
        playerTransform = GetComponent<Transform>();
        playerAnim = GetComponent<Animation>();

        playerAnim.Play("Idle");

        rotationSpeed = 0.0f;
        yield return new WaitForSeconds(0.3f);
        rotationSpeed = 80.0f;

        currentHp = initHp;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        moveDir.Normalize();

        transform.Translate(moveDir * moveSpeed * Time.deltaTime);

        transform.Rotate(Vector3.up * r * rotationSpeed * Time.deltaTime);

    }
}
