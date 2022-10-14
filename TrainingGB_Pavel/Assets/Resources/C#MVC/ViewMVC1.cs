using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewMVC1 : MonoBehaviour {
    [SerializeField] private Text text;
   // [SerializeField] private ModelMVC modelMVC;


    public void Subscribe(ModelMVC modelMVC) {

        modelMVC.AddCoinListener(OnCoinChanged);//�������� ������
        OnCoinChanged(modelMVC.Coin());

    }

    public void Unsubscribe(ModelMVC modelMVC) {// ������� ������
        modelMVC.RemoveCoinListener(OnCoinChanged);

    }
    private void OnCoinChanged(int currentCoin) {

        text.text = "����� �������: " + currentCoin;

    }


}
