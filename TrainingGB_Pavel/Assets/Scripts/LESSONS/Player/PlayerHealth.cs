using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PlayerHealth : BehaviourStart {


        [SerializeField] private int currentHealth;// текущее здоровье
        [SerializeField] private int maxHealth;//  максимальное здоровье
        [SerializeField] private IHealth _health = new Health();

        public  int AddHealthPlayer(int health) {

            currentHealth = _health.AddHealth(health, currentHealth, maxHealth);
        
            return currentHealth;
        }
        public  int DamagPlayer(int damag) {

            currentHealth = _health.Damag(damag, currentHealth);
            DestroyObject();
            return currentHealth;
        }
        public void DestroyObject() {

            if (currentHealth <= 0) {
                Destroy(gameObject);

            }
        }
    }

