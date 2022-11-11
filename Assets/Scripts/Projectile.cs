using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed = 10f;
    //public float Damage = 5f;

    
    private void Update(){
        if(target != null){
            MoveProjectile();
        } else{
            Destroy(gameObject);
        }
    }
    
    private void MoveProjectile(){
        transform.position = Vector3.MoveTowards(transform.position, 
        target.transform.position, moveSpeed * Time.deltaTime);

        if((transform.position - target.transform.position).magnitude < .2f){
            //call enemy damage function
            Destroy(gameObject);
        }

    }

    public void SetEnemy(GameObject enemy){
        target = enemy;
    }
}
