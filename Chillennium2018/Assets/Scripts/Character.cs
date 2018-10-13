using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Controller control;
    public enum Effectiveness { REDUCED, NORMAL, SUPER };
    public Spell.SpellType activeSpell = Spell.SpellType.GROUND;

    [SerializeField]
    protected float maxHealth;
    public float currentHealth;

    [SerializeField]
    protected float invincibilityDuration = 0f;
    [SerializeField]
    protected int blinkIntervals = 5;
    [SerializeField]
    private bool canBeDamaged = true;

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public void Damage(int amount, Effectiveness effectiveness)
    {
        if (canBeDamaged)
        {
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
                Die();
            }
        }
    }

    public void Invincibility()
    {
        if (invincibilityDuration > 0f)
        {
            StartCoroutine(BeginInvincibility());
            StartCoroutine(BlinkSprite());
        }
    }

    IEnumerator BeginInvincibility()
    {
        canBeDamaged = false;
        yield return new WaitForSeconds(invincibilityDuration);
        canBeDamaged = true;
    }

    IEnumerator BlinkSprite()
    {
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        float interval = invincibilityDuration/blinkIntervals;
        Color c = spriteRenderer.color;
        for (int i =0; i< blinkIntervals; i++)
        {
            c.a = .2f;
            spriteRenderer.color = c;
            yield return new WaitForSeconds(interval/2f);
            c.a = 1f;
            spriteRenderer.color = c;
            if(i != blinkIntervals - 1)
                yield return new WaitForSeconds(interval/2f);
        }
    }
}