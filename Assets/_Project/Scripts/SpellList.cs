using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpellList : MonoBehaviour {
    public List<Spell> spells = new List<Spell>();
    public int length = 3;

    public GameObject entryPrefab;

    void Start() {
        var y = 0.0f;

        // TODO hack this better
        var follower = GetComponent<ObjectUIFollower>();
        if (follower != null) {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(follower.target.position);
            GetComponent<RectTransform>().position = screenPos + follower.offset;
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

        // Move ourselves to the canvas
        transform.SetParent(GameObject.Find("Canvas").transform, false);
    }
}
