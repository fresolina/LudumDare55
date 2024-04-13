using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Typer : MonoBehaviour
{

    public TMP_Text TypeField;

    public event Action<String> TypeEvent;

    void Start()
    {
        TypeField.text = "";
    }

    void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // has backspace/delete been pressed?
            {
                if (TypeField.text.Length != 0)
                {
                    TypeField.text = TypeField.text.Substring(0, TypeField.text.Length - 1);
                    TypeEvent?.Invoke(TypeField.text);
                }
            }
            else if ((c == '\n') || (c == '\r')) // enter/return
            {
                print("Execute: " + TypeField.text);
                TypeField.text = "";
                TypeEvent?.Invoke(TypeField.text);
            }
            else if (c >= 'a' && c <= 'z')
            {
                TypeField.text += Char.ToUpper(c);
                TypeEvent?.Invoke(TypeField.text);
            }
        }
    }
}
