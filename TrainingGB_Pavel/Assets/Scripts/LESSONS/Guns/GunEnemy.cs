using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : Gun {

    public override void Start() {
        StartOptions();
        InstantiateBullet();
    }

    public override void Shot() {
        base.Shot();
    }
    public override void InstantiateBullet() {
        for (int i = 0; i < numberBullets; i++) {
            GameObject newBullet = Instantiate(bulletPrefab, pullBulletTransform.position, Quaternion.identity);
            newBullet.GetComponent<PullBulletEnemy>().StarFind();
            newBullet.GetComponent<BulletDamag>().Damag = bulletDamag;
            newBullet.SetActive(false);
            _bulletList.Add(newBullet);
        }
    }
    public override void StartOptions() {
        bulletPrefab = Resources.Load<GameObject>("BulletEnemy");
    }

}
