using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PlayerRB : MonoBehaviour {

    private Rigidbody rigidbodyPlayer;
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string mouseX = "Mouse X";
    private Vector3 rotationPlayer;
    private float jumpY;
    private float startSpeed;
   public bool Grounded;
    [SerializeField] private float angularSpeed = 300f;
    [SerializeField] private float speedMovePlayer = 0.4f;
    [SerializeField] private float speedJump = 5f;


    void Awake() {
        rigidbodyPlayer = GetComponent<Rigidbody>();
        rigidbodyPlayer.interpolation = RigidbodyInterpolation.Interpolate;
      //  startSpeed = speedMovePlayer;
    }
    private void Start() {
        startSpeed = speedMovePlayer;
    }

    private void FixedUpdate() {
        PlayerRotationY();
        if (!Grounded) {
            speedMovePlayer = SpeedMove(speedMovePlayer);
        } else {
            speedMovePlayer = startSpeed;
        }
        if (Input.GetKey(KeyCode.Space) && Grounded) {

            jumpY = 1f;

        } else { jumpY = 0f; }

        PlayerMove();

    }
    private float SpeedMove(float speedMovePlayer) {

     return   speedMovePlayer *= 0.5f;

    }
    public void PlayerMove() {
        rigidbodyPlayer.AddRelativeForce(Input.GetAxis(Horizontal) * speedMovePlayer, jumpY * speedJump, Input.GetAxis(Vertical) * speedMovePlayer, ForceMode.VelocityChange);
    }
    public void PlayerRotationY() {
        rigidbodyPlayer.AddRelativeTorque(angularSpeed * Input.GetAxis(mouseX) * Vector3.up,ForceMode.VelocityChange);
     
    }
    private void OnCollisionEnter(Collision collision) {

        Grounded = true;

    }
    private void OnCollisionStay(Collision collision) {
        Grounded = true;

    }
    private void OnCollisionExit(Collision collision) {

        Grounded = false;
    }

}
