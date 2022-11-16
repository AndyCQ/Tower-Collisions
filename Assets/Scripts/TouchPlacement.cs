using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPlacement : MonoBehaviour
{
    public GameObject currPrefab;
    [SerializeField]
    Camera mainCam;

    public bool SpawnTowerAtPos(Vector3 touchPos) {
        if (currPrefab == null) {
            return false;
        }
        Ray ray = mainCam.ScreenPointToRay(touchPos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, LayerMask.GetMask("TowerSpawn"))) {
            Instantiate(currPrefab, hit.point, Quaternion.identity);
            return true;
        } else {
            return false;
        }
    }
}
