using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {
   
    [SerializeField] private float SpeedGo;
    [SerializeField] private float SpeedJump;
    [SerializeField] private bool Grounded;
    [SerializeField] private float AngularSpeed = 500f;


    private Rigidbody _rigidbodyPlayer;
    private const string _mouseX = "Mouse X";
    private float _startSpeed;
    private bool _startJump = false;
    private float _timerJump;
    private Vector3 _rotationPlayer;
    public Text TextBullet;

    private void Awake() {
        _rigidbodyPlayer = GetComponent<Rigidbody>();
    }
    void Start() {
        _startSpeed = SpeedGo;
       

    }


    void Update() {
        TextBullet.text = GetComponent<GunObj>().ShowBullet();
        PlayerGo();


        if (Grounded) {
            if (Input.GetKeyDown(KeyCode.Space)) {

                _startJump = true;
                _rigidbodyPlayer.isKinematic = true;
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {

                SpeedGo = _startSpeed * 2f;

            } else {
                SpeedGo = _startSpeed;
            }
        }
        if (_startJump == true) {
            _timerJump += Time.deltaTime;
            if (_timerJump >= 0.5f) {
                _startJump = false;
                _timerJump = 0f;
                _rigidbodyPlayer.isKinematic = false;

            } else {
                Jump();
            }
        }
    }


    #region(ױמהüבא)
    public void PlayerGo() {

        _rotationPlayer.y = Input.GetAxis(_mouseX) * AngularSpeed * Time.deltaTime;
        transform.Rotate(_rotationPlayer);

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
        transform.Translate(0, SpeedJump * Time.deltaTime, 0);

    }

    private void OnCollisionEnter(Collision collision) {
        Grounded = true;
    }

    private void OnCollisionExit(Collision collision) {
        Grounded = false;
    }
}
