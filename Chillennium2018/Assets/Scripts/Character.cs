using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Controller control;
    public enum Effectiveness { REDUCED, NORMAL, SUPER };
    public Spell.SpellType spellType = Spell.SpellType.GROUND;
    [SerializeField]
    public float maxHealth;
    [SerializeField]
    public float currentHealth;

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Damage(int amount, Effectiveness effectiveness)
    {
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
            Die();
        }
    }

    
}