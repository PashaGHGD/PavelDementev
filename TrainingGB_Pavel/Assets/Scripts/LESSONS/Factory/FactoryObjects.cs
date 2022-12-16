using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryObjects {


    /// <summary>
    /// создает объекты от точки спавна
    /// </summary>
    /// <param name="amountObject">количество объектов которые появится</param>
    /// <param name="prefab">префаб</param>
    /// <param name="transformObjest">позиция где появится объект в пулл</param>
    /// <param name="objectList">лист где будут храниться объекты при инициализации</param>
    public void InstantiateObjects(int amountObject, GameObject prefab, Transform transformObjest, List<GameObject> objectList) {
        for (int i = 0; i < amountObject; i++) {
            GameObject newObjects = Object.Instantiate(prefab, transformObjest.position, Quaternion.identity);
            objectList.Add(newObjects);
        }
    }
    /// <summary>
    /// рандомное появление обектов от точек спавна по оси X
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
    /// рандомное появление обектов от точек спавна по оси X без заполнения листа GameObject
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
    /// настройка стартовая для инициализации листа Transform добавлять в Awake
    /// </summary>
    /// <param name="transform">Трансформ родителя</param>
    /// <param name="spawnTransformList">Трансформ Объектов родителя</param>
    public void StartOptions(Transform transform, List<Transform> spawnTransformList) {
        for (int i = 0; i < transform.childCount; i++) {
            var a = transform.GetChild(i);
            spawnTransformList.Add(a);
        }
    }
   
}
