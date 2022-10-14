using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

    private Rigidbody _rigidbodyPlayer;
    [SerializeField] private float speed;
    [SerializeField] private Transform cameraCenter;
    [SerializeField] private Text textHealth;
    [SerializeField] private Text textCoin;
    [SerializeField] private Text textSpeed;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private int coin;
    [SerializeField] private int health;

    private void Awake() {

        _rigidbodyPlayer = GetComponent<Rigidbody>();
        _rigidbodyPlayer.maxAngularVelocity = 500f;
    }
    private void Start() {
        textCoin.text = "Монет собрали: " + coin;
        textHealth.text = "Жизней осталось: " + health;
        textSpeed.text = "Скорость: " + speed;
    }
    private void FixedUpdate() {
        PlauerRun();

        if (coin >= 1 || health < 0) {
            gameOver.SetActive(true);
            speed = 0f;
        }
    }
    public void ReloadScene() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SkillSpeedUp() {

        speed *= 2f;
        textSpeed.text = "Ускорение Х 2: " + speed;
    }
    public void SkillSpeedDown() {
        speed /= 2f;
        textSpeed.text = "Скорость: " + speed;
    }
    public void PlauerRun() {

        _rigidbodyPlayer.AddTorque(cameraCenter.right * Input.GetAxis("Vertical") * speed);
        _rigidbodyPlayer.AddTorque(-cameraCenter.forward * Input.GetAxis("Horizontal") * speed);
    }
    public void PlayerCoin(int coinVol) {
        coin += coinVol;
        textCoin.text = "Монет собрали: " + coin;
    }
    public void PlayerHealth(int healthVol) {
        health += healthVol;
        textHealth.text = "Жизней осталось: " + health;
    }
}
