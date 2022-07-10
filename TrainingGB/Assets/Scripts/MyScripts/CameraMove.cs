using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform;
    private void Awake() {
        PlayerTransform = FindObjectOfType<PlayerMove>().transform;
    }
    void Start()
    {
       
    }

    private void LateUpdate() {
        transform.SetPositionAndRotation(PlayerTransform.position,PlayerTransform.rotation);
    }
  
}
