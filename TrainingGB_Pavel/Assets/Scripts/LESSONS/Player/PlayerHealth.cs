using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lesson {
    public class PlayerHealth : BehaviourStart {


        [SerializeField] private int currentHealth;// текущее здоровье
        [SerializeField] private int maxHealth;//  максимальное здоровье
        [SerializeField] private IHealth _health = new Health();

        public virtual int AddHealthPlayer(int health) {

            currentHealth = _health.AddHealth(health, currentHealth, maxHealth);

            return currentHealth;
        }
        public virtual int DamagPlayer(int damag) {

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
}
