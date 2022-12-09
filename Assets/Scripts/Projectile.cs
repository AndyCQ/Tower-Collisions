using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject target;
    public TowerController.DamageType DamageType;
    public float Damage = 2f;
    public float moveSpeed = 10f;
    public Material[] mainMat;
    Material dM;


    private void Update()
    {
        if (target != null)
        {
            if (target.tag == "TowerTarget")
            {
                TowerTargetMoveProjectile();
            }
            else if (target.tag == "Shrine")
            {
                ShrineTargetMoveProjectile();
            }
            else
            {
                MoveProjectile();
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void MoveProjectile()
    {
        transform.position = Vector3.MoveTowards(transform.position,
        target.transform.position, moveSpeed * Time.deltaTime);

        if ((transform.position - target.transform.position).magnitude < .2f)
        {
            target.GetComponent<Health>().TakeDamage(Damage, DamageType);
            Destroy(gameObject);
        }
    }
    private void TowerTargetMoveProjectile()
    {
        transform.position = Vector3.MoveTowards(transform.position,
        target.transform.position, moveSpeed * Time.deltaTime);
        if ((transform.position - target.transform.position).magnitude < .2f)
        {
            target.GetComponent<TowerHealth>().TakeDamage(Damage, DamageType);
            Destroy(gameObject);
        }
    }
    private void ShrineTargetMoveProjectile()
    {
        transform.position = Vector3.MoveTowards(transform.position,
        target.transform.position, moveSpeed * Time.deltaTime);
        if ((transform.position - target.transform.position).magnitude < .2f)
        {
            target.GetComponent<ShrineHealth>().TakeDamage(Damage);
            Destroy(gameObject);
        }
    }

    public void SetEnemy(GameObject enemy)
    {
        target = enemy;
    }

    public void SetBulletStats(GameObject enemy, TowerController.DamageType dmgType, float dmg)
    {
        target = enemy;
        DamageType = dmgType;
        Damage = dmg;
        MaterialUpdate();
    }

    void MaterialUpdate()
    {
        switch (DamageType)
        {
            case TowerController.DamageType.Normal:
                dM = mainMat[0];
                break;
            case TowerController.DamageType.Fire:
                dM = mainMat[1];
                break;
            case TowerController.DamageType.Plant:
                dM = mainMat[2];
                break;
            case TowerController.DamageType.Water:
                dM = mainMat[3];
                break;
            default:
                print("COLOR NOT FOUND");
                break;
        };
        gameObject.GetComponent<MeshRenderer>().material = dM;
    }
}
