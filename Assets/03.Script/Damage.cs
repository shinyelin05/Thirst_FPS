using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UI�׸��� �����ϱ� ���� �����ϴ� ���ӽ����̽�
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
  //  private const string bulletTag = "BULLET";
    private const string enemyTag = "ENEMY";

    private float initHp = 100.0f;
    public float currHp;

    private float gginitHp = 100.0f;
    public float ggcurrHp;
    //BloodScreen �ؽ�ó�� �����ϱ� ���� ����
    //public Image bloodScreen;

    //Hp Bar Image�� �����ϱ� ���� ����
    public Image hpBar;
    public Image ggBar;

    //���� �������� ó�� ����(���)
    private readonly Color initColor = new Vector4(0, 1.0f, 0.0f, 1.0f);
    private Color currColor;

    // ��������Ʈ �� �̺�Ʈ ����
    public delegate void PlayerDieHandler();
    public static event PlayerDieHandler OnPlayerDie;

    void Start()
    {
        currHp = initHp;

        ggcurrHp = gginitHp;

        //���� �������� �ʱ� ������ ����
        hpBar.color = initColor;
        currColor = initColor;
    }

    //�浹�� Collider�� IsTrigger �ɼ��� üũ���� �� �߻�
    void OnTriggerEnter(Collider coll)
    {
        DisplayHpbar();
        //�浹�� Collider�� �±װ� BULLET�̸� Player�� currHp�� ����
        if (coll.tag == enemyTag)
        {
            //Destroy(coll.gameObject);

            if (coll.tag == enemyTag)
            {
                StartCoroutine("delayTime");

            }

            //���� ȿ���� ǥ���� �ڷ�ƾ �Լ� ȣ��
            //StartCoroutine(ShowBloodScreen());

            

            //���� �������� ���� �� ũ�� ���� �Լ��� ȣ��
            DisplayHpbar();

            //Player�� ������ 0 �����̸� ��� ó��
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
        //BloodScreen �ؽ�ó�� ���İ��� �ұ�Ģ�ϰ� ����
       // bloodScreen.color = new Color(1, 0, 0, Random.Range(0.2f, 0.3f));
        yield return new WaitForSeconds(0.1f);
        //BloodScreen �ؽ�ó�� ������ ��� 0���� ����
        //bloodScreen.color = Color.clear;
    }

    //Player�� ��� ó�� ��ƾ
    void PlayerDie()
    {
       // OnPlayerDie();
        Debug.Log("PlayerDie !");
        ////"ENEMY" �±׷� ������ ��� �� ĳ���͸� ������ �迭�� ����
        //GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        ////�迭�� ó������ ��ȸ�ϸ鼭 �� ĳ������ OnPlayerDie �Լ��� ȣ�� 
        //for (int i = 0; i < enemies.Length; i++)
        //{
        //    enemies[i].SendMessage("OnPlayerDie", SendMessageOptions.DontRequireReceiver);
        //}
    }

    void DisplayHpbar()
    {
        //���� ��ġ�� 50%�� �������� ������� ��������� ����
        if ((currHp / initHp) > 0.5f)
            currColor.r = (1 - (currHp / initHp)) * 2.0f;
        else//���� ��ġ�� 0%�� �������� ��������� ���������� ����
            currColor.g = (currHp / initHp) * 2.0f;

        //HpBar�� ���� ����
        hpBar.color = currColor;
        //HpBar�� ũ�� ����
        hpBar.fillAmount = (currHp / initHp);
    }

    void ggDisplayHpbar()
    {
        //���� ��ġ�� 50%�� �������� ������� ��������� ����
        if ((ggcurrHp / gginitHp) > 0.5f)
            currColor.r = (1 - (ggcurrHp / gginitHp)) * 2.0f;
        else//���� ��ġ�� 0%�� �������� ��������� ���������� ����
            currColor.g = (ggcurrHp / gginitHp) * 2.0f;

        //HpBar�� ���� ����
        ggBar.color = currColor;
        //HpBar�� ũ�� ����
        ggBar.fillAmount = (ggcurrHp / gginitHp);
    }

    private void Update()
    {
        ggDisplayHpbar(); 
        //Debug.Log(currHp);
        StartCoroutine("ggTime");

    }
}