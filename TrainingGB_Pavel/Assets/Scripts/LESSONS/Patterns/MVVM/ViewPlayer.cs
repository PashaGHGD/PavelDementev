using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class ViewPlayer : MonoBehaviour {
    [SerializeField] private Rigidbody rigidbodyPlayer;
    [SerializeField] private float speedMovePlayer;
    [SerializeField] GameObject parentCoin;
    private readonly Walking walking = new Walking();
    float X;
    private void Awake() {

        rigidbodyPlayer = GetComponent<Rigidbody>();
    }
    private void FixedUpdate() {

        walking.Move(rigidbodyPlayer, speedMovePlayer, transform);

    }
    public GameObject InstatiateParentCoin() {
        X -= 0.5f;
        GameObject a = Instantiate(parentCoin, new Vector3(transform.localPosition.x + X, transform.localPosition.y, transform.localPosition.z),Quaternion.Euler(0, transform.localRotation.y, 0));
        a.transform.parent = transform;
        return a;
    }
}
