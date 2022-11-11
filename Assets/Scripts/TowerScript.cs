using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public GameObject curr_target;
    public GameObject projectile;
    public string DamageType = "Normal";
    public float range = 10f;
    public float fireRate = 5f;
    public float Damage = 5f; 

    public string TargetTag = "Enemy";
    public List<GameObject> enemies;
    
    void Start(){
        gameObject.GetComponent<SphereCollider>().radius = range;
    }

    void Update(){
        gameObject.GetComponent<SphereCollider>().radius = range;
        GetCurrentTarget();
    }


    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }

    private void OnTriggerEnter(Collider other){
        print(other);
        if(other.CompareTag(TargetTag)){
            GameObject enemy = other.gameObject;
            enemies.Add(enemy);
        }
    }
    private void OnTriggerExit(Collider other){
        print(other);
        if(other.CompareTag(TargetTag)){
            GameObject enemy = other.gameObject;
            if(enemies.Contains(enemy))
                enemies.Remove(enemy);
        }
    }

    private void GetCurrentTarget(){
        if(enemies.Count > 0){
            curr_target = enemies[0];
        } else{
            curr_target = null;
        }
    }

    private void FireBullet


}
