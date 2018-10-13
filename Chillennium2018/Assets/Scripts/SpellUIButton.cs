using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellUIButton : MonoBehaviour {
    [SerializeField]
    public Spell.SpellType spellType;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetTransparent()
    {
        Color tmp = spriteRenderer.color;
        tmp.a = .5f;
        spriteRenderer.color = tmp;
    }

    public void SetActive()
    {
        Color tmp = spriteRenderer.color;
        tmp.a = 1f;
        spriteRenderer.color = tmp;
    }
}
