using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    TouchPlacement TP;
    private void Start() {
        TP = this.GetComponent<TouchPlacement>();
    }
    private void Update() {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began && Time.timeScale > 0f)
            {
                TP.SpawnTowerAtPos(t.position);
            }
        }
        if (Input.GetMouseButtonDown(0) && Time.timeScale > 0f) {
            TP.SpawnTowerAtPos(Input.mousePosition);
        }
    }
}
