using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public TowerController.DamageType Type = TowerController.DamageType.Fire;
    private float currHealth = 10f;
    private int tier=1;

    public int drop = 0;
    GameCardManager GCM;



    void Heal(float amount)
    {
        currHealth += amount;
    }

    public void TakeDamage(float damage, TowerController.DamageType type)
    {
        if (type == TowerController.DamageType.Normal)
        {
            currHealth -= damage * Constants.normalDmgBoost;
        }
        else
        {
            if (Constants.elementalMatchup.Contains(type))
            {
                // int index = Constants.elementalMatchup.Find(type);
                int index = 1;
                TowerController.DamageType strong = Constants.elementalMatchup[((index + 1) % 3)];
                TowerController.DamageType weak = Constants.elementalMatchup[((index - 1) % 3)];

                if (Type == strong)
                {
                    currHealth -= damage * Constants.elementalDmgBoost;
                }
                else if (Type == weak)
                {
                    currHealth -= damage * Constants.elementalResist;
                }
                else
                {
                    currHealth -= damage;
                }
            }
            else
            {
                print("Error Damage");
            }

        }
    }


    //Healthbar vars
    public float maxHealth = 10f;
    public GameObject healthBarUI;
    public Slider slider;


    void Start()
    {
        currHealth = maxHealth;
        GCM = GameObject.FindGameObjectWithTag("GameCardManager").GetComponent<GameCardManager>();
        slider.value = CalculateHealth();
    }


    // Update is called once per frame
    void Update()
    {
        if (currHealth <= 0f)
        {
            Destroy(gameObject);
            
        }

        slider.value = CalculateHealth();

    }

    float CalculateHealth()
    {
        return currHealth / maxHealth;
    }

    public void SetType(string element){
        switch(element){
            case "Normal":
                Type = TowerController.DamageType.Normal;
                break;
            case "Fire":
                Type = TowerController.DamageType.Fire;
                break;
            case "Plant":
                Type = TowerController.DamageType.Plant;
                break;
            case "Water":
                Type = TowerController.DamageType.Water;
                break;
            default:
                break;
        }
    }

    public void SetTier(int level){
        currHealth *= level/tier;
        maxHealth *= level/tier;
        drop *= level/tier;
        tier=level;

    }

    public float GetHealth(){
        return currHealth;
    }
    private void OnDestroy() {
        if(currHealth<=0 && gameObject.tag=="Enemy"){
            GCM.earned+=drop;
        }
    }
}
