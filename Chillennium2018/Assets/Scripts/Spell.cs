﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int spellInt = GetSpellButtons();
        SpellType spell;
        if (spellInt != -1)
        {
            spell = (SpellType)spellInt;
        }
    }
}
