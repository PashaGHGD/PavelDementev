using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    interface IHealth {
        
        public int Damag(int damage, int currentHealthObject);
        public int AddHealth(int health, int currentHealthObject, int maxHealthObject);

    }
