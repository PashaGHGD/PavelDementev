using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotStandartFactory : RobotAbstractFactory
{
    private Transform _spawnPoint;
    
    public RobotStandartFactory(Transform spawnPoint) {

        _spawnPoint = spawnPoint;
    }
    public override GameObject CreateEmemyStandart() {
        var _ememyStandartPrefab = Resources.Load<GameObject>("EmemyStandart");
        var _ememyStandart = Object.Instantiate(_ememyStandartPrefab, _spawnPoint.position, Quaternion.identity);
        return _ememyStandart;
    }
    public override GameObject CreateEmemyModernized() {
        var _ememyStandartModernizedPrefab = Resources.Load<GameObject>("EmemyStandartModernized");
        var _ememyStandartModernized = Object.Instantiate(_ememyStandartModernizedPrefab, _spawnPoint.position, Quaternion.identity);
        return _ememyStandartModernized;
    }
}
