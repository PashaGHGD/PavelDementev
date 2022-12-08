using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ViewService : MonoBehaviour {
    [SerializeField] private Transform _spawnPoint1;
    [SerializeField] private Transform _spawnPoint2;
    private RobotAbstractFactory _factory;


    private void Awake() {
        ServiceLocator.SetService<IService>(new RobotShipStandartFactory(transform));
    }
    private void Start() {
        EnemyData enemyData = new EnemyData();
        enemyData.CreateEmemyStandart(_spawnPoint1);


        EnemyData newenemyData = enemyData.DeepCopy();
        newenemyData.CreateEmemyStandart(_spawnPoint2);


    }


    private void Update() {

        if (Input.GetMouseButtonDown(1)) {
            ServiceLocator.Resolve<IService>().CreateEmemy();

        }
    }
   
}


[Serializable]
internal sealed class EnemyData {

   
    public  GameObject CreateEmemyStandart(Transform spawnPoint) {
        var _ememyShipStandartPrefab = Resources.Load<GameObject>("EmemyShipStandart");
        var _ememyShipStandart = UnityEngine.Object.Instantiate(_ememyShipStandartPrefab, spawnPoint.position, Quaternion.identity);
        return _ememyShipStandart;
    }
}

