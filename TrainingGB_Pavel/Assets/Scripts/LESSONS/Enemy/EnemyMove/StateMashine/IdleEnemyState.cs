using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleEnemyState : EnemyState {
    private readonly EnemyMove _enemyMove;
    /// <summary>
    /// С помощью конструктора подключаем скасс EnemyMove
    /// </summary>
    /// <param name="enemyMove"></param>
    public IdleEnemyState(EnemyMove enemyMove) {
        _enemyMove = enemyMove;
    }
    public override void EnterState() {
        base.EnterState();
        _enemyMove.transform.position = _enemyMove.StartTransform;
    }
    public override void ExitState() {
        base.ExitState();
    }


}
