using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullBulletEnemy : PullBullet {


    public override void Start() {
        base.Start();
        Gun = FindObjectOfType<GunEnemy>();
    }
    public override void StarFind() {
        Gun = FindObjectOfType<GunEnemy>();
    }


}
