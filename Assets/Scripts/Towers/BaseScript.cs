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
        slider.enabled = false;
    }

    private void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Enemy")){
            GameObject enemy = other.gameObject;
            currHealth -= damage;
            Destroy(other.gameObject);
            FindObjectOfType<MusicManager>().PlaySoundEffects("BaseHit");
        }
    }

    public void Damage(){
        currHealth -= damage;
    }

    private void Update() {
        if (currHealth <= 0){
            GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>().swapToScene("LoseScreen");
        }

        slider.value = CalculateHealth();
    }

    float CalculateHealth(){
        return currHealth / base_health;
    }

}
