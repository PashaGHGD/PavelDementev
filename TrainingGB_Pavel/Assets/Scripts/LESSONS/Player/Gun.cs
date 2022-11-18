using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lesson {
    public class Gun : MonoBehaviour
{
    
        [SerializeField] private float shotPeriodTime;// время между выстрелами
        [SerializeField] private float gunReloadingTime;// перезарядка пушки
        [SerializeField] private int numberBullets;// количество пуль в магазине
        [SerializeField] private List<GameObject> bulletList = new List<GameObject>();
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] private Transform spawnBulletTransform;
        [SerializeField] private Transform pullBulletTransform;
        [SerializeField] private float bulletSpeed = 2f;
        private float _timershotPeriod;
        private float _timerGunReloading;
        private bool _boolGunReloading = false;
        private int _indexBullet = 0;
        [SerializeField] private PlayerControl player;
        private void Awake() {

            player = GetComponentInParent<PlayerControl>();

        }

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
        virtual public void Shot() {


            if (Input.GetMouseButton(0)) {

                if (numberBullets > 0 && _timershotPeriod >= shotPeriodTime) {
                    if (_indexBullet > (numberBullets - 1)) {
                        _indexBullet = 0;
                        _boolGunReloading = true;
                    }
                    bulletList[_indexBullet].transform.SetPositionAndRotation(new Vector3(spawnBulletTransform.position.x, spawnBulletTransform.position.y,spawnBulletTransform.position.z), spawnBulletTransform.rotation);
                    bulletList[_indexBullet].SetActive(true);
                    if (transform.localScale.x > 0f && player.transform.localScale.x > 0f) {
                        bulletList[_indexBullet].GetComponent<Rigidbody>().velocity = spawnBulletTransform.right * bulletSpeed;
                        _indexBullet++;
                        _timershotPeriod = 0f;
                        return;
                    } else {


                        bulletList[_indexBullet].GetComponent<Rigidbody>().velocity = -spawnBulletTransform.right * bulletSpeed;
                        _indexBullet++;
                        _timershotPeriod = 0f;
                        return;


                    }
                }
            }
        }
        public int IndexBulletGuns() {
            return _indexBullet;
        }
        public void StartPullBullet(int a) {
            bulletList[a].transform.position = new Vector3(pullBulletTransform.position.x, pullBulletTransform.position.y, pullBulletTransform.position.z);
            bulletList[a].SetActive(false);
        }
        public void InstantiateBullet() {
            for (int i = 0; i < numberBullets; i++) {
                GameObject newBullet = Instantiate(bulletPrefab, pullBulletTransform.position, Quaternion.identity);
                newBullet.GetComponent<BulletPlayer>().StarFind();
                newBullet.SetActive(false);
                bulletList.Add(newBullet);
            }
        }
    }
}
