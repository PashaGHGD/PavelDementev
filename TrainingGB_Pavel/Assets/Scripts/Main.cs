using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    [SerializeField] private LevelObjectView PlayerView;
    [SerializeField] private AnimationConfig config;
    [SerializeField] private float animationSpeed;
    private SpriteAnimarionConyrollerPlayer playerAnimator;
   

    private void Awake() {
        config = Resources.Load<AnimationConfig>("SpriteAnimationCfg");
        playerAnimator = new SpriteAnimarionConyrollerPlayer(config);
        playerAnimator.StartAnimation(PlayerView.SpriteRendererView, AnimationState.Run, true, animationSpeed);
    }
    void Update() {
        playerAnimator.Update();
        if (Input.GetMouseButton(0)) {

            playerAnimator.Dispose();

        }
        if (Input.GetMouseButton(1)) {

            playerAnimator.StartAnimation(PlayerView.SpriteRendererView, AnimationState.Idle, true, animationSpeed);

        }
    }
}
