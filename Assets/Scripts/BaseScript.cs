using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BaseScript : MonoBehaviour
{
    public float base_health = 50;
    public float damage = 5f;
    public float currHealth;

    public GameObject healthBarUI;
    public Slider slider;
    void Start()
    {
        currHealth = base_health;
        slider.value = CalculateHealth();
    }

    private void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Enemy")){
            GameObject enemy = other.gameObject;
            currHealth -= damage;
            Destroy(other.gameObject);
        }
    }

    private void Update() {
        if (currHealth <= 0){
            SceneManager.LoadScene("LoseScreen");
        }

        slider.value = CalculateHealth();
    }

    float CalculateHealth(){
        return currHealth / base_health;
    }

}
