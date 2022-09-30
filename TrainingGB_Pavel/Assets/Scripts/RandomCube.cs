using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCube : MonoBehaviour {

    public GameObject CubePrefab;
    public GameObject[] CoinPrefab;
    public Vector3 RandomPosMin;
    public Vector3 RandomPosMax;
    public int AmountCube;//количество кубов

    void Start() {
        for (int i = 0; i < AmountCube; i++) {
            CubePrefab.transform.localScale = new Vector3(Random.Range(2f, 10f), 1f, 1f);
            int d = Random.Range(0, CoinPrefab.Length);
            float y = Random.Range(0f, 1f);
            if (y >= 0.51f) {

                Instantiate(CubePrefab, RandomVector(RandomPosMin, RandomPosMax), Quaternion.Euler(0f, 90f, 0f));
                Instantiate(CoinPrefab[d], RandomVector(RandomPosMin + Vector3.right * 2f, RandomPosMax), Quaternion.identity);
            } else {
                Instantiate(CubePrefab, RandomVector(RandomPosMin, RandomPosMax), Quaternion.Euler(0f, 0f, 0f));
                Instantiate(CoinPrefab[d], RandomVector(RandomPosMin + Vector3.right * 2f, RandomPosMax), Quaternion.identity);
            }

        }

    }





    public Vector3 RandomVector(Vector3 randomPosMin, Vector3 randomPosMax) {
        float xPosMax = randomPosMax.x;
        float xPosMin = randomPosMin.x;
        float zPosMax = randomPosMax.z;
        float zPosMin = randomPosMin.z;


        return new Vector3(Random.Range(xPosMin, xPosMax), 0f, Random.Range(zPosMin, zPosMax));
    }
}


