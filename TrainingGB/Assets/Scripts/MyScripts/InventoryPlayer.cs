using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPlayer : MonoBehaviour
{

    //public List<DoorKey> ListKeys = new List<DoorKey>();
    public List<int> KeyNamber = new List<int>();

    public void AddKeyNamber(int keyNamber) {

        KeyNamber.Add(keyNamber);
    }


    // �� � ��� ����������� ����� �� ���� ����� �������� ���� �� ���� �� ����������, � ����� ��� ����� ��������� ��� �������� �����
    //public List<int> AddKeys(DoorKey doorKey) {
    //    List<int> aKey = new List<int>();
    //    ListKeys.Add(doorKey);

    //    for (int i = 0; i < ListKeys.Count; i++) {

    //        for (int s = 0; s < aKey.Count; s++) {
    //            aKey[s] =  ListKeys[i].KeyNumber();
    //        }
    //    }
    //    Debug.Log(aKey);
    //    return aKey;
    //}
         



}
