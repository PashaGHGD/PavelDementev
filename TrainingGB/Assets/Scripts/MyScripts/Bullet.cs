using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {
    [SerializeField] private int BulletDamage;
    [SerializeField] private float SpeedBulletTransform = 3f;
    [SerializeField] private float SpeedBulletRb = 3f;
    [SerializeField] private float BulletLiveTime = 5f;
    [SerializeField] private bool isEnemyBullet;
    [SerializeField] private bool bulletTapeRb;
    [SerializeField] private Rigidbody rigidbodyBullet;


    private void Awake() {
        rigidbodyBullet = GetComponent<Rigidbody>();
        rigidbodyBullet.useGravity = false;
        rigidbodyBullet.mass = 0.001f;
    }
    private void Start() {
        Destroy(gameObject, BulletLiveTime);
    }

    private void Update() {
        if (!bulletTapeRb) {

            transform.Translate(0f, 0f, SpeedBulletTransform * Time.deltaTime);

        }
    }
    private void FixedUpdate() {

        if (bulletTapeRb) {

            rigidbodyBullet.AddRelativeForce(Vector3.forward * SpeedBulletRb, ForceMode.VelocityChange);
        }
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
