using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFactory : MonoBehaviour {
    private readonly FactoryObjects _factoryObjects = new FactoryObjects();
    [SerializeField] private int amountObject;//������� �������� ����� ��� ������
    [SerializeField] private GameObject prefabs;//������ 
    [SerializeField] private List<Transform> SpawnTransformList = new List<Transform>();//��������� �������� ��� ����� ����������
    [SerializeField] private List<GameObject> _objectListTransform = new List<GameObject>();

    private void Awake() {
        _factoryObjects.StartOptions(transform, SpawnTransformList);
    }
    void Start() {

        _factoryObjects.InstantiateObjects(prefabs, SpawnTransformList, _objectListTransform);

    }


}
