using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   public float health = 10f;
   public string type = "Fire";
   public float normalDmgBoost = 1.25f;
   public float elementalDmgBoost = 2f;
   public float elementalResist = 0.5f;

   private Dictionary<string,string> elementalMatchup = new Dictionary<string, string>();

    void Start()
    {
        elementalMatchup.Add("Water","Fire");
        elementalMatchup.Add("Fire","Plant");
        elementalMatchup.Add("Plant","Water");
    }

    void TakeDamage(float damage, string DMGType){
        if(DMGType == "Normal"){
            health -= damage * normalDmgBoost;
        } else{
            if(elementalMatchup.ContainsKey(DMGType)){
                if(elementalMatchup[DMGType] == type){
                    health -= damage * elementalDmgBoost;
                } else if(type == DMGType) {
                    health -= damage * elementalResist;
                } else{
                    health -= damage;
                }
            }
                
        }
        print(health);
    }

    // Update is called once per frame
    void Update()
    {
        if(health<0f){
            Destroy(gameObject);
        }
    }
}
