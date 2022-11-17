using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPlacement : MonoBehaviour
{
    public GameObject currPrefab;
    [SerializeField]
    Camera mainCam;

    private void Start() {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public bool SpawnTowerAtPos(Vector3 touchPos) {
        if (currPrefab == null) {
            return false;
        }
        Ray ray = mainCam.ScreenPointToRay(touchPos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("TowerSpawn"))) {
            Instantiate(currPrefab, hit.point, Quaternion.identity);
            currPrefab = null;
            return true;
        } else {
            return false;
        }
    }
}
