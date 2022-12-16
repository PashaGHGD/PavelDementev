using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal sealed class PanelTwo : MenuUI {
    [SerializeField] private Text _text;
    public override void Execute() {
        _text.text = "Выход из меню";
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public override void Cancel() {
        gameObject.SetActive(false);
    }
}
