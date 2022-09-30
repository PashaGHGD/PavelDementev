using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Bonuses {

    public int CoinAmount;


    public override int Positive() {

        return CoinAmount;
    }
    public override int Hegative() {
        return CoinAmount *= -1;
    }
    private void OnTriggerEnter(Collider other) {


        if (other.GetComponent<PlayerMove>()) {

            if (isPositiveBool) {
                other.GetComponent<PlayerMove>().PlayerCoin(Positive());
                Destroy(gameObject);
            } else if (isNegativeBool) {
                other.GetComponent<PlayerMove>().PlayerCoin(Hegative());
                Destroy(gameObject);

            }
        }
    }
}
