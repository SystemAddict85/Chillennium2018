using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    public bool isPlayerDead = false;

    private void Awake()
    {
        maxHealth = 6f;
        currentHealth = maxHealth;
    }

    public override void Die()
    {
        isPlayerDead = true;
        if (!LevelManager.Instance.isAPlayerDead)
        {
            LevelManager.Instance.isAPlayerDead = true;
        }
        else
        {
            // TODO: GameOver
        }

    }

    public void HidePlayer()
    {
        GetComponentInChildren<SpriteRenderer>().enabled = false;
    }

    public void ShowPlayer()
    {
        GetComponentInChildren<SpriteRenderer>().enabled = true;
    }


    public void PowerUp(Spell.SpellType spellType)
    {
        switch (spellType)
        {
            case Spell.SpellType.GROUND:
                break;
            case Spell.SpellType.LIGHTNING:
                break;
            case Spell.SpellType.ICE:
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
