using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField]
    private SpellUI spellUI;

    public enum SpellType { GROUND, LIGHTNING, WATER };
    private PlayerController control;
    private Shooter shoot;
    private Character character;

    private void Awake()
    {
        control = GetComponent<PlayerController>();
        shoot = GetComponent<Shooter>();
        character = GetComponent<Character>();
    }
    void Update()
    {
        if (control.hasControl)
        {
            CheckSpells();
            CheckForShoot();
        }
    }

    private void CheckForShoot()
    {
        if (Mathf.Abs(control.HorizontalAim) > 0 || Mathf.Abs(control.VerticalAim) > 0)
        {
            shoot.Shoot((int)character.activeSpell);
        }
    }

    private void CheckSpells()
    {
        int spellInt = control.GetSpellButtons();
        
        if (spellInt != -1)
        {
            SpellType spell = (SpellType)spellInt;
            character.activeSpell = spell;
            foreach (var s in spellUI.spellButtons)
                if (s.spellType == spell)
                {
                    s.SetActive();
                }
                else
                {
                    s.SetTransparent();
                }
        }       
    }

}
