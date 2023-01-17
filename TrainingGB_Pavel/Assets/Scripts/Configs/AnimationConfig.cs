using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationState {
    Idle = 0,
    Run = 1,
    Jump = 2
}

[CreateAssetMenu(fileName = "SpriteAnimationCfg", menuName = "Configs / Animation", order = 1)]
public class AnimationConfig : ScriptableObject {
    [Serializable]
    public class SpriteSequence {
        public AnimationState Track;
        public List<Sprite> Sprites = new List<Sprite>();
    }

    public List<SpriteSequence> Sequences = new List<SpriteSequence>();

}
