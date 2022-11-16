using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson {

    [RequireComponent(typeof(Rigidbody))]

    public class PlayerControl : BehaviourStart {



        private const string _horizontal = "Horizontal";
        private const string _vertical = "Vertical";
        [SerializeField] private float PlayerSpeedHorizontal;
        [SerializeField] private float PlayerSpeedVertical;
        [SerializeField] private Rigidbody rigidbodyPlayer;
       
        private void Awake() {
            StartRigidbodyConfig();
            
        }
        private void FixedUpdate() {
            PlayerMoveHorizontal();
            PlayerMoveVertical();

        }

        public void PlayerMoveHorizontal() {
            if (Input.GetAxis(_horizontal) != 0) {
                rigidbodyPlayer.AddRelativeForce(Input.GetAxis(_horizontal) * PlayerSpeedHorizontal * Vector3.right, ForceMode.VelocityChange);
            }

        }

        public void PlayerMoveVertical() {

            if (Input.GetAxis(_vertical) != 0) {
                rigidbodyPlayer.AddRelativeForce(Input.GetAxis(_vertical) * PlayerSpeedVertical * Vector3.forward, ForceMode.VelocityChange);
            }

        }

        public void StartRigidbodyConfig() {

            rigidbodyPlayer = GetComponent<Rigidbody>();

            rigidbodyPlayer.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;


        }

      
    }

}


