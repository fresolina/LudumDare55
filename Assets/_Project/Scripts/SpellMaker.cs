using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpellMaker {
    private static List<string> spells = new List<string>();


    private static void LoadSpells() {
        // http://www.lexique.org/shiny/unipseudo/
        var asset = Resources.Load<TextAsset>("words");
        foreach (string line in asset.text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)) {
            spells.Add(line.ToUpper());
        }

    }

    // Get random spell
    public static String GetRandomSpell(int len = 6) {
        if (spells.Count == 0)
            LoadSpells();
        return spells[UnityEngine.Random.Range(0, spells.Count)].Substring(0, len);
    }
}
