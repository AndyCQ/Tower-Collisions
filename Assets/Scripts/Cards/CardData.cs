using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "CardData", menuName = "CustomObjects/CardData", order = 0)]
[Serializable]
public class CardData : ScriptableObject
{
    public enum TowerType { Tower,Shrine};
    public string cardName;
    public Sprite border;
    public Sprite cardArt;
    public string cardDescription;
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

    public TowerType type = new TowerType();
    public ShrineController.BuffType buff = new ShrineController.BuffType();

    public float buffAmo = 0f;
    public String TargetTag;



}
