using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpellList : MonoBehaviour {
    public List<Spell> spells = new List<Spell>();
    public int length = 3;

    public GameObject entryPrefab;

    void Start() {
        var y = 0.0f;

        var follower = GetComponent<ObjectUIFollower>();
        if (follower != null) {
            var target = follower.target;
            if (target != null) {
                var renderer = target.GetComponent<Renderer>();
                if (renderer != null) {
                    // "/ 2.0" because pivot is in middle
                    // "* 32.0" because 1 unit = 32 pixels (can maybe be read from sprite)
                    y = renderer.bounds.size.y / 2.0f * 32.0f;
                }
            }
        }

        foreach (var spell in spells) {
            var position = new Vector3(0.0f, y, 0.0f);
            var entry = Instantiate(entryPrefab, transform);
            entry.transform.localPosition = position;
            y += entry.GetComponent<RectTransform>().rect.height;

            var indicator = entry.GetComponentInChildren<SpellIndicator>();
            if (indicator) {
                indicator.length = length;
            }

            var icon = entry.transform.Find("Icon").GetComponent<Image>();
            icon.sprite = spell.Icon();

            // Ugly way to connect spell class
            entry.gameObject.AddComponent(spell.GetType()); ;
        }
    }
}
