using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMVC : MonoBehaviour {


    private int _coin;
    private Action<int> OnCoinChanged; // Инициализация делегата


    public void AddCoinListener(Action<int> onCoinChanged) {// добавляет функцию метода для делегата

        OnCoinChanged += onCoinChanged;

    }
    public void RemoveCoinListener(Action<int> onCoinChanged) {//удаляет ссылку делегата к методу

        OnCoinChanged -= onCoinChanged;

    }
    public void OnCoin(int coin) {

        _coin += coin;

        OnCoinChanged?.Invoke(_coin);

    }


    public int Coin() => _coin;



   
}
