using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellIndicator : MonoBehaviour
{
    public Typer typer;

    private string spell = "";
    private TMP_Text display;

    // Start is called before the first frame update
    void Start()
    {
        typer.TypeEvent += OnTypeEvent;
        display = GetComponent<TMP_Text>();
        spell = display.text.ToUpper();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTypeEvent(string text)
    {
        // If this spell starts with the text, highlight it in the field.
        // Otherwise clear all hightlights.
        if (spell == text)
        {
            display.text = "<u><size=120%><color=\"green\">" + text + "</color></size></u>";
        }
        else if (text != "" && spell.StartsWith(text))
        {
            display.text = "<u><color=\"green\">" + text + "</color></u>" + spell.Substring(text.Length);
        }
        else
        {
            display.text = spell;
        }

    }
}