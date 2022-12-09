using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShrineHealth : MonoBehaviour
{
    public ShrineController controller;
    private float currHealth;

    public void Setup(ShrineController c, float health){
        controller = c;
        currHealth = health;
        updateUI();
    }

    void Heal(float amount){
        currHealth += amount;
        updateUI();
    }

    public void TakeDamage(float damage){
        currHealth -= damage * Constants.normalDmgBoost;
        updateUI();
    }

    public void updateUI(){
		controller.healthBar.value =  currHealth / controller.getMaxHealth();
	}

    public float getCurrentHealth(){
        return currHealth;
    }
}
