using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EulerDor : MonoBehaviour {
    [SerializeField] private float rotationSpeed = 45;
    private Vector3 currentEulerAngles;
    private float y;
    
    [SerializeField] private int NumberKeyOpenDor;

    void Update() {

        currentEulerAngles += new Vector3(0, y, 0) * Time.deltaTime * rotationSpeed;


        if (currentEulerAngles.y <= 90f) {
            transform.localEulerAngles = currentEulerAngles;
        } else currentEulerAngles.y = 90f;
        if (currentEulerAngles.y <= -0.1f) {

            currentEulerAngles.y = 0f;
        }

    }


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<PlayerMove>()) {
            if (other.GetComponent<InventoryPlayer>()) {

                for (int i = 0; i < other.GetComponent<InventoryPlayer>().KeyNamber.Count; i++) {
                    if(NumberKeyOpenDor == other.GetComponent<InventoryPlayer>().KeyNamber[i]) {

                        y = 1f;

                    }
                }
              
            }

            //y = 1f;

        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.GetComponent<PlayerMove>()) {


            y = -1f;

        }
    }
}
