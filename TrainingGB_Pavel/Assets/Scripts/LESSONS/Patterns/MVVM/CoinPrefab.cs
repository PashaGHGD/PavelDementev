using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPrefab : MonoBehaviour {
    [SerializeField] private MVScene mVScene;
    [SerializeField] private bool active = true;
    [SerializeField] private ViewPlayer viewPlayer;
    [SerializeField] private GameObject parentObj;
    public void AddMV(MVScene mV) {
        mVScene = mV;
    }
    private void OnTriggerEnter(Collider other) {
        if (active) {
            if (other.GetComponent<ViewPlayer>()) {
                mVScene.PlayerParent();
                viewPlayer = other.GetComponent<ViewPlayer>();
                parentObj = viewPlayer.InstatiateParentCoin();
                active = false;
            }
        }

    }
    private void LateUpdate() {
        if (!active) {

            transform.position = Vector3.Lerp(transform.position, parentObj.transform.position, Time.deltaTime * 10f);
        }

    }
}
