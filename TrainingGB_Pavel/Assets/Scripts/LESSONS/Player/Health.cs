using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson {

    public class Health : IHealth {



        /// <summary>
        /// метод который отвечает за урон 
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="currentHealthObject"></param>
        /// <returns></returns>

        public int Damag(int damage, int currentHealthObject) {
            if (currentHealthObject > 0) {
                currentHealthObject -= damage;
            }
            return currentHealthObject;
        }
        /// <summary>
        /// метод который отвечает за добавления здоровья 
        /// </summary>
        /// <param name="health"></param>
        /// <param name="currentHealthObject"></param>
        /// <param name="maxHealthObject"></param>
        /// <returns></returns>
        public int AddHealth(int health, int currentHealthObject, int maxHealthObject) {
            if (currentHealthObject > 0 && currentHealthObject! > maxHealthObject) {

                currentHealthObject += health;

            }
            return currentHealthObject;
        }

    }



}


