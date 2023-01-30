
using UnityEngine;

public class PlayerController {

    private AnimationConfig config;
    private SpriteAnimarionConyrollerPlayer _playerAnimator;
    private LevelObjectView _playerView;
    private ContactPooler _contactPooler;

    private float _xAxisInput;
    private bool _isJump;

    private Transform _playerTransform;
    private Rigidbody2D _rigidbody2;

    private float _walkSpeed = 150f;
    private float _animationSpeed = 20f;
    private float _movengTreshold = 0.1f;

    private int _health = 100;


    private Vector3 _leftScale = new Vector3(-1, 1, 1);
    private Vector3 _rightScale = new Vector3(1, 1, 1);

    private bool _isMoving;

    private float _jumpForce = 9f;
    private float _jumpTreshold = 1f;


    private float _yVelocity = 0;
    private float _xVelosity = 0;


    public PlayerController(InteractiveObjectView player) {

        config = Resources.Load<AnimationConfig>("SpriteAnimationCfg");
        _playerAnimator = new SpriteAnimarionConyrollerPlayer(config);
        _playerAnimator.StartAnimation(player.SpriteRendererView, AnimationState.Run, true, _animationSpeed);
        _playerView = player;
        _playerTransform = player._transform;
        _rigidbody2 = _playerView._rb;
        _contactPooler = new ContactPooler(_playerView.Collider2DView);
        player.TakeDamage += TakeBullet;
    }

    private void MoveTowards() {
        _xVelosity = Time.fixedDeltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1);
        _rigidbody2.velocity = new Vector2(_xVelosity, _yVelocity);
        _playerTransform.localScale = _xAxisInput < 0 ? _leftScale : _rightScale;
    }


    public void Update() {

        if (_health <= 0) {
            _health = 0;
            _playerView.SpriteRendererView.enabled = false;
        }
        _playerAnimator.Update();
        _contactPooler.Update();
        _xAxisInput = Input.GetAxis("Horizontal");
        _isJump = Input.GetAxis("Vertical") > 0;
        _yVelocity = _rigidbody2.velocity.y;
        _isMoving = Mathf.Abs(_xAxisInput) > _movengTreshold;
        _playerAnimator.StartAnimation(_playerView.SpriteRendererView, _isMoving ? AnimationState.Run : AnimationState.Idle, true, _animationSpeed);
        if (_isMoving) {

            MoveTowards();

        } else {

            _xVelosity = 0f;
            _rigidbody2.velocity = new Vector2(_xVelosity, _rigidbody2.velocity.y);
        }
        if (_contactPooler.IsGrounded) {
            _playerAnimator.StartAnimation(_playerView.SpriteRendererView, _isMoving ? AnimationState.Run : AnimationState.Idle, true, _animationSpeed);
            if (_isJump && _yVelocity <= _jumpTreshold) {

                _rigidbody2.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        } else {
            if (Mathf.Abs(_yVelocity) > _jumpTreshold) {

                _playerAnimator.StartAnimation(_playerView.SpriteRendererView, AnimationState.Jump, true, _animationSpeed);
            }


        }




    }

    private void TakeBullet(BulletView bulletView) {

        _health -= bulletView.DamagePoint;
    }
}
