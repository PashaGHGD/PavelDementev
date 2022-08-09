using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform;
    private void Awake() {
        if(PlayerTransform == null) {

            PlayerTransform = FindObjectOfType<PlayerMove>().transform;
        }
       
    }
   
    private void LateUpdate() {
        transform.SetPositionAndRotation(PlayerTransform.position,PlayerTransform.rotation);
    }
  
}
