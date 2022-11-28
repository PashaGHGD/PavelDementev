using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullBulletPlayer : PullBullet
{


    public override void Start() {
        base.Start();
        Gun = FindObjectOfType<GunPlayer>();
    }
    public override void StarFind() {
        Gun = FindObjectOfType<GunPlayer>();
    }
}
