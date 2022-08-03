using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum NumberEnum { 
    Key1,
    Key2,
    Key3



}
public class DoorKey : MonoBehaviour
{

    [SerializeField] private NumberEnum NumberEnum;
  
    public int KeyNumber() {
        int a = ((int)NumberEnum);
        return a;
    }
   
    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<InventoryPlayer>()) {
            other.GetComponent<InventoryPlayer>().AddKeyNamber(KeyNumber());
            Destroy(gameObject);
        }
    }
}
