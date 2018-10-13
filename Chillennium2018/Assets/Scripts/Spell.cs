using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField]
    private SpellUI spellUI;
    public enum SpellType { GROUND, LIGHTNING, ICE };
    private PlayerController control;

    private void Awake()
    {
        control = GetComponent<PlayerController>();
    }
    void Update()
    {
        CheckSpells();
    }

    private void CheckSpells()
    {
        int spellInt = control.GetSpellButtons();
        
        if (spellInt != -1)
        {
            SpellType spell = (SpellType)spellInt;
            //Debug.Log(spell);
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

        
            
        //todo: set player active spell
    }

}
