using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lesson {
    public class BulletEnemy : BehaviourStart {

        [SerializeField] private bool isEnemyBullet;
        [SerializeField] private bool isPlayerBullet;
        [SerializeField] private int damag;
        private void OnTriggerEnter(Collider other) {
            if (isEnemyBullet) {

                if (other.GetComponent<PlayerHealth>()) {

                    other.GetComponent<PlayerHealth>().DamagPlayer(damag);

                }
            } else {
                if (isPlayerBullet) {
                    if (other.GetComponent<EnemyHealth>()) {

                        other.GetComponent<EnemyHealth>().DamagPlayer(damag);

                    }

                }
            }

        }

    }
}
