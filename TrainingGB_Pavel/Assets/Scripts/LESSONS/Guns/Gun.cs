using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : BehaviourStart {

    [SerializeField] private float shotPeriodTime;// время между выстрелами
    [SerializeField] private float gunReloadingTime;// перезарядка пушки
    [SerializeField] protected int numberBullets;// количество пуль в магазине
    [SerializeField] private float bulletSpeed = 2f;// скорость пули
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected int bulletDamag;
    [SerializeField] private Transform spawnBulletTransform;
    [SerializeField] protected Transform pullBulletTransform;
    protected List<GameObject> _bulletList = new List<GameObject>();
    private float _timershotPeriod;
    private float _timerGunReloading;
    private bool _boolGunReloading = false;
    private int _indexBullet = 0;


    private void Start() {
        InstantiateBullet();
    }
    private void Update() {
        _timershotPeriod += Time.deltaTime;
        if (_boolGunReloading == false) {
            Shot();
        } else {
            _timerGunReloading += Time.deltaTime;
            if (_timerGunReloading >= gunReloadingTime && _boolGunReloading == true) {
                _boolGunReloading = false;
                _timerGunReloading = 0f;
            }
        }
    }
    public void Shot() {


        if (Input.GetMouseButton(0)) {

            if (numberBullets > 0 && _timershotPeriod >= shotPeriodTime) {
                if (_indexBullet > (numberBullets - 1)) {
                    _indexBullet = 0;
                    _boolGunReloading = true;
                }
                _bulletList[_indexBullet].transform.SetPositionAndRotation(new Vector3(spawnBulletTransform.position.x, spawnBulletTransform.position.y, spawnBulletTransform.position.z), spawnBulletTransform.rotation);
                _bulletList[_indexBullet].SetActive(true);

                _bulletList[_indexBullet].GetComponent<Rigidbody>().velocity = spawnBulletTransform.forward * bulletSpeed;
                _indexBullet++;
                _timershotPeriod = 0f;

            }
        }
    }
    public int IndexBulletGuns() {
        return _indexBullet;
    }
    public void StartPullBullet(int indexBullet) {
        _bulletList[indexBullet].transform.position = new Vector3(pullBulletTransform.position.x, pullBulletTransform.position.y, pullBulletTransform.position.z);
        _bulletList[indexBullet].SetActive(false);
    }
    public virtual void InstantiateBullet() {
        for (int i = 0; i < numberBullets; i++) {
            GameObject newBullet = Instantiate(bulletPrefab, pullBulletTransform.position, Quaternion.identity);
            newBullet.GetComponent<PullBullet>().StarFind();
            newBullet.GetComponent<BulletDamag>().Damag = bulletDamag;
            newBullet.SetActive(false);
            _bulletList.Add(newBullet);
        }
    }
}
public class InitializationObjectsPullBullet {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="amountObject">количество объектов которые появится</param>
    /// <param name="prefab">префаб</param>
    /// <param name="transformObjest">позиция где появится объект в пулл</param>
    /// <param name="objectList">лист где будут храниться объекты при инициализации</param>
    public void InstantiateObjects(int amountObject, GameObject prefab, Transform transformObjest, List<GameObject> objectList) {
        for (int i = 0; i < amountObject; i++) {
            GameObject newBullet = Object.Instantiate(prefab, transformObjest.position, Quaternion.identity);
            newBullet.GetComponent<PullBullet>().StarFind();
            newBullet.SetActive(false);
            objectList.Add(newBullet);

        }
    }
}



