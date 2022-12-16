using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PullBullet : MonoBehaviour {

    [SerializeField] protected Gun Gun;
    [SerializeField] private float lifeTimeBullet = 3f;
    protected int _indexBullet = 0;
    private float _timer;

    public virtual void Start() {

      
        _indexBullet = Gun.IndexBulletGuns();

    }
    private void Update() {
        DieTimerBullet();
    }
    public void DieTimerBullet() {
        _timer += Time.deltaTime;
        if (_timer >= lifeTimeBullet) {
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
    public virtual void StarFind() {

      

    }
}

