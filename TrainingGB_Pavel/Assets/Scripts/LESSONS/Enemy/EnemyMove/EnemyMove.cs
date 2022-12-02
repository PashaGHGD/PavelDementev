using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class EnemyMove : MonoBehaviour {
    [SerializeField] private float SpeedMove;
    public Rigidbody RigidbodyEnemy { get; set; }
    private StateMachineEnemy _stateMachine;
    public Vector3 StartTransform;
    private void Awake() {
        RigidbodyEnemy = GetComponent<Rigidbody>();
    }
    private void Start() {
        _stateMachine = new StateMachineEnemy();
        _stateMachine.InitializeState(new RunEnemyState(this));
        StartTransform = transform.position;
    }

    private void FixedUpdate() {
        _stateMachine.CurrentEnemyState.FixedUpdateEnemyState();
       
    }
    public float Speed() => SpeedMove;
    public void Idle() {
        _stateMachine.ChangeState(new IdleEnemyState(this));
        _stateMachine.ChangeState(new RunEnemyState(this));
    }

}
