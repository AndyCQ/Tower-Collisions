using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    [SerializeField] 
    private GameObject[][] waypoints = new GameObject[2][];

    [SerializeField] float moveSpeed = 2f;

    public int waypointIndex = 0;
    public int path = 0;

    void Start()
    {
        waypoints[0] = GameObject.FindGameObjectsWithTag("Map");
        waypoints[1] = GameObject.FindGameObjectsWithTag("AltPath");
        transform.position = waypoints[path][waypointIndex].transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() {
        transform.position = Vector3.MoveTowards(transform.position, 
        waypoints[path][waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        if ((transform.position - waypoints[path][waypointIndex].transform.position).magnitude < .2f) {
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints[path].Length) {
            Destroy(gameObject);
        }
    }
    public void ChangePath(int p) {
        path = p;
    }


}