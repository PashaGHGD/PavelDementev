using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnebleEnemy : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<EnemyMove>()) {
            other.GetComponent<EnemyMove>().Idle();

        }

    }
}
