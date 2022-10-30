using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TestEditor : MonoBehaviour {

    [HideInInspector]
    public int Variant1 = 0;

    [Header("Test")]
    public int Variant2 = 0;

    [Range(10, 30)]
    public int Variant3;

    [Space(30)]
    public int Variant4 = 0;

    [Multiline(20)]
    public string Variant5;

    [Tooltip("Tooltio Text")]
    public int Variant6 = 0;

    [ContextMenuItem("Random Count", nameof(RandomMenu))]
    [SerializeField] private int count;


    public void RandomMenu() {

      
    }

}
