
using UnityEngine;

public class PlayerController {

    private AnimationConfig config;
    private SpriteAnimarionConyrollerPlayer _playerAnimator;
    private LevelObjectView _playerView;

    private float _xAxisInput;
    private bool _isJump;

    private Transform _playerTransform;

    private float _walkSpeed = 3f;
    private float _animationSpeed = 20f;
    private float _movengTreshold = 0.1f;

    private Vector3 _leftScale = new Vector3(-1, 1, 1);
    private Vector3 _rightScale = new Vector3(1, 1, 1);

    private bool _isMoving;

    private float _jumpForce = 9f;
    private float _jumpTreshold = 1f;
    private float _g = -9.8f;//ускорение падения при прыжке
    private float _groundLevel = 0.5f;//остаток позиции по земли
    private float _yVelocity;



    public PlayerController(LevelObjectView player) {

        config = Resources.Load<AnimationConfig>("SpriteAnimationCfg");
        _playerAnimator = new SpriteAnimarionConyrollerPlayer(config);
        _playerAnimator.StartAnimation(player.SpriteRendererView, AnimationState.Run, true, _animationSpeed);
        _playerView = player;
        _playerTransform = player.TransformView;
    }

    private void MoveTowards() {
        _playerTransform.position += Vector3.right * (Time.deltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1));
        _playerTransform.localScale = _xAxisInput < 0 ? _leftScale : _rightScale;
    }

    public bool IsGrounded() {

        return _playerTransform.position.y <= _groundLevel && _yVelocity <= 0;

    }
    public void Update() {
        _playerAnimator.Update();
        _xAxisInput = Input.GetAxis("Horizontal");
        _isJump = Input.GetAxis("Vertical") > 0;
        _isMoving = Mathf.Abs(_xAxisInput) > _movengTreshold;

        if (_isMoving) {

            MoveTowards();

        }
        if (IsGrounded()) {
            _playerAnimator.StartAnimation(_playerView.SpriteRendererView, _isMoving ? AnimationState.Run : AnimationState.Idle, true, _animationSpeed);
            if (_isJump && _yVelocity <= 0) {

                _yVelocity = _jumpForce;
            } else if (_yVelocity < 0) {
                _yVelocity = 0;
                _playerTransform.position = new Vector3(_playerTransform.position.x, _groundLevel, _playerTransform.position.z);
            }
        } else {
            if (Mathf.Abs(_yVelocity) > _jumpTreshold) {

                _playerAnimator.StartAnimation(_playerView.SpriteRendererView, AnimationState.Jump, true, _animationSpeed);
            }

            _yVelocity += _g * Time.deltaTime;
            _playerTransform.position += Vector3.up * (Time.deltaTime * _yVelocity);
        }




    }


}
