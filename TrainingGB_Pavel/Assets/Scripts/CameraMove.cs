using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public Transform PlayerMove;
    public Rigidbody PlayerRigidbody;
    private List<Vector3> VelositiesList = new List<Vector3>();

    private void Start() {

        for (int i = 0; i < 10; i++) {

            VelositiesList.Add(Vector3.zero);

        }

    }

    private void LateUpdate() {
        Vector3 summ = Vector3.zero;

        for (int i = 0; i < VelositiesList.Count; i++) {
            summ += VelositiesList[i];
        }
        transform.position = PlayerMove.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(summ), Time.deltaTime * 3f);
    }

    private void FixedUpdate() {
        VelositiesList.Add(PlayerRigidbody.velocity);
        VelositiesList.RemoveAt(0);


    }
}
