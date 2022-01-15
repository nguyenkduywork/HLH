using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float waitTime = 1f;
    [SerializeField] private List<Waypoint> path = new List<Waypoint>();
    void Start()
    {
        StartCoroutine(PathFinding());
    }
    
    //IENumerator : countable that the system can use. We use this for coroutines
    IEnumerator PathFinding()
    {
        foreach (Waypoint wp in path)
        {
            //Move enemy along a predefined path
            transform.position = wp.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }

}
