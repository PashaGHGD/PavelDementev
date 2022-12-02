using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotShipStandartFactory : RobotAbstractFactory
{
    private Transform _spawnPoint;

    public RobotShipStandartFactory(Transform spawnPoint) {

        _spawnPoint = spawnPoint;
    }
    public override GameObject CreateEmemyStandart() {
        var _ememyShipStandartPrefab = Resources.Load<GameObject>("EmemyShipStandart");
        var _ememyShipStandart = Object.Instantiate(_ememyShipStandartPrefab, _spawnPoint.position, Quaternion.identity);
        return _ememyShipStandart;
    }
    public override GameObject CreateEmemyModernized() {
        var _ememyShipStandartModernizedPrefab = Resources.Load<GameObject>("EmemyShipStandartModernized");
        var _ememyShipStandartModernized = Object.Instantiate(_ememyShipStandartModernizedPrefab, _spawnPoint.position, Quaternion.identity);
        return _ememyShipStandartModernized;
    }
}
