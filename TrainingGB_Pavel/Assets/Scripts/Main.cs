using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    [SerializeField] private InteractiveObjectView playerView;
    [SerializeField] private CannonView _cannonView;
    [SerializeField] private GeneratorLevelView generatorView;

    private PlayerController _playerController;
    private CannonController _cannonController;
    private EmiterController _emiterController;
    private GeneratorController _generatorController;
    private CameraController _cameraController;

    private void Awake() {
        _playerController = new PlayerController(playerView);
        _cannonController = new CannonController(_cannonView._muzzleT, playerView.transform);
        _emiterController = new EmiterController(_cannonView._bullets ,_cannonView._emitterT);
        _cameraController = new CameraController(playerView,Camera.main.transform);
        _generatorController = new GeneratorController(generatorView);
        _generatorController.Start();
    }
    void Update() {
        _playerController.Update();
        _cannonController.Update();
        _emiterController.Update();
      
    }
    private void LateUpdate() {
        _cameraController.Update();
    }
}
