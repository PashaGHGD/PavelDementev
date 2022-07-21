using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] private int BulletDamage;
    [SerializeField] private float SpeedBullet = 3f;
    [SerializeField] private float BulletLiveTime = 5f;
    [SerializeField] private bool isEnemyBullet;
    private void Start() {
        Destroy(gameObject, BulletLiveTime);
    }

    private void Update() {

        transform.Translate(0f, 0f, SpeedBullet * Time.deltaTime);

    }
    public bool EnemyBullet(bool isEnemy) {

        return isEnemyBullet = isEnemy;

    }
    public int Damage(int bulletDamage) {

        return BulletDamage = bulletDamage;
    }

    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.GetComponent<PlayerMove>()) {
            if (isEnemyBullet == true) {
                collision.gameObject.GetComponent<HealseObjects>().DamageObj(BulletDamage);
            }
        }
        if (collision.gameObject.GetComponent<EnemyHealse>()) {
            if (isEnemyBullet == false) {

                collision.gameObject.GetComponent<EnemyHealse>().DamageObj(BulletDamage);
            }

        }
        Destroy(gameObject);
    }

}
