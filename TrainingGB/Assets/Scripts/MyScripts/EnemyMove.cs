using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    [SerializeField] private float SpeedGo;
    public Transform PlayerTransform;


    private void Awake() {
        PlayerTransform = FindObjectOfType<PlayerMove>().transform;
    }
    void Start() {

    }


    void Update() {

        EnemyGo();
    }

    public void EnemyGo() {
        float PosPlayer = Vector3.Distance(transform.position, PlayerTransform.position);
        Vector3 Pos = PlayerTransform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(Pos, Vector3.up);
        transform.rotation = rotation;
       
        if (PosPlayer >= 2f) {
            transform.Translate(0f, 0f, SpeedGo * Time.deltaTime);
        }
    }

}
