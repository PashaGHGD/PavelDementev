using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
  

    public GameObject[] SpawnObj;
    [SerializeField] private float RundomPosA;
    [SerializeField] private float RundomPosB;
    [SerializeField] private float StartSpawn;

    private float a;

  


    void Update() {
        a += Time.deltaTime;
        if (a >= StartSpawn) {
            SpawnOblects();
            a = 0f;
        }
    }

    public void SpawnOblects() {

        for (int i = 0; i < SpawnObj.Length; i++) {

            Instantiate(SpawnObj[i], RundomNamber(RundomPosA, RundomPosB), Quaternion.identity);
        }

    }

    private Vector3 RundomNamber(float RundomPosA, float RundomPosB) {

        float RundomPosX = Random.Range(RundomPosA, RundomPosB);
        float RundomPosZ = Random.Range(RundomPosA, RundomPosB);
        Vector3 Pos = new Vector3(RundomPosX, 0f, RundomPosZ);
        return Pos;
    }






}
