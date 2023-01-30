using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmiterController  {
    private List<BulletController> _bulletControllers = new List<BulletController>();
    private Transform _tr;

    private int _index;
    private float _timerTillNextBull;
    private float _startSpeed = 15f;
    private float _delay = 1;

    public EmiterController(List<BulletView> bulletViews, Transform emitterTr) {

        _tr = emitterTr;
        foreach (BulletView bulletView in bulletViews) {
            _bulletControllers.Add(new BulletController(bulletView));
        }
    }

    public void Update() {
        if (_timerTillNextBull > 0) {

            _bulletControllers[_index].Active(false);
            _timerTillNextBull -= Time.deltaTime;
        } else {

            _timerTillNextBull = _delay;
            _bulletControllers[_index].Trow(_tr.position, -_tr.up * _startSpeed);
            _index++;
            if (_index >= _bulletControllers.Count) {
                _index = 0;
            }
        }
    }
}
