using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    [SerializeField] private LevelObjectView playerView;
    [SerializeField] private CannonView _cannonView;

    private PlayerController _playerController;
    private CannonController _cannonController;



    private void Awake() {
        _playerController = new PlayerController(playerView);
        _cannonController = new CannonController(_cannonView._muzzleT, playerView.transform);
    }
    void Update() {
        _playerController.Update();
        _cannonController.Update();
    }
}
