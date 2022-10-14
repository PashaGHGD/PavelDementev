using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMVC : MonoBehaviour
{
    private int _coinAmount = 1;



    public int CoinAmount => _coinAmount;




    private void OnTriggerEnter(Collider other) {

        if (other.GetComponent<ModelMVC>()) {


          

        }

    }

}
