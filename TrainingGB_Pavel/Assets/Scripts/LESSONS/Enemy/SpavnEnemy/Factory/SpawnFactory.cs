using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFactory : MonoBehaviour {
    private readonly FactoryObjects _factoryObjects = new FactoryObjects();
    [SerializeField] private int amountObject;//сколько объектов нужно для спавна
    [SerializeField] private GameObject prefabs;//префаб 
    [SerializeField] private List<Transform> SpawnTransformList = new List<Transform>();//трансформ объектов где будут появляться
    [SerializeField] private List<GameObject> _objectListTransform = new List<GameObject>();

    private void Awake() {
        _factoryObjects.StartOptions(transform, SpawnTransformList);
    }
    void Start() {

        _factoryObjects.InstantiateObjects(prefabs, SpawnTransformList, _objectListTransform);

    }


}
