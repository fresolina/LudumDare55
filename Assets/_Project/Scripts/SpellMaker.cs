using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpellMaker {
    private static List<string>[] spells = new List<string>[7];

    private static void LoadSpells(int len) {
        // http://www.lexique.org/shiny/unipseudo/
        var asset = Resources.Load<TextAsset>("words_" + len);
        spells[len] = new List<string>();
        foreach (string line in asset.text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)) {
            spells[len].Add(line.ToUpper());
        }

    }

    // Get random spell
    public static String GetRandomSpell(int len = 6) {
        if (len < 3)
            len = 3;
        if (len > 6)
            len = 6;

        if (spells[len] == null)
            LoadSpells(len);

        return spells[len][UnityEngine.Random.Range(0, spells[len].Count)];
    }
}
