using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour {

    [SerializeField] PlayerMove playerMove;


    void Start()
    {
        playerMove = FindObjectOfType<PlayerMove>();
    }

    private void LateUpdate() {

        // transform.SetPositionAndRotation(playerMove.transform.position, playerMove.transform.rotation);
        transform.position = playerMove.transform.position;
    }
}
