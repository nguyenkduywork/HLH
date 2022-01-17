using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0f,5f)] float speed = 1f;
    [SerializeField] private List<Waypoint> path = new List<Waypoint>();
    Animator animator;

    void Start()
    {
    if(GetComponent<Animator>() != null) animator = GetComponent<Animator>();
    StartCoroutine(PathFinding(0.75f));
    }
    
    //IENumerator : countable that the system can use. We use this for coroutines
    IEnumerator PathFinding(float delay)
    {
        if (delay != 0f) yield return new WaitForSeconds(delay);
        foreach (Waypoint wp in path)
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
                if(animator != null) animator.SetBool("Walk Forward", true);
                yield return new WaitForEndOfFrame();
            }
        }
    }

}
