using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour {
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_InputField _inputField;
    private void Start() {
        _inputField.onValueChanged.AddListener(Interpret);
    }
    private void Interpret(string value) {
        if (Int64.TryParse(value, out var number)) {
            _text.text = Result(number);
        }
    }
    private string Result(long number) {
        if ((number < 0) || (number > 922337203685477580)) throw new
        ArgumentOutOfRangeException(nameof(number),
        "insert value betwheen 1 and 922337203685477580");
        if (number < 1) return string.Empty;
        if (number < 1000) return number + "";
        if (number >= 1000 && number < 1000000) return number / 1000 + "K";
        if (number >= 1000000 && number < 922337203685477580) return number / 1000000 + "M";
        if (number > 922337203685477581) return "ни!";


        throw new ArgumentOutOfRangeException(nameof(number));
    }
}




