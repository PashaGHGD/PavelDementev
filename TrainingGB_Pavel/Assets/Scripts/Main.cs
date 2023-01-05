using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    [SerializeField] private LevelObjectView playerView;
    private PlayerController _playerController;




    private void Awake() {
        _playerController = new PlayerController(playerView);
    }
    void Update() {
        _playerController.Update();
    }
}
