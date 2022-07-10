using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
    public GameObject GameObjectEnemy;
    [SerializeField] private float RundomPosA;
    [SerializeField] private float RundomPosB;
    [SerializeField] private float StartSpawn;

    private float a;

    void Start() {

    }


    void Update() {
        a += Time.deltaTime;
        if (a >= StartSpawn) {

            Instantiate(GameObjectEnemy, RundomNamber(RundomPosA, RundomPosB), Quaternion.identity);
            a = 0f;
        }
    }


    private Vector3 RundomNamber(float RundomPosA, float RundomPosB) {

        float RundomPosX = Random.Range(RundomPosA, RundomPosB);
        float RundomPosZ = Random.Range(RundomPosA, RundomPosB);
        Vector3 Pos = new Vector3(RundomPosX, 0f, RundomPosZ);
        return Pos;
    }






}
