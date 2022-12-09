using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{ 
    private Path path;
    public Transform goal;

    [SerializeField] float moveSpeed = 2f;

    public int waypointIndex = 0;
    public BaseScript baselvl;

    void Start()
    {
        transform.position = path.waypoints[waypointIndex].transform.position;
        baselvl = GameObject.FindGameObjectWithTag("Base").GetComponent<BaseScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        goal = path.waypoints[waypointIndex].transform;
        if(gameObject.GetComponentInChildren<EnemyShoot>().curr_target == null){
            Move();
        }
        
    }

    void Move() {
        transform.position = Vector3.MoveTowards(transform.position, 
        path.waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        if ((transform.position - path.waypoints[waypointIndex].transform.position).magnitude < .2f) {
            waypointIndex += 1;
        }

        if (waypointIndex == path.waypoints.Length) {
            baselvl.Damage();
            Destroy(gameObject);
        }
    }

    public void ChangePath(Path p){
        path = p;
    }
}