using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunObj : MonoBehaviour {

    public GameObject BulletPrefab;
    public Transform SpawnBullet;
    public Transform PoinerTransform;
  

    [SerializeField] private float BulletShotPeriod;
    [SerializeField] private float BulletMax = 100f;
    [SerializeField] private float BulletMin = 0f;
    [SerializeField] private float BulletAmount = 50f;
    [SerializeField] private int BulletDamage;
    [SerializeField] private bool isEnemyBullet;
    public bool isPlayerGun;
    private float _timer;
    public float SpeedRotation = 10f;

    private void Start() {

    }
    private void Update() {
        if (isPlayerGun) {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(SpawnBullet.position, SpawnBullet.forward * 100f, Color.red);
            if (Physics.Raycast(ray, out RaycastHit hit)) {
                PoinerTransform.position = hit.point;
            }
            Vector3 Pos = PoinerTransform.position - SpawnBullet.position;
            var RotationLerp = Vector3.RotateTowards(SpawnBullet.forward, Pos, SpeedRotation * Time.deltaTime, 0f);
            //  Quaternion rotation = Quaternion.LookRotation(Pos, Vector3.up);
            SpawnBullet.rotation = Quaternion.LookRotation(RotationLerp);
        }
      


        if (Input.GetKey(KeyCode.Mouse0) && !isEnemyBullet) {

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
