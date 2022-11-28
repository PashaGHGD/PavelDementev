using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlayer : Gun
{

    public override void InstantiateBullet() {
        for (int i = 0; i < numberBullets; i++) {
            GameObject newBullet = Instantiate(bulletPrefab, pullBulletTransform.position, Quaternion.identity);
            newBullet.GetComponent<PullBulletPlayer>().StarFind();
            newBullet.GetComponent<BulletDamag>().Damag = bulletDamag;
            newBullet.SetActive(false);
            _bulletList.Add(newBullet);
        }
    }

}
