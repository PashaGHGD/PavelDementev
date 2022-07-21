using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour {

    [SerializeField] private float LootValyeBullet;
    [SerializeField] private int LootValyeHealse;
    [SerializeField] private bool isBullet;

    private void OnTriggerEnter(Collider other) {

        if (other.GetComponent<PlayerMove>()) {
            if (isBullet == false) {
                other.GetComponent<HealseObjects>().LootObj(LootValyeHealse);
                Destroy(gameObject);
            }
            if (isBullet == true) {
                other.GetComponent<GunObj>().LootBullet(LootValyeBullet);
                Destroy(gameObject);
            }

        }


    }




}
