using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPlacement : MonoBehaviour
{
    public GameObject currPrefab;
    [SerializeField]
    Camera mainCam;

    public bool SpawnPrefabAtPos(Vector3 touchPos) {
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
