using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking {
    public void Move(Rigidbody rigidbody, float speed, Transform transformPlayer) {
        float velocityY = rigidbody.velocity.y;
        if (Input.GetAxis("Vertical") > 0) {
            transformPlayer.rotation = Quaternion.Euler(0f, -90f, 0f);
        } else if (Input.GetAxis("Vertical") < 0) {

            transformPlayer.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        if (Input.GetAxis("Horizontal") > 0) {

            transformPlayer.rotation = Quaternion.Euler(0f, 0f, 0f);
        } else if (Input.GetAxis("Horizontal") < 0) {

            transformPlayer.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, velocityY, Input.GetAxis("Vertical") * speed);

    }

}
