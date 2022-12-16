using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientFactory : MonoBehaviour {
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    [SerializeField] private float createTime;
    private RobotAbstractFactory _factory;
    private float timer;
    private void Update() {
        timer += Time.deltaTime;
        if (timer > createTime) {
            CreateStandartEmemy();
            CreateStandartShipEmemyModernized();
            timer = 0f;
        } else {
            //if(timer> (createTime / 2)) {
            //    CreateStandartEmemyModernized();
            //    CreateStandartShipEmemy();
            //}
        }
    }
        public void CreateStandartEmemy() {
            _factory = new RobotStandartFactory(_point1);
            _factory.CreateEmemyStandart();
        }

        public void CreateStandartEmemyModernized() {
            _factory = new RobotStandartFactory(_point1);
            _factory.CreateEmemyModernized();
        }

        public void CreateStandartShipEmemy() {
            _factory = new RobotShipStandartFactory(_point2);
            _factory.CreateEmemyStandart();
        }

        public void CreateStandartShipEmemyModernized() {
            _factory = new RobotShipStandartFactory(_point2);
            _factory.CreateEmemyModernized();
        }
    }
