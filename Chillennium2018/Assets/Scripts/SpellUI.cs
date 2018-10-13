using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellUI : MonoBehaviour {

    // Use this for initialization
    public SpellUIButton[] spellButtons;
    private void Awake()
    {
        spellButtons = GetComponentsInChildren<SpellUIButton>();
    }
}
