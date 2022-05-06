using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentwaypoint = 0;

    [SerializeField] private float speed = 2f;
   

    // Update is called once per frame
    private void Update()
    {
       //position >0
        if (Vector2.Distance(waypoints[currentwaypoint].transform.position, transform.position)<0.1f)
         {
           currentwaypoint++;
           if (currentwaypoint >= waypoints.Length)
           {
               currentwaypoint = 0;
           }
        }
         transform.position = Vector2.MoveTowards(transform.position, waypoints[currentwaypoint].transform.position, Time.deltaTime* speed);
    }
}
