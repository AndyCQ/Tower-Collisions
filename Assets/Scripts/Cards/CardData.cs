using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "CustomObjects/CardData", order = 0)]
public class CardData : ScriptableObject
{
    public string cardName;
    public Sprite cardArt;
    public GameObject towerPrefab;
    public int mainArrayIndex;

    public GameObject CardButton;

    public float SetupHealth = 10f;
    public float SetupAmmo = 10f;
    public float range = 10f;
    public float fireRate = 1f;
    public float Damage = 5f;
    public TowerController.DamageType damageType = new TowerController.DamageType();
    //Tower in game stats
    public TowerController.Tier tier = new TowerController.Tier();
    public TowerController.Rariety rariety = new TowerController.Rariety();


}
