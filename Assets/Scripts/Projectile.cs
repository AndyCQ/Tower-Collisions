using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject target;
    public string DamageType = "Normal";
    public float Damage = 2f;
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

            target.GetComponent<EnemyHealth>().TakeDamage(Damage,DamageType);
            Destroy(gameObject);
        }

    }

    public void SetEnemy(GameObject enemy){
        target = enemy;
    }

    public void SetBulletStats(GameObject enemy,string dmgType,float dmg){
        target = enemy;
        DamageType = dmgType;
        Damage = dmg;
    }
}
