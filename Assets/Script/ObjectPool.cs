using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] [Range(0,50)] private int poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)] private float spawnTimer = 1f;

    private GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(Spawner());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab[0], transform);

            pool[i].SetActive(false);
            
        }
        
    }

    void EnablePoolObjects()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
    IEnumerator Spawner()
    {
        while (true)
        {
            EnablePoolObjects();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
