using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor.Animations;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0f,5f)] float speed = 1f;
    [SerializeField] private List<Waypoint> path = new List<Waypoint>();
    Animator animator;
    EnemyHealth hp;
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        if(GetComponent<Animator>() != null) animator = GetComponent<Animator>();
        hp = GetComponent<EnemyHealth>();
    }

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(PathFollow(0.75f));
    }


    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if (waypoint != null)
            {
                path.Add(waypoint);
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    //IENumerator : countable that the system can use. We use this for coroutines
    IEnumerator PathFollow(float delay)
    {
        if (delay != 0f) yield return new WaitForSeconds(delay);
            foreach (Waypoint wp in path)
            {
                if(hp.currentHP > 0)
                {
                    Vector3 startPos = transform.position;
                    Vector3 endPos = wp.transform.position;

                    float travelPercent = 0f;

                    //rotate game object to face the right direction
                    transform.LookAt(endPos);

                    while (travelPercent < 1f)
                    {
                        travelPercent += Time.deltaTime * speed;
                        transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                        
                        //turn on walk animation
                        if (animator != null) animator.SetBool("Walk Forward", true);
                        if (hp.currentHP > 0)
                        {
                            yield return new WaitForEndOfFrame();
                        }
                        else
                        {
                            turnOnDieAnimation();
                            yield return null;
                        }
                    }
                }
                else
                {
                    turnOnDieAnimation();
                    yield return null;
                }
            }
            finishPath();
    }

    //Destroy enemy game object when it reaches the end, also take player's money
    void finishPath()
    {
        if (transform.position == path[path.Count - 1].transform.position)
        {
            gameObject.SetActive(false);
            enemy.StealGold();
        }
    }
    void turnOnDieAnimation()
    {
        //if (animator != null) animator.SetBool("Walk Forward", false);
        if (animator != null) animator.SetBool("Die", true);
    }

}
