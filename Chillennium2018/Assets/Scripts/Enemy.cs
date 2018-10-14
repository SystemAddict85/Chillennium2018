using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character  {
    private void Awake()
    {
        maxHealth = 10f;
        currentHealth = maxHealth;
    }

    public override void Die()
    {
        float chanceToDrop = Random.Range(0f, 1f);
        chanceToDrop *= 100f;
        if (chanceToDrop <= 8f)//powerup
        {
            Debug.Log("todo: drop powerup");
        }
        else if (chanceToDrop >= 8f && chanceToDrop <= 20f)//health
        {
            Debug.Log("todo: drop Health");
        }
        else if (chanceToDrop >= 20f && chanceToDrop <= 24f && LevelManager.Instance.isAPlayerDead)
        {//revive
            Debug.Log("todo: drop Revive");
        }

        LevelManager.Instance.GetRoom.RemoveEnemyAndCheckForRoomComplete(this);
        base.Die();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player Projectile"))
        {
            Effectiveness effectiveness = Effectiveness.NORMAL;
            switch (activeSpell)
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
                        case Spell.SpellType.WATER:
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
                        case Spell.SpellType.WATER:
                            effectiveness = Effectiveness.REDUCED;
                            break;
                    }
                    break;
                case Spell.SpellType.WATER:
                    switch (col.GetComponent<Projectile>().spellType)
                    {
                        case Spell.SpellType.GROUND:
                            effectiveness = Effectiveness.REDUCED;
                            break;
                        case Spell.SpellType.LIGHTNING:
                            effectiveness = Effectiveness.SUPER;
                            break;
                        case Spell.SpellType.WATER:
                            effectiveness = Effectiveness.NORMAL;
                            break;
                    }
                    break;
            }
            //Debug.Log(effectiveness);
            Damage(1, effectiveness);
        }
    }

}
