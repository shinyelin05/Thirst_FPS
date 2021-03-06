using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UI항목을 접근하기 위해 선언하는 네임스페이스
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
  //  private const string bulletTag = "BULLET";
    private const string enemyTag = "ENEMY";

    public Image sand;

    private float initHp = 100.0f;
    public float currHp;

    private float gginitHp = 100.0f;
    public static float ggcurrHp;
    //BloodScreen 텍스처를 저장하기 위한 변수
    //public Image bloodScreen;

    //Hp Bar Image를 저장하기 위한 변수
    public Image hpBar;
    public Image ggBar;

    //생명 게이지의 처음 색상(녹색)
    private readonly Color initColor = new Vector4(0, 1.0f, 0.0f, 1.0f);
    private Color currColor;

    // 델리게이트 및 이벤트 선언
    public delegate void PlayerDieHandler();
    public static event PlayerDieHandler OnPlayerDie;

    void Start()
    {
        currHp = initHp;

        ggcurrHp = gginitHp;

        //생명 게이지의 초기 색상을 설정
        hpBar.color = initColor;
        currColor = initColor;
    }

    //충돌한 Collider의 IsTrigger 옵션이 체크됐을 때 발생
    void OnTriggerEnter(Collider coll)
    {
        DisplayHpbar();
        //충돌한 Collider의 태그가 BULLET이면 Player의 currHp를 차감
        if (coll.tag == enemyTag)
        {
            //Destroy(coll.gameObject);

            if (coll.tag == enemyTag)
            {
                StartCoroutine("delayTime");

            }

            //혈흔 효과를 표현할 코루틴 함수 호출
            //StartCoroutine(ShowBloodScreen());

            

            //생명 게이지의 색상 및 크기 변경 함수를 호출
            DisplayHpbar();

            //Player의 생명이 0 이하이면 사망 처리
            if (currHp <= 0.0f)
            {
                PlayerDie();
            }

        }
    }
     void OnTriggerStay(Collider coll)
    {
       
            
    }

    IEnumerator delayTime()
    {
        
       // Debug.Log("dljfl");
        currHp -= 5.0f;
        yield return new WaitForSeconds(1);
    }

    IEnumerator ggTime()
    {

         //Debug.Log(ggcurrHp);
        ggcurrHp -= 0.007f;
        yield return new WaitForSeconds(1);
    }


    IEnumerator ShowBloodScreen()
    {
        //BloodScreen 텍스처의 알파값을 불규칙하게 변경
       // bloodScreen.color = new Color(1, 0, 0, Random.Range(0.2f, 0.3f));
        yield return new WaitForSeconds(0.1f);
        //BloodScreen 텍스처의 색상을 모두 0으로 변경
        //bloodScreen.color = Color.clear;
    }

    //Player의 사망 처리 루틴
    void PlayerDie()
    {
       // OnPlayerDie();
        Debug.Log("PlayerDie !");
        SceneManager.LoadScene("GameOver");
        ////"ENEMY" 태그로 지정된 모든 적 캐릭터를 추출해 배열에 저장
        //GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        ////배열의 처음부터 순회하면서 적 캐릭터의 OnPlayerDie 함수를 호출 
        //for (int i = 0; i < enemies.Length; i++)
        //{
        //    enemies[i].SendMessage("OnPlayerDie", SendMessageOptions.DontRequireReceiver);
        //}
    }

    void DisplayHpbar()
    {
        //생명 수치가 50%일 때까지는 녹색에서 노란색으로 변경
        if ((currHp / initHp) > 0.5f)
            currColor.r = (1 - (currHp / initHp)) * 2.0f;
        else//생명 수치가 0%일 때까지는 노란색에서 빨간색으로 변경
            currColor.g = (currHp / initHp) * 2.0f;

        //HpBar의 색상 변경
        hpBar.color = currColor;
        //HpBar의 크기 변경
        hpBar.fillAmount = (currHp / initHp);
    }

    void ggDisplayHpbar()
    {
        //생명 수치가 50%일 때까지는 녹색에서 노란색으로 변경
        if ((ggcurrHp / gginitHp) > 0.5f)
            currColor.r = (1 - (ggcurrHp / gginitHp)) * 2.0f;
        else//생명 수치가 0%일 때까지는 노란색에서 빨간색으로 변경
        {
            currColor.g = (ggcurrHp / gginitHp) * 2.0f;
            PlayerSlow();
        }
           
        //HpBar의 색상 변경
        ggBar.color = currColor;
        //HpBar의 크기 변경
        ggBar.fillAmount = (ggcurrHp / gginitHp);
    }

    private void Update()
    {
        ggDisplayHpbar(); 
            
        StartCoroutine("ggTime");

}

    void PlayerSlow()
    {
       // PlayerMoveCode.jumpHeight -= 2.0f;
    }
   

  
}