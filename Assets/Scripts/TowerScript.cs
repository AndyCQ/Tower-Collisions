using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    protected GameObject curr_target;
    public GameObject projectile;
    public string DamageType = "Normal";
    public float range = 10f;
    public float fireRate = 1000f;
    protected float timeToFire = 0f;
    public float Damage = 5f; 
    public Transform firingPosition;
    public string TargetTag = "Enemy";
    public List<GameObject> enemies;
    
    void Start(){
        gameObject.GetComponent<SphereCollider>().radius = range;
    }

    void Update(){
        gameObject.GetComponent<SphereCollider>().radius = range;
        GetCurrentTarget();
        FireBullet();
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

    private void FireBullet(){
        if(Time.time > timeToFire){
            if(curr_target != null){
                GameObject bullet = Instantiate(projectile, firingPosition.position, Quaternion.identity).gameObject;
                bullet.GetComponent<Projectile>().SetEnemy(curr_target);
                
            }
            timeToFire = Time.time + fireRate;
            print(timeToFire);
            print(Time.time);
            
        }
    }


}
