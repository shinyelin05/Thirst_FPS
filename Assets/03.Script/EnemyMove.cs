using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnemyMove : MonoBehaviour
{
    // 몬스터의 상태 정보
    public enum State
    {
        IDLE,
        TRACE,
        ATTACK,
        PLAYERDIE,
        DIE
    }

    private const string bulletTag = "BULLET";

    // 몬스터의 현재 상태
    public State state = State.IDLE;
    // 추적 사정 거리
    public float traceDist = 10.0f;
    // 공격 사정 거리
    public float attackDist = 2.0f;
    // 몬스터의 사망 여부
    public bool isDie = false;

    private Transform monsterTransform;
    private Transform targetTransform;

    private NavMeshAgent agent;
    
    private Animator anim;


    private readonly int hashTrace = Animator.StringToHash("IsMove");
    // Animator 해쉬 값 추출
    //private readonly int hashMove = Animator.StringToHash("IsMove");

    
    private readonly int hashAttack = Animator.StringToHash("IsAttack");
    private readonly int hashHit = Animator.StringToHash("hashHit");


    //private readonly int hashPlayerDie = Animator.StringToHash("PlayerDie");
    //private readonly int hashSpeed = Animator.StringToHash("Speed");
    private readonly int hashDie = Animator.StringToHash("Die");

    // 몬스터 생명 초기화
    private int iniHp = 100;
    private int currentHp;

    private GameObject bloodEffect;

    //플레이어스코어
    int Playerscore = 0;

    public Text PlayerScoretext;

    void Awake()
    {
        //agent.enabled = false;
        //agent.enabled = true;

        monsterTransform = GetComponent<Transform>();

        targetTransform = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;

        anim = GetComponent<Animator>();

        bloodEffect = Resources.Load<GameObject>("BloodSprayEffect");
    }
    private void Update()
    {
        //주석
       // if (agent.remainingDistance >= 2.0f)
        //{
            Vector3 dir = agent.desiredVelocity;

          //  Quaternion rot = Quaternion.LookRotation(dir);

            //monsterTransform.rotation = Quaternion.Slerp(monsterTransform.rotation, rot, Time.deltaTime * 10.0f);
       // }
    }
    private void OnEnable()
    {
        currentHp = iniHp;

        state = State.IDLE;

        currentHp = iniHp;
        isDie = false;

        GetComponent<CapsuleCollider>().enabled = true; 
        SphereCollider[] spheres = GetComponentsInChildren<SphereCollider>();
        foreach (SphereCollider sp in spheres)
        {
            sp.enabled = true;
        }
        // 몬스터의 상태를 체크하는 코루틴 함수
        StartCoroutine(CheckMonsterState());

        // 상태에 따라 몬스터의 행동을 수행하는 코루틴 함수
        //StartCoroutine(MonsterAction());
    }

    IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.3f);

            // 몬스터 상태가 DIE 코루틴 종료
            if (state == State.DIE) yield break;
            if (state == State.PLAYERDIE) yield break;

            // 몬스터와 주인공 캐릭터 사이의 거리 측정
            float distance = Vector3.Distance(monsterTransform.position, targetTransform.position);

            if (distance <= attackDist)
            {
                state = State.ATTACK;
            }
            else if (distance <= traceDist)
            {
                state = State.TRACE;
            }
            else
            {
                state = State.IDLE;
            }
        }
    }

    IEnumerator MonsterAction()
    {
        while (!isDie)
        {
            switch (state)
            {
                case State.IDLE:
                    agent.isStopped = true;
                    anim.SetBool(hashTrace, false);
                    break;

                case State.TRACE:
                    agent.SetDestination(targetTransform.position);
                    agent.isStopped = false;
                    anim.SetBool(hashTrace, true);
                    anim.SetBool(hashAttack, false);
                    break;

                case State.ATTACK:
                    anim.SetBool(hashAttack, true);
                   // anim.SetTrigger(hashDie);
                   //Debug.Log("몬스터 공격햇움.");
                    break;

                case State.DIE:

                    Playerscore += 100;
                    PlayerScoretext.text = "Score: " + Playerscore;
                    Debug.Log(Playerscore);

                    isDie = true;
                    agent.isStopped = true;

                    //Score.Playerscore += 100;
                    //PlayerScoretext.text = "Score: " + Playerscore;

                 
                    anim.SetTrigger(hashDie);

                    GetComponent<CapsuleCollider>().enabled = false;
                    //SphereCollider[] spheres = GetComponentsInChildren<SphereCollider>();
                    //foreach (SphereCollider sp in spheres)
                    //{
                    //    sp.enabled = false;
                    //}

                    yield return new WaitForSeconds(1.0f);

                    Destroy(gameObject);

                    //this.gameObject.SetActive(false);
                    break;

                    

                case State.PLAYERDIE:
                    StopAllCoroutines();

                    // 추적 정지
                    agent.isStopped = true;
                  //anim.SetFloat(hashSpeed, Random.Range(0.8f, 1.3f));
                   //anim.SetTrigger(hashPlayerDie);
                    break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == bulletTag)
        {
            //Debug.Log("우악!");
            anim.SetBool(hashHit, true);
            Destroy(coll.gameObject);


            //피격 리액션 애니 트리거
            anim.SetTrigger(hashHit);

            // 충돌 지점
            //Vector3 pos = coll.GetContact(0).point;
             //총알 충돌 지점의 법선 벡터
            //Quaternion rot = Quaternion.LookRotation(-coll.GetContact(0).normal);

           // ShowBloodEffect(pos, rot);

            currentHp -= 25;
            if (currentHp <= 0)
            {
                state = State.DIE;

              //  GameManager.Instance().DisplayScore(50);
            }
        }
    }

    //private void ShowBloodEffect(Vector3 pos, Quaternion rot)
    //{
    //    //혈흔 효과 생성
    //    GameObject blood = Instantiate<GameObject>(bloodEffect, pos, rot, monsterTransform);
    //    Destroy(blood, 1.0f);
    //}

    //void OnPlayerDie()
    //{
    //    state = State.PLAYERDIE;

    //}

    void OnDrawGizmos()
    {
        if (state == State.TRACE)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(monsterTransform.position, traceDist);
        }
        if (state == State.ATTACK)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(monsterTransform.position, attackDist);
        }
    }

    private void FixedUpdate()
    {
      
    }
}
