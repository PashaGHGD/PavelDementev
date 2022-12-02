using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryObjects {


    /// <summary>
    /// ������� ������� �� ����� ������
    /// </summary>
    /// <param name="amountObject">���������� �������� ������� ��������</param>
    /// <param name="prefab">������</param>
    /// <param name="transformObjest">������� ��� �������� ������ � ����</param>
    /// <param name="objectList">���� ��� ����� ��������� ������� ��� �������������</param>
    public void InstantiateObjects(int amountObject, GameObject prefab, Transform transformObjest, List<GameObject> objectList) {
        for (int i = 0; i < amountObject; i++) {
            GameObject newObjects = Object.Instantiate(prefab, transformObjest.position, Quaternion.identity);
            objectList.Add(newObjects);
        }
    }
    /// <summary>
    /// ��������� ��������� ������� �� ����� ������ �� ��� X
    /// </summary>
    /// <param name="amountObject"></param>
    /// <param name="prefab"></param>
    /// <param name="transformObjestList"></param>
    /// <param name="objectList"></param>
    public void InstantiateObjects(GameObject prefab, List<Transform> transformObjestList, List<GameObject> objectList) {

        for (int i = 0; i < transformObjestList.Count; i++) {
            float x = Random.Range(-10, 10);
            GameObject newObjects = Object.Instantiate(prefab, transformObjestList[i].position + new Vector3(x, 0), Quaternion.identity);
            objectList.Add(newObjects);

        }

    }
    /// <summary>
    /// ��������� ��������� ������� �� ����� ������ �� ��� X ��� ���������� ����� GameObject
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="transformObjestList"></param>
    /// <param name=""></param>
    public void InstantiateObjects(GameObject prefab, List<Transform> transformObjestList) {
        for (int i = 0; i < transformObjestList.Count; i++) {
            float x = Random.Range(-10, 10);
            Object.Instantiate(prefab, transformObjestList[i].position + new Vector3(x, 0), Quaternion.identity);
        }
    }
    /// <summary>
    /// ��������� ��������� ��� ������������� ����� Transform ��������� � Awake
    /// </summary>
    /// <param name="transform">��������� ��������</param>
    /// <param name="spawnTransformList">��������� �������� ��������</param>
    public void StartOptions(Transform transform, List<Transform> spawnTransformList) {
        for (int i = 0; i < transform.childCount; i++) {
            var a = transform.GetChild(i);
            spawnTransformList.Add(a);
        }
    }
   
}
