using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lesson {
    [RequireComponent(typeof(Rigidbody))]
    public class BulletPlayer : MonoBehaviour {
        [SerializeField] private Gun Gun;
        [SerializeField] private Rigidbody _bulletRigidbody;
        private int _indexBullet = 0;
        [SerializeField] private float _timer;
        private void Awake() {

            _bulletRigidbody = GetComponent<Rigidbody>();
        }
        private void Start() {
            if (Gun == null) {
                Gun = FindObjectOfType<Gun>();
            }
            _indexBullet = Gun.IndexBulletGuns();

        }
        private void Update() {
            DieTimerBullet();
        }
        public void DieTimerBullet() {
            _timer += Time.deltaTime;
            if (_timer >= 3f) {
                _timer = 0f;
                Gun.StartPullBullet(_indexBullet - 1);
            }
        }
        private void OnCollisionEnter(Collision collision) {

            if (collision.collider) {
                _timer = 0f;
                Gun.StartPullBullet(_indexBullet - 1);
            }
        }
        public void StarFind() {
            if (Gun == null) {
                Gun = FindObjectOfType<Gun>();
            }
        }
    }
}
