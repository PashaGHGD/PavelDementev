using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lesson {
    public class BulletEnemy : BehaviourStart {
        
        [SerializeField] private int damag;
        private void OnTriggerEnter(Collider other) {
            if (other.GetComponent<PlayerHealth>()) {

                other.GetComponent<PlayerHealth>().DamagPlayer(damag);

            }
        }
        
    }
}
