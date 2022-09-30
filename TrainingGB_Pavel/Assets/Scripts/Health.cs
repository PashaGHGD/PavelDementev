using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Bonuses {








    private void OnTriggerEnter(Collider other) {


        if (other.GetComponent<PlayerMove>()) {

            if (isPositiveBool) {
                other.GetComponent<PlayerMove>().PlayerHealth(Positive());
                Destroy(gameObject);
            } else if (isNegativeBool) {
                other.GetComponent<PlayerMove>().PlayerHealth(Hegative());
                Destroy(gameObject);

            }
        }
    }

}
