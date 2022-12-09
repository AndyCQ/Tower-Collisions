using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisuals : MonoBehaviour
{
    public GameObject Mesh;
    public Transform toRotate;
    public TowerController.DamageType damageType;
    public Material[] damageColor;
    Material dM;
    public float speed = 10f;
    public Transform target;
    
    // Start is called before the first frame update
    public void Setup(TowerController.DamageType dt)
    {
        damageType = dt;
        MaterialUpdate();
    }

    // Update is called once per frame
    void Update() 
    {
        target = gameObject.GetComponent<EnemyMove>().goal;
        if(target != null){
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = lookRotation.eulerAngles;
            toRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);
        } 
    }

    void OnValidate()
    {
        MaterialUpdate();
    }
    void MaterialUpdate()
    {
        switch (damageType)
        {
            case TowerController.DamageType.Normal:
                dM = damageColor[0];
                break;
            case TowerController.DamageType.Fire:
                dM = damageColor[1];
                break;
            case TowerController.DamageType.Plant:
                dM = damageColor[2];
                break;
            case TowerController.DamageType.Water:
                dM = damageColor[3];
                break;
            default:
                print("COLOR NOT FOUND");
                break;
        };
        if(Mesh.CompareTag("Skeleton")){
            Material[] list = Mesh.GetComponent<SkinnedMeshRenderer>().sharedMaterials; 
            list[2] = dM;
            Mesh.GetComponent<SkinnedMeshRenderer>().sharedMaterials = list;
            
        } else{
            
            Material[] list = Mesh.GetComponent<SkinnedMeshRenderer>().sharedMaterials; 
            list[0] = dM;
            Mesh.GetComponent<SkinnedMeshRenderer>().sharedMaterials = list;
        }
        
    }
}
