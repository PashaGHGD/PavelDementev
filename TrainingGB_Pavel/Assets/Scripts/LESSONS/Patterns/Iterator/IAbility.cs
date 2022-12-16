using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Flags]
public enum Target {
    None = 0,
    Unit = 1,
    Autocast = 2,
    Passive = 4,
}

public enum DamageType {
    None = 0,
    Magical = 1,
    Pure = 2,
}
public interface IAbility {

    string Name { get; }
    int Damage { get; }
    DamageType DamageType { get; }
    Target Target { get; }

}

