using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

    private Rigidbody _rigidbodyPlayer;
    [SerializeField] private float speed;
    [SerializeField] private Transform cameraCenter;
    [SerializeField] private Text textHealth;
    [SerializeField] private Text textCoin;
    [SerializeField] private int coin;
    [SerializeField] private int health;
    private void Awake() {
        _rigidbodyPlayer = GetComponent<Rigidbody>();
        _rigidbodyPlayer.maxAngularVelocity = 500f;
    }
    private void Start() {
        textCoin.text = "����� �������: " + coin;
        textHealth.text = "������ ��������: " + health;
    }
    private void FixedUpdate() {
        PlauerRun();
    }


    public void PlauerRun() {

        _rigidbodyPlayer.AddTorque(cameraCenter.right * Input.GetAxis("Vertical") * speed);
        _rigidbodyPlayer.AddTorque(-cameraCenter.forward * Input.GetAxis("Horizontal") * speed);

    }

    public void PlayerCoin(int coinVol) {
        coin += coinVol;
        textCoin.text = "����� �������: " + coin;
    }
    public void PlayerHealth(int healthVol) {
        health += healthVol;
        textHealth.text = "������ ��������: " + health;
    }
}
