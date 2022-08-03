using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tolia : MonoBehaviour {
   
        [SerializeField] private float speed = 3f;
        [SerializeField] private float runSpeed = 5f;
        // [SerializeField] private float speedJump = 1f;
        [SerializeField] private float angularSpeed = 100f;

      //  [SerializeField] private GameObject _mine;
       // [SerializeField] private Transform _mineSpawnPlace;
      //  [SerializeField] private int _damageMine;
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        //private const string Running = "Running";
        private const string Jump = "Jump";
        private const string MouseX = "Mouse X";
     //   [SerializeField] private GameObject fonarik;
      //  [SerializeField] private int healthFonarik = 10;

        private Vector3 direction;
        
        private Vector3 rotationDir;

        void Update() {
            direction.x = Input.GetAxis(Horizontal);
            direction.z = Input.GetAxis(Vertical);
            direction.y = Input.GetAxis(Jump);

            

            transform.Translate(runSpeed * Time.deltaTime *  direction);
            transform.Rotate(rotationDir);

            rotationDir.y = Input.GetAxis(MouseX) * angularSpeed * Time.deltaTime;

            //if (Input.GetKey(KeyCode.Mouse0)) {
            //    fonarik.SetActive(true);
            //    healthFonarik -= 1;

            //} else {
            //    fonarik.SetActive(false);

            //}

            //if (Input.GetKey(KeyCode.Mouse1)) {
            //    Instantiate(_mine, _mineSpawnPlace.position, _mineSpawnPlace.rotation);
            //}
        }
    }
