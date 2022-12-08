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
    public Dictionary<string, bool> buffed;
    public bool shrine = false;

    public float buff=1;
    
    public void Setup(TowerController c){
        controller = c;
        gameObject.AddComponent<SphereCollider>();
        gameObject.GetComponent<SphereCollider>().radius = controller.range;
        gameObject.GetComponent<SphereCollider>().isTrigger = true;
        timeToFire = controller.fireRate;
        AmmoCount = controller.getMaxAmmo();
    }

    void Update(){
        if(!shrine){
            GetCurrentTarget();
            if(timeToFire <= 0f && AmmoCount > 0 && curr_target != null){
                timeToFire = controller.fireRate;
                AmmoCount -= 1;
                FireBullet();
            }
            timeToFire -= Time.deltaTime; 
        }else{
            for(int i=0;i<enemies.Count;i++){
                if(!buffed[enemies[i].name]){
                    buffed[enemies[i].name]=true;
                    enemies[i].GetComponent<TowerShoot>().buff+=0.2f;
                }
            }
        }
    }
    public void Debuff(){
        for(int i=0;i<enemies.Count;i++){
                if(!buffed[enemies[i].name]){
                    buffed[enemies[i].name]=true;
                    enemies[i].GetComponent<TowerShoot>().buff+=0.2f;
                }
            }
    }
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag(controller.TargetTag)){
            GameObject enemy = other.gameObject;
            enemies.Add(enemy);
            if(shrine){
                buffed.Add(enemy.name,false);
            }
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.CompareTag(controller.TargetTag)){
            GameObject enemy = other.gameObject;
            if(enemies.Contains(enemy)){
                enemies.Remove(enemy);
                if(shrine){
                    buffed.Remove(enemy.name);
                }
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
            bullet.GetComponent<Projectile>().SetBulletStats(curr_target,controller.damageType,controller.Damage*buff);        
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