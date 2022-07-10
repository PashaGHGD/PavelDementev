using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public Rigidbody RigidbodyPlayer;
    [SerializeField] private float SpeedGo;
    [SerializeField] private float SpeedRotation;
    [SerializeField] private float SpeedJump;
    [SerializeField] private bool Grounded;
    private float StartSpeed;
    void Start() {
        StartSpeed = SpeedGo;
    }


    void Update() {
        PlayerGo();
        if (Grounded) {
            if (Input.GetKeyDown(KeyCode.Space)) {

                Jump();

            }

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {

                SpeedGo = StartSpeed * 2f;

            } else {
                SpeedGo = StartSpeed;
            }

        }
    }

    #region(ױמהüבא)
    public void PlayerGo() {
        if (Input.GetAxis("Horizontal") > 0) {

            transform.Translate(SpeedGo * Time.deltaTime, 0, 0);

        } else if (Input.GetAxis("Horizontal") < 0) {

            transform.Translate(SpeedGo * -Time.deltaTime, 0, 0);

        }
        if (Input.GetAxis("Vertical") > 0) {

            transform.Translate(0, 0, SpeedGo * Time.deltaTime);

        } else if (Input.GetAxis("Vertical") < 0) {

            transform.Translate(0, 0, SpeedGo * -Time.deltaTime);

        }

    }
    #endregion

    public void Jump() {

        RigidbodyPlayer.AddRelativeForce(0f, SpeedJump, 0f, ForceMode.VelocityChange);
        //transform.position = new Vector3(transform.position.x,5f*Time.deltaTime*SpeedJump,transform.position.z);
    }

    private void OnCollisionEnter(Collision collision) {
        Grounded = true;
    }

    private void OnCollisionExit(Collision collision) {
        Grounded = false;
    }
}
