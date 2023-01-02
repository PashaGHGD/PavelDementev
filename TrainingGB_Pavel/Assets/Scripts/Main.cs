using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    [SerializeField] private LevelObjectView PlayerView;
    [SerializeField] private AnimationConfig config;
    private SpriteAnimarionConyrollerPlayer playerAnimator;

    private void Awake() {
        config = Resources.Load<AnimationConfig>("SpriteAnimationCfg");
        playerAnimator = new SpriteAnimarionConyrollerPlayer(config);
        playerAnimator.StartAnimation(PlayerView.SpriteRendererView, AnimationState.Run, true, 10f);
    }
    void Update() {
        playerAnimator.Update();
    }
}
