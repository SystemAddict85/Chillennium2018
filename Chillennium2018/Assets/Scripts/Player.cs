using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    private void Awake()
    {
        maxHealth = 6f;
        currentHealth = maxHealth;
    }

    public void PowerUp(Spell.SpellType spellType)
    {
        switch (spellType)
        {
            case Spell.SpellType.GROUND:
                break;
            case Spell.SpellType.LIGHTNING:
                break;
            case Spell.SpellType.WATER:
                break;
        }
    }

    public void Heal()
    {
        int toHeal = Random.Range(1, 3);
        if (currentHealth < maxHealth)
        {
            currentHealth += toHeal;
            if (currentHealth > maxHealth)
                currentHealth = maxHealth;
        }
    }
}
