using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson {

    [RequireComponent(typeof(Rigidbody))]

    public class PlayerControl : BehaviourStart {

        [SerializeField] private float PlayerSpeedHorizontal;
        [SerializeField] private float PlayerSpeedVertical;
        [SerializeField] private Rigidbody rigidbodyPlayer;

        private void Awake() {
         
            rigidbodyPlayer = GetComponent<Rigidbody>();
            InputPlayer.StartRigidbodyConfig(rigidbodyPlayer);

        }
        private void FixedUpdate() {
            InputPlayer.PlayerMoveHorizontal(PlayerSpeedHorizontal, rigidbodyPlayer);
            InputPlayer.PlayerMoveVertical(PlayerSpeedVertical, rigidbodyPlayer);
            
        }

    }

    public static class InputPlayer {


        private const string _horizontal = "Horizontal";
        private const string _vertical = "Vertical";
       
     
        public static void PlayerMoveHorizontal(float horizontalSpeed, Rigidbody rigidbodyPlayer) {
            if (Input.GetAxis(_horizontal) != 0) {
                rigidbodyPlayer.AddRelativeForce(Input.GetAxis(_horizontal) * horizontalSpeed * Vector3.right, ForceMode.VelocityChange);
            }
        }
        public static void PlayerMoveVertical(float speedVertical, Rigidbody rigidbodyPlayer) {

            if (Input.GetAxis(_vertical) != 0) {
                rigidbodyPlayer.AddRelativeForce(Input.GetAxis(_vertical) * speedVertical * Vector3.forward, ForceMode.VelocityChange);
            }
        }
        public static void StartRigidbodyConfig(Rigidbody rigidbody) {

            rigidbody = rigidbody.GetComponent<Rigidbody>();

            rigidbody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
            
        }
     
    }
   
}


