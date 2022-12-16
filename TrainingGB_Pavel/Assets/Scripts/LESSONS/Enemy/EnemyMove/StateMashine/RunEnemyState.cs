using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunEnemyState : EnemyState
{
    private readonly EnemyMove _enemyMove;
    /// <summary>
    /// С помощью конструктора подключаем скасс EnemyMove
    /// </summary>
    /// <param name="enemyMove"></param>
    public RunEnemyState(EnemyMove enemyMove) {
        _enemyMove = enemyMove;
    }


   public Rigidbody RigidbodyEnemy { get; set; }
    public override void EnterState() {
        base.EnterState();
    }
    public override void ExitState() {
        base.ExitState();
    }

    public override void FixedUpdateEnemyState() {
        base.FixedUpdateEnemyState();
        EnemyGo(_enemyMove.Speed(),_enemyMove.RigidbodyEnemy);
        
    }
    public void EnemyGo(float SpeedMove, Rigidbody rigidbodyEnemy) {

        rigidbodyEnemy.velocity = Vector3.forward * -SpeedMove;
    }
}
