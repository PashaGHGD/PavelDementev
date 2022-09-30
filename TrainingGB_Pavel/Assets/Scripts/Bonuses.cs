using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bonuses : MonoBehaviour {

    //[SerializeField] private float positiveBonusesSpeed;
    //[SerializeField] private float negativeBonusesSpeed;
    //[SerializeField] private int positiveBonusesCoin;
    //[SerializeField] private int negativeBonusesCoin;
    //[SerializeField] private int positiveHealth;
    private int Amount = 1;//дефолтное значение
    [SerializeField] private protected bool isPositiveBool;
    [SerializeField] private protected bool isNegativeBool;






    public virtual int Hegative() {

        return Amount *= -1;

    }

    public virtual int Positive() {

        return Amount;

    }



}
