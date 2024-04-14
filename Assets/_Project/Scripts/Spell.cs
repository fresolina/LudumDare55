using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour {
    public abstract Sprite Icon();
    public abstract void Cast(GameObject target);
}
