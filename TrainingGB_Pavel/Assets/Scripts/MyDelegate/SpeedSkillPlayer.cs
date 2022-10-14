using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(Rigidbody))]
public class SpeedSkillPlayer : MonoBehaviour {

    private SkillDelegate _speedDown;
    private SkillDelegate _speedUp;
    private PlayerMove _playerMove;
    public bool SpeedDown;
    public bool SpeedUp;

    private void Start() {
        _playerMove = FindObjectOfType<PlayerMove>();
        try {
            if (SpeedDown == false && SpeedUp == false) {
                throw new MyExcertio();
            }
        } catch (System.Exception e) {

            Debug.Log("выстави галочку SpeedDown или SpeedUp: " + e);
        }
       
            _speedDown += _playerMove.SkillSpeedDown;
            _speedDown += TransformSlale;
            _speedUp += _playerMove.SkillSpeedUp;
            _speedUp += TransformSlale;
       
    }
    public void TransformSlale() {

        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    private void OnTriggerEnter(Collider other) {

        if (other.GetComponent<PlayerMove>()) {

            if (SpeedDown) {
                _speedDown?.Invoke();

            } else {

                _speedUp?.Invoke();
            }
            RemoveDelegate();
            Destroy(gameObject, 2f);

        }
    }
    public void RemoveDelegate() {
        if (SpeedDown) {
            _speedDown -= _playerMove.SkillSpeedDown;
            _speedDown -= TransformSlale;

        } else {

            _speedUp -= _playerMove.SkillSpeedUp;
            _speedUp -= TransformSlale;
        }


    }

}


public class MyExcertio : Exception {

  //  bool Val { get; }
    public MyExcertio(/*string message, bool val*/) /*: base(message)*/ {

        //Val = val;

    }

}
