using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimarionConyrollerPlayer : IDisposable {


    private class Animation {
        public AnimationState Track;
        public List<Sprite> Sprites /*= new List<Sprite>()*/;
        public bool Loop;
        public float Speed = 10;
        public float Couter = 0;
        public bool Sleep;

        public void Update() {
            if (Sleep) return;

            Couter += Time.deltaTime * Speed;
            if (Loop) {
                while (Couter > Sprites.Count) {
                    Couter -= Sprites.Count;
                }

            } else if (Couter > Sprites.Count) {
                Couter = Sprites.Count;
                Sleep = true;


            }

        }

    }

    private AnimationConfig _config;
    private Dictionary<SpriteRenderer, Animation> _activeAnimations = new Dictionary<SpriteRenderer, Animation>();


    public SpriteAnimarionConyrollerPlayer(AnimationConfig config) {
        _config = config;
    }

    public void StartAnimation(SpriteRenderer spriteRenderer, AnimationState track, bool loop, float speed) {
        if (_activeAnimations.TryGetValue(spriteRenderer, out var animation)) {

            animation.Loop = loop;
            animation.Speed = speed;
            animation.Sleep = false;
            if (animation.Track != track) {

                animation.Track = track;
                animation.Sprites = _config.Sequences.Find(sequence => sequence.Track == track).Sprites;
                animation.Couter = 0;
            } else {

                _activeAnimations.Add(spriteRenderer, new Animation() {
                    Track = track,
                    Sprites = _config.Sequences.Find(sequence => sequence.Track == track).Sprites,
                    Loop = loop,
                    Speed = speed
                });
            }


        }
    }
    public void StopAnimation(SpriteRenderer sprite) {
        if (_activeAnimations.ContainsKey(sprite)) {
            _activeAnimations.Remove(sprite);
        }

    }
    public void Update() {
        foreach (var animation in _activeAnimations) {
            animation.Value.Update();
            if (animation.Value.Couter < animation.Value.Sprites.Count) {
                animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Couter];
            }
        }
    }
    public void Dispose() {
        _activeAnimations.Clear();
    }
}
