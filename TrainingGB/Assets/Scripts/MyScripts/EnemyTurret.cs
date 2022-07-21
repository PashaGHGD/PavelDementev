using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    [SerializeField] private float SpeedRotation;
    [SerializeField] private GunObj GunObj;
    public Transform PlayerTransform;

    private bool _activationTurret = false;

    private void Awake() {
        PlayerTransform = FindObjectOfType<PlayerMove>().transform;
        GunObj = GetComponent<GunObj>();
    }
   
    void Update() {
        if(_activationTurret == true) {

            TurretRotation();
            GunObj.ShotBullets();
        }
        
    }

    public void TurretRotation() {

      

        // float PosPlayer = Vector3.Distance(transform.position, PlayerTransform.position);
        Vector3 Pos = PlayerTransform.position - transform.position;
        var RotationLerp = Vector3.RotateTowards(transform.forward, Pos, SpeedRotation * Time.deltaTime,0f);
      //  Quaternion rotation = Quaternion.LookRotation(Pos, Vector3.up);
        transform.rotation = Quaternion.LookRotation(RotationLerp);

       
    }

    private void OnTriggerStay(Collider other) {
        if (other.GetComponent<PlayerMove>()) {

            _activationTurret = true;

        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.GetComponent<PlayerMove>()) {

            _activationTurret = false;

        }
    }
}
