using System.Collections;
using System.Collections.Generic;
using UnityEngine;



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
          
            
        }

    }

   
   



