using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : BehaviourStart {

    [SerializeField] private int currentHealth;// текущее здоровье
    [SerializeField] private int maxHealth;//  максимальное здоровье
    [SerializeField] private IHealth _health = new Health();
    private EnemyMove _enemyMove;
    private void Start() {
        _enemyMove = GetComponent<EnemyMove>();
    }
    public  int AddHealthEnemy(int health) {
        currentHealth = _health.AddHealth(health, currentHealth, maxHealth);
        return currentHealth;
    }
    public  int DamagEnemy(int damag) {
        currentHealth = _health.Damag(damag, currentHealth);
        DestroyObject();
        return currentHealth;
    }
    public void DestroyObject() {
        if (currentHealth <= 0) {
            _enemyMove.Idle();
        }
    }

}

