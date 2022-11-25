using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamag : BehaviourStart {

    [SerializeField] private bool isEnemyBullet;
    [SerializeField] private bool isPlayerBullet;
    public int Damag { get; set; }
    private void OnTriggerEnter(Collider other) {
        if (isEnemyBullet) {

            if (other.GetComponent<PlayerHealth>()) {

                other.GetComponent<PlayerHealth>().DamagPlayer(Damag);

            }
        } else {
            if (isPlayerBullet) {
                if (other.GetComponent<EnemyHealth>()) {

                    other.GetComponent<EnemyHealth>().DamagEnemy(Damag);

                }

            }
        }

    }

}

