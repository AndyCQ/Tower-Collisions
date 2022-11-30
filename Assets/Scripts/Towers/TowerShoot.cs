using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    private GameObject curr_target;
    public GameObject projectile;
    public TowerController.DamageType DamageType = TowerController.DamageType.Normal;
    public float range = 10f;
    public float fireRate = 1f;
    private float timeToFire = 0f;
    public float Damage = 5f; 
    public Transform firingPosition;
    public string TargetTag = "Enemy";
    public List<GameObject> enemies;
    public int AmmoCount = 100;
    
    void Start(){
        gameObject.GetComponent<SphereCollider>().radius = range;
        timeToFire = fireRate;
    }

    void Update(){
        gameObject.GetComponent<SphereCollider>().radius = range;
        GetCurrentTarget();
        if(timeToFire <= 0f && AmmoCount > 0 && curr_target != null){
            FireBullet();
            timeToFire = fireRate;
            AmmoCount -= 1;
        }
        timeToFire -= Time.deltaTime; 
        

    }
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag(TargetTag)){
            GameObject enemy = other.gameObject;
            enemies.Add(enemy);
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.CompareTag(TargetTag)){
            GameObject enemy = other.gameObject;
            if(enemies.Contains(enemy))
                enemies.Remove(enemy);
        }
    }

    private void GetCurrentTarget(){
        if(enemies.Count > 0){
            while(enemies.Count > 0){
                curr_target = enemies[0];
                if(curr_target == null){
                    enemies.RemoveAt(0);
                    continue;
                }
                break;
            }
            
            
        } else{
            curr_target = null;
        }
    }

    private void FireBullet(){
        if(curr_target != null){
            GameObject bullet = Instantiate(projectile, firingPosition.position, Quaternion.identity).gameObject;
            bullet.GetComponent<Projectile>().SetBulletStats(curr_target,DamageType,Damage);        
        }
    }
}