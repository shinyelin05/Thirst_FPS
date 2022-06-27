using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  //  public TMP_Text scoreText;

   private int totalScore = 0;

    public GameObject monster;

    public float createTime = 3.0f;

    public List<Transform> points = new List<Transform>();

    public List<GameObject> monsterPool = new List<GameObject>();

    public int maxMonster = 10;

    private bool isGameOver;

    int coinCount = 0;

    public bool IsGameOver
    {
        get => isGameOver;
        set
        {
            isGameOver = value;
            if (IsGameOver == true)
            {
                CancelInvoke("CreateMonster");
            }
        }
    }

    private static GameManager instance;

    public static GameManager Instance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<GameManager>();

            if (instance == null)
            {
                GameObject container = new GameObject("GameManager");
                instance = container.AddComponent<GameManager>();
            }
        }
        return instance;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {

        //DisplayScore(0);

       CreateMonsterPool();

        Transform spawnPointGroup = GameObject.Find("SpawnPointGroup")?.transform;

        spawnPointGroup?.GetComponentsInChildren<Transform>(points);

        Transform[] pointArray = spawnPointGroup.GetComponentsInChildren<Transform>(true);

        foreach (Transform item in spawnPointGroup)
        {
            points.Add(item);
        }

        InvokeRepeating("CreateMonster", 2.0f, createTime);
    }

    private void CreateMonster()
    {
        int idx = Random.Range(0, points.Count);

        GameObject _monster = GetMonsterInPool();

        _monster?.transform.SetPositionAndRotation(points[idx].position, points[idx].rotation);
        _monster?.SetActive(true);


    }


    void CreateMonsterPool()
    {
        for (int i = 0; i < maxMonster; ++i)
        {
            var _monster = Instantiate<GameObject>(monster);

            _monster.name = $"Monster_{i:00}";

            _monster.SetActive(false);

            monsterPool.Add(_monster);
        }
    }

    public GameObject GetMonsterInPool()
    {
        foreach (var _monster in monsterPool)
        {
            if (_monster.activeSelf == false)
            {
                return _monster;

            }
        }
        return null;
    }



}
