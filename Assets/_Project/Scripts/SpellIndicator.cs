using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellIndicator : MonoBehaviour {
    private static Typer typer;

    public int length = 6;

    private string spell = "";
    private TMP_Text display;

    // Start is called before the first frame update
    void Start() {
        if (typer == null)
            typer = FindObjectOfType<Typer>();

        typer.TypeEvent += OnTypeEvent;
        display = GetComponent<TMP_Text>();

        Randomize();
    }

    void Randomize() {
        spell = SpellMaker.GetRandomSpell(length);
        display.text = spell;
    }

    void OnTypeEvent(string text) {
        // If this spell starts with the text, highlight it in the field.
        // Otherwise clear all hightlights.
        if (spell == text) {
            display.text = "<u><size=120%><color=\"green\">" + text + "</color></size></u>";

            var spellToCast = GetComponentInParent<Spell>();
            var follower = GetComponentInParent<ObjectUIFollower>();
            print("Spell complete: spell = " + spellToCast + ", follower = " + follower + " target = " + follower?.target);
            if (follower != null && spellToCast != null) {
                spellToCast.Cast(follower.target.gameObject);
            } else if (spellToCast != null) {
                spellToCast.Cast(null);
            } else {
                Debug.Log("SpellIndicator: No spell to cast!");
            }

            typer.Reset();
            Randomize();
        } else if (text != "" && spell.StartsWith(text)) {
            display.text = "<u><color=\"green\">" + text + "</color></u>" + spell.Substring(text.Length);
        } else {
            display.text = spell;
        }
    }

    void OnDestroy() {
        typer.TypeEvent -= OnTypeEvent;
    }
}
