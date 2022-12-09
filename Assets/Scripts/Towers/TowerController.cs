using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerController : MonoBehaviour
{
    //Dropdown Choices
    public enum DamageType { Normal, Fire, Plant, Water };
    public enum Rariety { N, R, SR, UR };
    public enum Tier { Bronze, Silver, Gold };


    //Tower Customizable Variables
    public float SetupHealth = 10f;
    public float SetupAmmo = 10f;
    public float range = 10f;
    public float fireRate = 1f;
    public float Damage = 5f;
    public DamageType damageType = new DamageType();
    //Tower in game stats
    public Tier tier = new Tier();
    public Rariety rariety = new Rariety();

    //Tower Settings
    public float buffrange = 0f;
    public float bufffireRate = 0f;
    public float buffDamage = 0f;

    public GameObject projectile;
    public GameObject TowerBase;
    public GameObject firingPosition;
    public string TargetTag = "Enemy";

    //Material Change
    public Material baseColors;
    public Material[] damageColor;
    public Material[] tierColor;
    public Material[] rarietyColor;
    Material dM;
    Material tM;
    Material rM;
	//Health/Ammo Variables
	private float maxHealth;
	private float maxAmmo;
   	public Slider healthBar;
	public Slider ammoBar;
	private TowerHealth healthController;
    private TowerShoot shootController;

    //Element type
    public string element;

    // Start is called before the first frame update
    void Start()
    {
		maxHealth = SetupHealth;
		TowerBase.AddComponent<TowerHealth>();
		healthController = TowerBase.GetComponent<TowerHealth>();
		healthController.Setup(this,maxHealth);

		maxAmmo = SetupAmmo;
        firingPosition.AddComponent<TowerShoot>();
        shootController = firingPosition.GetComponent<TowerShoot>();
        shootController.Setup(this);
        healthBar.enabled = false;
        ammoBar.enabled = false;
    }

    public void Setup(float health, float ammo, float _range, float ratefire, float damage, DamageType element, Tier _tier, Rariety _rariety){
        SetupHealth = health;
        SetupAmmo = ammo;
        range = _range;
        fireRate = ratefire;
        Damage = damage;
        damageType = element;
        tier = _tier;
        rariety = _rariety;
        MaterialUpdate();
    }

    void OnValidate()
    {
        MaterialUpdate();
    }
    // Update is called once per frame
    void Update()
    {
        if(healthController.getCurrentHealth()<=0){
            Destroy(gameObject);
            //shootController.Debuff();
        }
    }

	void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(firingPosition.transform.position, range);
    }

    void MaterialUpdate()
    {
        switch (tier)
        {
            case Tier.Bronze:
                tM = tierColor[0];
                break;
            case Tier.Silver:
                tM = tierColor[1];
                break;
            case Tier.Gold:
                tM = tierColor[2];
                break;
            default:
                print("COLOR NOT FOUND");
                break;
        };
        switch (rariety)
        {
            case Rariety.N:
                rM = rarietyColor[0];
                break;
            case Rariety.R:
                rM = rarietyColor[1];
                break;
            case Rariety.SR:
                rM = rarietyColor[2];
                break;
            case Rariety.UR:
                rM = rarietyColor[3];
                break;
            default:
                print("COLOR NOT FOUND");
                break;
        };
        switch (damageType)
        {
            case DamageType.Normal:
                dM = damageColor[0];
                element = "Normal";
                break;
            case DamageType.Fire:
                dM = damageColor[1];
                element = "Fire";
                break;
            case DamageType.Plant:
                dM = damageColor[2];
                element = "Plant";
                break;
            case DamageType.Water:
                dM = damageColor[3];
                element = "Water";
                break;
            default:
                print("COLOR NOT FOUND");
                break;
        };
        Material[] newMats = { baseColors, tM, rM };
        TowerBase.GetComponent<MeshRenderer>().materials = newMats;
        firingPosition.GetComponent<MeshRenderer>().material = dM;
    }

	public float getMaxHealth(){
		return maxHealth;
	}
	
	public float getMaxAmmo(){
		return maxAmmo;
	}
}