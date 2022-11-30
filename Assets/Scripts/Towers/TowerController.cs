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

    // Start is called before the first frame update
    void Start()
    {
		maxHealth = SetupHealth;
		TowerBase.AddComponent<TowerHealth>();
		healthController = TowerBase.GetComponent<TowerHealth>();
		healthController.Setup(this,maxHealth);

		firingPosition.AddComponent<TowerShoot>();




    }

    void OnValidate()
    {
        MaterialUpdate();
    }
    // Update is called once per frame
    void Update()
    {

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
                break;
            case DamageType.Fire:
                dM = damageColor[1];
                break;
            case DamageType.Plant:
                dM = damageColor[2];
                break;
            case DamageType.Water:
                dM = damageColor[3];
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