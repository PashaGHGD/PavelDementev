using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


internal sealed class PanelOne : MenuUI {
    [SerializeField] private Text _text;
    public override void Execute() {
        _text.text = "Μενώ";
        gameObject.SetActive(true);
        Time.timeScale = 1f;
    }
    public override void Cancel() {
        gameObject.SetActive(false);
    }
}

