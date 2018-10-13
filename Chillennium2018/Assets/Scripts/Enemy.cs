using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character  {

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player Projectile"))
        {
            Effectiveness effectiveness = Effectiveness.NORMAL;
            switch (spellType)
            {
                case Spell.SpellType.GROUND:
                    switch (col.GetComponent<Projectile>().spellType)
                    {
                        case Spell.SpellType.GROUND:
                            effectiveness = Effectiveness.NORMAL;
                            break;
                        case Spell.SpellType.LIGHTNING:
                            effectiveness = Effectiveness.REDUCED;
                            break;
                        case Spell.SpellType.ICE:
                            effectiveness = Effectiveness.SUPER;
                            break;
                    }
                    break;
                case Spell.SpellType.LIGHTNING:
                    switch (col.GetComponent<Projectile>().spellType)
                    {
                        case Spell.SpellType.GROUND:
                            effectiveness = Effectiveness.SUPER;
                            break;
                        case Spell.SpellType.LIGHTNING:
                            effectiveness = Effectiveness.NORMAL;
                            break;
                        case Spell.SpellType.ICE:
                            effectiveness = Effectiveness.REDUCED;
                            break;
                    }
                    break;
                case Spell.SpellType.ICE:
                    switch (col.GetComponent<Projectile>().spellType)
                    {
                        case Spell.SpellType.GROUND:
                            effectiveness = Effectiveness.REDUCED;
                            break;
                        case Spell.SpellType.LIGHTNING:
                            effectiveness = Effectiveness.SUPER;
                            break;
                        case Spell.SpellType.ICE:
                            effectiveness = Effectiveness.NORMAL;
                            break;
                    }
                    break;
            }
            Debug.Log(effectiveness);
            //damage
        }
    }
}
