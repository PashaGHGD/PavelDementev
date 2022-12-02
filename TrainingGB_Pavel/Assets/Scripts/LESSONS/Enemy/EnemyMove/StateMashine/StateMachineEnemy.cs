using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineEnemy 
{
   public EnemyState CurrentEnemyState { get; set; }
    /// <summary>
    /// Стартовое состояние(самое первое состояние)
    /// </summary>
    /// <param name="startState"></param>
    public void InitializeState(EnemyState startState) {
        CurrentEnemyState = startState;
        CurrentEnemyState.EnterState();
    }
    /// <summary>
    /// Метод для смены состояния
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeState(EnemyState newState) {
        CurrentEnemyState.ExitState();
        CurrentEnemyState = newState;
        CurrentEnemyState.EnterState();

    }

}
