using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private GameObject curr_target;
    public GameObject projectile;
    public TowerController.DamageType DamageType = TowerController.DamageType.Normal;
    public float range = 10f;
    public float fireRate = 1f;
    private float timeToFire = 0f;
    public float Damage = 5f; 

    public float buffrange = 0f;
    public float bufffireRate = 0f;
    public float buffDamage = 0f;

    public Transform firingPosition;
    public string TargetTag = "TowerTarget";
    public string TargetTag2 = "Shrine";
    public List<GameObject> enemies = new List<GameObject>();
    public bool melee = false;

    
     
    void Start(){
        gameObject.GetComponent<SphereCollider>().radius = range;
        timeToFire = fireRate;
    }

    void Update(){
        gameObject.GetComponent<SphereCollider>().radius = range;
        GetCurrentTarget();
        if(timeToFire <= 0f){
            FireBullet();
            timeToFire = fireRate;
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
        if(other.CompareTag(TargetTag2)){
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
        if(other.CompareTag(TargetTag2)){
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
            if(melee){
                curr_target.GetComponent<TowerHealth>().TakeDamage(Damage,DamageType);
            }else{
                GameObject bullet = Instantiate(projectile, firingPosition.position, Quaternion.identity).gameObject;
                bullet.GetComponent<Projectile>().SetBulletStats(curr_target,DamageType,Damage);   
            }     
        }
    }

    public void SetType(string element){
        switch(element){
            case "Normal":
                DamageType = TowerController.DamageType.Normal;
                break;
            case "Fire":
                DamageType = TowerController.DamageType.Fire;
                break;
            case "Plant":
                DamageType = TowerController.DamageType.Plant;
                break;
            case "Water":
                DamageType = TowerController.DamageType.Water;
                break;
            default:
                break;
        }
    }

}
