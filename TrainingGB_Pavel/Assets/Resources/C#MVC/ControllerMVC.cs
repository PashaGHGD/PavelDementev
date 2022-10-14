using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class ControllerMVC : MonoBehaviour {

    private const string _vertical = "Vertical";
    private const string _horizontal = "Horizontal";
    private Rigidbody _rigidbodyPlayer;
    private ModelMVC _modelMVC = null;
    [SerializeField] private ViewMVC1 viewMVC1;
    [SerializeField] private float speed;
    [SerializeField] private Transform cameraCenter;



    private void Awake() {
        _rigidbodyPlayer = GetComponent<Rigidbody>();
    }
    //private void FixedUpdate() {
    //    PlauerMove();
    //}

    //public void PlauerMove() {

    //    _rigidbodyPlayer.AddTorque(cameraCenter.right * Input.GetAxis(_vertical) * speed);
    //    _rigidbodyPlayer.AddTorque(-cameraCenter.forward * Input.GetAxis(_horizontal) * speed);

    //}

    private void Update() {

        if (Input.GetMouseButtonDown(0)) {
            if (_modelMVC != null)
                ExitVoid();


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity)) {


                if (hit.collider.TryGetComponent(out ModelMVC modelMVC)) {

                    _modelMVC = modelMVC;
                    viewMVC1.Subscribe(_modelMVC);

                }


            }

        }



    }
    public void ExitVoid() {

        viewMVC1.Unsubscribe(_modelMVC);
        _modelMVC = null;
    }
}
