using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShrineController : MonoBehaviour
{
    //Dropdown Choices
    public enum BuffType { Range, Damage, FireRate, DeRange, DeDamage, DeFireRate};

    //Tower Customizable Variables
    public float SetupHealth = 10f;
    public float range = 10f;
    public float BuffAmount = 5f;
    public BuffType buffType = new BuffType();
    //Tower in game stats
    public TowerController.Tier tier = new TowerController.Tier();
    public TowerController.Rariety rariety = new TowerController.Rariety();

    //Tower Settings
    public GameObject ShrineBase;
    public GameObject buffPosition;
    public GameObject crystal;
    public string TargetTag = "Enemy";
    //Material Change
    public Material baseColors;
    public Material[] buffColor;
    public Material[] tierColor;
    public Material[] rarietyColor;
    Material dM;
    Material tM;
    Material rM;
	//Health/Ammo Variables
	private float maxHealth;
	public Slider healthBar;
	private ShrineHealth healthController;
    private ShrineBuff buffController;

    // Start is called before the first frame update
    void Start()
    {
		maxHealth = SetupHealth;
		ShrineBase.AddComponent<ShrineHealth>();
		healthController = ShrineBase.GetComponent<ShrineHealth>();
		healthController.Setup(this,maxHealth);

        buffPosition.AddComponent<ShrineBuff>();
        buffController = buffPosition.GetComponent<ShrineBuff>();
        buffController.Setup(this);
        healthBar.enabled = false;
    }

    public void Setup(float health, float _range, float buff, BuffType bufftype, TowerController.Tier _tier, TowerController.Rariety _rariety, string tag){
        SetupHealth = health;
        range = _range;
        BuffAmount = buff;
        buffType = bufftype;
        tier = _tier;
        rariety = _rariety;
        TargetTag = tag;
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
            buffController.ReBuffAll();
            if(gameObject != null){
                Destroy(gameObject);
            }
        }
    }

	void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(buffPosition.transform.position, range);
    }

    void MaterialUpdate()
    {
        switch (tier)
        {
            case TowerController.Tier.Bronze:
                tM = tierColor[0];
                break;
            case TowerController.Tier.Silver:
                tM = tierColor[1];
                break;
            case TowerController.Tier.Gold:
                tM = tierColor[2];
                break;
            default:
                print("COLOR NOT FOUND");
                break;
        };
        switch (rariety)
        {
            case TowerController.Rariety.N:
                rM = rarietyColor[0];
                break;
            case TowerController.Rariety.R:
                rM = rarietyColor[1];
                break;
            case TowerController.Rariety.SR:
                rM = rarietyColor[2];
                break;
            case TowerController.Rariety.UR:
                rM = rarietyColor[3];
                break;
            default:
                print("COLOR NOT FOUND");
                break;
        };
        switch (buffType)
        {
            case BuffType.Range: 
                dM = buffColor[0];
                break;
            case BuffType.Damage:
                dM = buffColor[1];
                break;
            case BuffType.FireRate:
                dM = buffColor[2];
                break;
            case BuffType.DeRange: 
                dM = buffColor[3];
                break;
            case BuffType.DeDamage:
                dM = buffColor[4];
                break;
            case BuffType.DeFireRate:
                dM = buffColor[5];
                break;
            default:
                print("COLOR NOT FOUND");
                break;
        };
        Material[] newMats = { baseColors, tM, rM };
        ShrineBase.GetComponent<MeshRenderer>().materials = newMats;
        crystal.GetComponent<MeshRenderer>().material = dM;
    }

	public float getMaxHealth(){
		return maxHealth;
	}
}