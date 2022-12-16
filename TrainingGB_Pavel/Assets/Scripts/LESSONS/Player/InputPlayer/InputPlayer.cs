using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputPlayer {


    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";


    public static void PlayerMoveHorizontal(float horizontalSpeed, Rigidbody rigidbodyPlayer) {
        if (Input.GetAxis(_horizontal) != 0) {
            rigidbodyPlayer.velocity = Input.GetAxis(_horizontal) * horizontalSpeed * Vector3.right;
        }
    }
    public static void PlayerMoveVertical(float speedVertical, Rigidbody rigidbodyPlayer) {

        if (Input.GetAxis(_vertical) != 0) {
            rigidbodyPlayer.AddRelativeForce(Input.GetAxis(_vertical) * speedVertical * Vector3.forward, ForceMode.VelocityChange);
        }
    }
    public static void StartRigidbodyConfig(Rigidbody rigidbody) {

        rigidbody = rigidbody.GetComponent<Rigidbody>();

        //  rigidbody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;// отключает все повороты кроме по оси Y

    }

}
