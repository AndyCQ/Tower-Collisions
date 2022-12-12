using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrineBuff : MonoBehaviour
{
    private ShrineController controller;
    public List<GameObject> buffs = new List<GameObject>();

    public void Setup(ShrineController c){
        controller = c;
        gameObject.AddComponent<SphereCollider>();
        gameObject.GetComponent<SphereCollider>().radius = controller.range;
        gameObject.GetComponent<SphereCollider>().isTrigger = true;
    }

    void Update(){
        // BuffAll();
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag(controller.TargetTag)){
            GameObject tar = other.gameObject;
            buffs.Add(tar);
            AddBuff(tar);
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.CompareTag(controller.TargetTag)){
            GameObject tar = other.gameObject;
            if(buffs.Contains(tar)){
                buffs.Remove(tar);
                RemoveBuff(tar);
            }
        }
    }

    private void AddBuff(GameObject tar){
        switch (controller.buffType)
        {
            case ShrineController.BuffType.Range: 
                tar.GetComponent<TowerController>().buffrange += controller.BuffAmount;
                break;
            case ShrineController.BuffType.Damage:
                tar.GetComponent<TowerController>().buffDamage += controller.BuffAmount;
                break;
            case ShrineController.BuffType.FireRate:
                tar.GetComponent<TowerController>().bufffireRate += controller.BuffAmount;
                break;
            case ShrineController.BuffType.DeRange: 
                tar.transform.GetChild(0).gameObject.GetComponent<EnemyShoot>().buffrange -= controller.BuffAmount;
                break;
            case ShrineController.BuffType.DeDamage:
                tar.transform.GetChild(0).gameObject.GetComponent<EnemyShoot>().buffDamage -= controller.BuffAmount;
                break;
            case ShrineController.BuffType.DeFireRate:
                tar.transform.GetChild(0).gameObject.GetComponent<EnemyShoot>().bufffireRate -= controller.BuffAmount;
                break;
            default:
                print("COLOR NOT FOUND");
                break;
        };
    }

    private void RemoveBuff(GameObject tar){
        switch (controller.buffType)
        {
            case ShrineController.BuffType.Range: 
                tar.GetComponent<TowerController>().buffrange -= controller.BuffAmount;
                break;
            case ShrineController.BuffType.Damage:
                tar.GetComponent<TowerController>().buffDamage -= controller.BuffAmount;
                break;
            case ShrineController.BuffType.FireRate:
                tar.GetComponent<TowerController>().bufffireRate -= controller.BuffAmount;
                break;
            case ShrineController.BuffType.DeRange: 
                tar.transform.GetChild(0).gameObject.GetComponent<EnemyShoot>().buffrange += controller.BuffAmount;
                break;
            case ShrineController.BuffType.DeDamage:
                tar.transform.GetChild(0).gameObject.GetComponent<EnemyShoot>().buffDamage += controller.BuffAmount;
                break;
            case ShrineController.BuffType.DeFireRate:
                tar.transform.GetChild(0).gameObject.GetComponent<EnemyShoot>().bufffireRate += controller.BuffAmount;
                break;
            default:
                print("COLOR NOT FOUND");
                break;
        };
    }

    public void ReBuffAll(){
        foreach (GameObject tar in buffs) {
            if(tar != null){
                RemoveBuff(tar);
            }
        }
    }
}