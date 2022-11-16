using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lesson {
    public class PlayerHealth : BehaviourStart {


        [SerializeField] private int currentHealth;
        [SerializeField] private int maxHealth;
        [SerializeField] private IHealth _health = new Health();

        public int AddHealthPlayer(int health) {

            currentHealth = _health.AddHealth(health, currentHealth, maxHealth);

            return currentHealth;
        }
        public int DamagPlayer(int damag) {

            currentHealth = _health.Damag(damag, currentHealth);
            return currentHealth;
        }
    }
}
