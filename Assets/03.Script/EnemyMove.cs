using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterCtrl : MonoBehaviour
{
    // ������ ���� ����
    public enum State
    {
        IDLE,
        TRACE,
        ATTACK,
        PLAYERDIE,
        DIE
    }

    // ������ ���� ����
    public State state = State.IDLE;
    // ���� ���� �Ÿ�
    public float traceDist = 10.0f;
    // ���� ���� �Ÿ�
    public float attackDist = 2.0f;
    // ������ ��� ����
    public bool isDie = false;

    private Transform monsterTransform;
    private Transform targetTransform;
    private NavMeshAgent agent;
    //private Animator anim;

    //// Animator �ؽ� �� ����
    //private readonly int hashTrace = Animator.StringToHash("IsTrace");
    //private readonly int hashAttack = Animator.StringToHash("IsAttack");
    //private readonly int hashHit = Animator.StringToHash("Hit");
    //private readonly int hashPlayerDie = Animator.StringToHash("PlayerDie");
    //private readonly int hashSpeed = Animator.StringToHash("Speed");
    //private readonly int hashDie = Animator.StringToHash("Die");

    // ���� ���� �ʱ�ȭ
    private int iniHp = 100;
    private int currentHp;

    private GameObject bloodEffect;
    void Awake()
    {

        monsterTransform = GetComponent<Transform>();

        targetTransform = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;

        //anim = GetComponent<Animator>();

        bloodEffect = Resources.Load<GameObject>("BloodSprayEffect");
    }
    private void Update()
    {
        if (agent.remainingDistance >= 2.0f)
        {
            Vector3 dir = agent.desiredVelocity;

            Quaternion rot = Quaternion.LookRotation(dir);

            monsterTransform.rotation = Quaternion.Slerp(monsterTransform.rotation, rot, Time.deltaTime * 10.0f);
        }
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
        // ������ ���¸� üũ�ϴ� �ڷ�ƾ �Լ�
        StartCoroutine(CheckMonsterState());

        // ���¿� ���� ������ �ൿ�� �����ϴ� �ڷ�ƾ �Լ�
        //StartCoroutine(MonsterAction());
    }

    IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.3f);

            // ���� ���°� DIE �ڷ�ƾ ����
            if (state == State.DIE) yield break;
            if (state == State.PLAYERDIE) yield break;

            // ���Ϳ� ���ΰ� ĳ���� ������ �Ÿ� ����
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

    //IEnumerator MonsterAction()
    //{
    //    while (!isDie)
    //    {
    //        switch (state)
    //        {
    //            case State.IDLE:
    //                agent.isStopped = true;
    //                anim.SetBool(hashTrace, false);
    //                break;
    //            case State.TRACE:
    //                agent.SetDestination(targetTransform.position);
    //                agent.isStopped = false;
    //                anim.SetBool(hashTrace, true);
    //                anim.SetBool(hashAttack, false);
    //                break;
    //            case State.ATTACK:
    //                anim.SetBool(hashAttack, true);
    //                break;
    //            case State.DIE:
    //                isDie = true;
    //                agent.isStopped = true;
    //                anim.SetTrigger(hashDie);

    //                GetComponent<CapsuleCollider>().enabled = false;
    //                SphereCollider[] spheres = GetComponentsInChildren<SphereCollider>();
    //                foreach (SphereCollider sp in spheres)
    //                {
    //                    sp.enabled = false;
    //                }

    //                yield return new WaitForSeconds(3.0f);

    //                this.gameObject.SetActive(false);
    //                break;
    //            case State.PLAYERDIE:
    //                StopAllCoroutines();

    //                // ���� ����
    //                agent.isStopped = true;
    //                anim.SetFloat(hashSpeed, Random.Range(0.8f, 1.3f));
    //                anim.SetTrigger(hashPlayerDie);
    //                break;
    //        }
    //        yield return new WaitForSeconds(0.3f);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BULLET"))
        {
            Destroy(collision.gameObject);

            //�ǰ� ���׼� �ִ� Ʈ����
            //anim.SetTrigger(hashHit);

            // �浹 ����
            Vector3 pos = collision.GetContact(0).point;
            // �Ѿ� �浹 ������ ���� ����
            Quaternion rot = Quaternion.LookRotation(-collision.GetContact(0).normal);

            ShowBloodEffect(pos, rot);

            currentHp -= 10;
            if (currentHp <= 0)
            {
                state = State.DIE;

              //  GameManager.Instance().DisplayScore(50);
            }
        }
    }

    private void ShowBloodEffect(Vector3 pos, Quaternion rot)
    {
        //���� ȿ�� ����
        GameObject blood = Instantiate<GameObject>(bloodEffect, pos, rot, monsterTransform);
        Destroy(blood, 1.0f);
    }

    void OnPlayerDie()
    {
        state = State.PLAYERDIE;

    }

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
}
