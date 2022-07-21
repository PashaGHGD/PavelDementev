using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealse : HealseObjects {





    private void Start() {
        TextHealse = null;
    }


    private void Update() {
        DestroiObj();
    }

    public override void DamageObj(int damage) {
          base.DamageObj(damage);

      
    }
}
