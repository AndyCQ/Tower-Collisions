using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    [SerializeField] GameObject[] waypoints;

    [SerializeField] float moveSpeed = 2f;

    public int waypointIndex = 0;

    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Map");
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() {
        transform.position = Vector3.MoveTowards(transform.position, 
        waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        if ((transform.position - waypoints[waypointIndex].transform.position).magnitude < .2f) {
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints.Length) {
            Destroy(gameObject);
        }
    }
}