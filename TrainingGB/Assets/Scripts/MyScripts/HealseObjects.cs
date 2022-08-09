using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealseObjects : MonoBehaviour {


    [SerializeField] private  int Healse = 1;
    [SerializeField] private int MaxHealse;
    [SerializeField] private int MinHealse = 0;
  //  [SerializeField] private int Damage;
   // [SerializeField] private int Loot;
    public Text TextHealse;

    private void Update() {
        TextHealse.text = "Жизни: " + Healse.ToString();
        //GameOverPlayer();
    }
    public virtual void DamageObj(int damage) {
        if (Healse > MinHealse) {
            if (Healse <= 0) {
                Healse = 0;
            }
            Healse -= damage;
            //TextHealse.text = "Жизни: " + Healse.ToString();
        }

    }
    private void Start() {
        //TextHealse.text = "Жизни: " + Healse.ToString();
    }
    
    public void LootObj(int loot) {

        if (Healse < MaxHealse) {

            Healse += loot;
            //TextHealse.text = "Жизни: " + Healse.ToString();
        }

    }

    public void DestroiObj() {
        if (Healse <= 0) {

            Destroy(gameObject);

        }
    }

    public void GameOverPlayer() {

        if (Healse <= 0) {

            Time.timeScale = 0;

        }

    }















}


