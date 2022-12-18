using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVScene : MonoBehaviour {
    private ViewPlayer playerTransform;
    [SerializeField] GameObject coin;
    private Coin coinClass = new Coin();
    
    private void Start() {
        playerTransform = FindObjectOfType<ViewPlayer>();
        AddCoin();
    }
   
    public void AddCoin() {
        GameObject coinAdd = coinClass.InstatiateCoin(coin, coin.transform);
        CoinPrefab prefab = coinAdd.GetComponent<CoinPrefab>();
        prefab.AddMV(this);
    }
    public void PlayerParent() {
        playerTransform.InstatiateParentCoin();
        AddCoin();
    }
   
}
public class Coin {

    public GameObject InstatiateCoin(GameObject gameObjectCoin, Transform transform) {
        float x = Random.Range(-25f, 25f);
        float z = Random.Range(-25f, 25f);
        GameObject coin = Object.Instantiate(gameObjectCoin, transform.position = new Vector3(x, 0, z), Quaternion.identity);
        return coin;
    }

}