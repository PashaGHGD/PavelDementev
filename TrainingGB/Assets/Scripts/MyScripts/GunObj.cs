using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunObj : MonoBehaviour {

    public GameObject BulletPrefab;
    public Transform SpawnBullet;


    [SerializeField] private float BulletShotPeriod;
    [SerializeField] private float BulletMax = 100f;
    [SerializeField] private float BulletMin = 0f;
    [SerializeField] private float BulletAmount = 50f;
    [SerializeField] private int BulletDamage;
    [SerializeField] private bool isEnemyBullet;
   
    private float _timer;


    private void Start() {

    }
    private void Update() {
        
        if (Input.GetKey(KeyCode.Mouse0) && isEnemyBullet == false) {

            ShotBullets();
        }
    }
    public string ShowBullet() {

        return  "Количество пуль: " + BulletAmount.ToString();

    }
    public void LootBullet(float bulletAmount) {
        if (BulletMax >= BulletAmount) {
            BulletAmount += bulletAmount;
        }

    }
    public void ShotBullets() {

        _timer += Time.deltaTime;
        if (_timer >= BulletShotPeriod && BulletAmount > BulletMin) {
            BulletAmount--;
            BulletPrefab.GetComponent<Bullet>().EnemyBullet(isEnemyBullet);
            BulletPrefab.GetComponent<Bullet>().Damage(BulletDamage);
            Instantiate(BulletPrefab, SpawnBullet.position, SpawnBullet.rotation);
            _timer = 0f;
        }
    }

}
