using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class Health : IHealth {

       /// <summary>
       /// 
       /// </summary>
       /// <param name="damage">приходящий дамаг</param>
       /// <param name="currentHealthObject">текушее здоровье</param>
       /// <returns></returns>

        public int Damag(int damage, int currentHealthObject) {
            if (currentHealthObject > 0) {
                currentHealthObject -= damage;
            }
            return currentHealthObject;
        }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="health">сколько добавится здоровья к текушему здоровью</param>
    /// <param name="currentHealthObject">текушее здоровье</param>
    /// <param name="maxHealthObject">максимальное здоровье</param>
    /// <returns></returns>
    public int AddHealth(int health, int currentHealthObject, int maxHealthObject) {
            if (currentHealthObject > 0 && currentHealthObject! > maxHealthObject) {

                currentHealthObject += health;

            }
            return currentHealthObject;
        }

    }






