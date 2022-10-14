using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMVC : MonoBehaviour {


    private int _coin;
    private Action<int> OnCoinChanged; // ������������� ��������


    public void AddCoinListener(Action<int> onCoinChanged) {// ��������� ������� ������ ��� ��������

        OnCoinChanged += onCoinChanged;

    }
    public void RemoveCoinListener(Action<int> onCoinChanged) {//������� ������ �������� � ������

        OnCoinChanged -= onCoinChanged;

    }
    public void OnCoin(int coin) {

        _coin += coin;

        OnCoinChanged?.Invoke(_coin);

    }


    public int Coin() => _coin;



   
}
