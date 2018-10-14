using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Controller control;
    public enum Effectiveness { REDUCED, NORMAL, SUPER };
    public Spell.SpellType activeSpell = Spell.SpellType.GROUND;

    [SerializeField]
    protected int maxHealth;
    public int currentHealth;
        
    public float invincibilityDuration = 0f;
    [SerializeField]
    protected int blinkIntervals = 5;
    [SerializeField]
    public bool canBeDamaged = true;

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void Damage(int amount, Effectiveness effectiveness)
    {
        var dashing = GetComponent<Dashing>();
        if ((dashing && dashing.isDashing) || effectiveness == Effectiveness.REDUCED || !canBeDamaged)
            return;

        canBeDamaged = false;
        Invincibility();
        switch (effectiveness)
        {
            case Effectiveness.REDUCED:
                break;
            case Effectiveness.SUPER:
                currentHealth -= amount * 2;
                break;
            case Effectiveness.NORMAL:
                currentHealth -= amount;
                break;
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

    }

    public void Invincibility()
    {
        if (invincibilityDuration > 0f)
        {            
            StartCoroutine(BlinkSprite());
        }
    }    

    IEnumerator BlinkSprite()
    {
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        float interval = invincibilityDuration / blinkIntervals;
        Color c = spriteRenderer.color;
        for (int i = 0; i < blinkIntervals; i++)
        {
            c.a = .2f;
            spriteRenderer.color = c;
            yield return new WaitForSeconds(interval / 2f);
            c.a = 1f;
            spriteRenderer.color = c;
            if (i != blinkIntervals - 1)
                yield return new WaitForSeconds(interval / 2f);
        }
        canBeDamaged = true;
    }

    public static Effectiveness DetermineAttackEffect(Spell.SpellType attacker, Spell.SpellType defender)
    {
        Character.Effectiveness effect = Character.Effectiveness.NORMAL;
        switch (attacker)
        {
            case Spell.SpellType.GROUND:
                switch (defender)
                {
                    case Spell.SpellType.GROUND:
                        effect = Character.Effectiveness.NORMAL;
                        break;
                    case Spell.SpellType.LIGHTNING:
                        effect = Character.Effectiveness.SUPER;
                        break;
                    case Spell.SpellType.WATER:
                        effect = Character.Effectiveness.REDUCED;
                        break;
                }
                break;
            case Spell.SpellType.LIGHTNING:
                switch (defender)
                {
                    case Spell.SpellType.GROUND:
                        effect = Character.Effectiveness.REDUCED;
                        break;
                    case Spell.SpellType.LIGHTNING:
                        effect = Character.Effectiveness.NORMAL;
                        break;
                    case Spell.SpellType.WATER:
                        effect = Character.Effectiveness.SUPER;
                        break;
                }
                break;
            case Spell.SpellType.WATER:
                switch (defender)
                {
                    case Spell.SpellType.GROUND:
                        effect = Character.Effectiveness.SUPER;
                        break;
                    case Spell.SpellType.LIGHTNING:
                        effect = Character.Effectiveness.REDUCED;
                        break;
                    case Spell.SpellType.WATER:
                        effect = Character.Effectiveness.NORMAL;
                        break;
                }
                break;
        }
        return effect;
    }

    public static Effectiveness DetermineDefenseEffect(Spell.SpellType defender, Spell.SpellType attacker)
    {
        Character.Effectiveness effect = Character.Effectiveness.NORMAL;
        switch (defender)
        {
            case Spell.SpellType.GROUND:
                switch (attacker)
                {
                    case Spell.SpellType.GROUND:
                        effect = Character.Effectiveness.NORMAL;
                        break;
                    case Spell.SpellType.LIGHTNING:
                        effect = Character.Effectiveness.SUPER;
                        break;
                    case Spell.SpellType.WATER:
                        effect = Character.Effectiveness.REDUCED;
                        break;
                }
                break;
            case Spell.SpellType.LIGHTNING:
                switch (attacker)
                {
                    case Spell.SpellType.GROUND:
                        effect = Character.Effectiveness.REDUCED;
                        break;
                    case Spell.SpellType.LIGHTNING:
                        effect = Character.Effectiveness.NORMAL;
                        break;
                    case Spell.SpellType.WATER:
                        effect = Character.Effectiveness.SUPER;
                        break;
                }
                break;
            case Spell.SpellType.WATER:
                switch (attacker)
                {
                    case Spell.SpellType.GROUND:
                        effect = Character.Effectiveness.SUPER;
                        break;
                    case Spell.SpellType.LIGHTNING:
                        effect = Character.Effectiveness.REDUCED;
                        break;
                    case Spell.SpellType.WATER:
                        effect = Character.Effectiveness.NORMAL;
                        break;
                }
                break;
        }
        return effect;
    }
}