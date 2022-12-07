using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{ 
    private Path path;

    [SerializeField] float moveSpeed = 2f;

    public int waypointIndex = 0;

    void Start()
    {
        transform.position = path.waypoints[waypointIndex].transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() {
        transform.position = Vector3.MoveTowards(transform.position, 
        path.waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        if ((transform.position - path.waypoints[waypointIndex].transform.position).magnitude < .2f) {
            waypointIndex += 1;
        }

        if (waypointIndex == path.waypoints.Length) {
            Destroy(gameObject);
        }
    }

    public void ChangePath(Path p){
        path = p;
    }
}