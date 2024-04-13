using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Typer : MonoBehaviour {

    public TMP_Text TypeField;

    private bool hint = true;

    public event Action<string> TypeEvent;

    void Start() {
        TypeField.text = "<color=\"grey\">Type to summon</color>";
    }

    void Update() {
        foreach (char c in Input.inputString) {
            if (hint) {
                TypeField.text = "";
                hint = false;
            }

            if (c == '\b') // has backspace/delete been pressed?
            {
                if (TypeField.text.Length != 0) {
                    TypeField.text = TypeField.text.Substring(0, TypeField.text.Length - 1);
                    TypeEvent?.Invoke(TypeField.text);
                }
                /*} else if ((c == '\n') || (c == '\r')) // enter/return
                  {
                    print("Execute: " + TypeField.text);
                    TypeField.text = "";
                    TypeEvent?.Invoke(TypeField.text);
                    */
            } else if ((c >= 'a' && c <= 'z') || c == '-') {
                TypeField.text += Char.ToUpper(c);
                TypeEvent?.Invoke(TypeField.text);
            }
        }
    }

    public void Reset() {
        TypeField.text = "";
        TypeEvent?.Invoke(TypeField.text);
    }
}
