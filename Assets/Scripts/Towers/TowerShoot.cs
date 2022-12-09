using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    private GameObject curr_target;
    private float timeToFire = 0f;
    private TowerController controller;
    public List<GameObject> enemies = new List<GameObject>();
    private float AmmoCount = 100f;

    public float currrange = 0f;
    public float currfireRate = 0f;
    public float currDamage = 0f;
    
    public void Setup(TowerController c){
        controller = c;
        gameObject.AddComponent<SphereCollider>();
        gameObject.GetComponent<SphereCollider>().radius = controller.range;
        gameObject.GetComponent<SphereCollider>().isTrigger = true;
        timeToFire = controller.fireRate;
        AmmoCount = controller.getMaxAmmo();
    }

    public void ApplyBuffs(){
        currrange = controller.range + controller.buffrange;
        currfireRate = controller.fireRate + controller.bufffireRate;
        currDamage = controller.Damage + controller.buffDamage;
        if(currrange < 3f){
            currrange = 3f;
        }
        if(currfireRate > 5f){
            currfireRate = 5f;
        }
        if(currDamage < 3f){
            currDamage = 3f;
        }
        if(currfireRate < 0f){
            currfireRate = .1f;
        }
        gameObject.GetComponent<SphereCollider>().radius = currrange;
    }



    void Update(){
        ApplyBuffs();
        GetCurrentTarget();
        if(timeToFire <= 0f && AmmoCount > 0 && curr_target != null){
            timeToFire = currfireRate;
            AmmoCount -= 1;
            FireBullet();
        }
        timeToFire -= Time.deltaTime; 

    }
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag(controller.TargetTag)){
            GameObject enemy = other.gameObject;
            enemies.Add(enemy);
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.CompareTag(controller.TargetTag)){
            GameObject enemy = other.gameObject;
            if(enemies.Contains(enemy)){
                enemies.Remove(enemy);
            }
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
            GameObject bullet = Instantiate(controller.projectile, gameObject.transform.position, Quaternion.identity).gameObject;
            bullet.GetComponent<Projectile>().SetBulletStats(curr_target,controller.damageType,currDamage);        
            updateUI();
            FindObjectOfType<MusicManager>().PlaySoundEffects(controller.element);
        }
    }

    public void updateUI(){
		controller.ammoBar.value =  AmmoCount / controller.getMaxAmmo();
	}

    public float getCurrentAmmo(){
        return AmmoCount;
    }
}