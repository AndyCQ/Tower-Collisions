using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerHealth : MonoBehaviour
{
    public TowerController controller;
    private float currHealth;

    public void Setup(TowerController c, float health){
        controller = c;
        currHealth = health;
        updateUI();
    }

    void Heal(float amount){
        currHealth += amount;
        updateUI();
    }

    public void TakeDamage(float damage, TowerController.DamageType type){
        if(type == TowerController.DamageType.Normal){
            currHealth -= damage * Constants.normalDmgBoost;
        } else{
            if(Constants.elementalMatchup.Contains(type)){
                // int index = Constants.elementalMatchup.Find(type);
                int index = 1;
                TowerController.DamageType strong = Constants.elementalMatchup[((index+1)%3)];
                TowerController.DamageType weak = Constants.elementalMatchup[((index- 1)%3)];
                
                if(controller.damageType == strong){
                    currHealth -= damage * Constants.elementalDmgBoost;
                } else if(controller.damageType == weak) {
                    currHealth -= damage * Constants.elementalResist;
                } else{
                    currHealth -= damage;
                }
            } else{
                print("Error Damage");
            }
        }
        updateUI();
    }

    public void updateUI(){
		controller.healthBar.value =  currHealth / controller.getMaxHealth();
	}

    public float getCurrentHealth(){
        return currHealth;
    }
}
