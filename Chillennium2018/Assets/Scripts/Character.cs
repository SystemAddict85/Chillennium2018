using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Controller control;
    public enum Effectiveness { REDUCED, NORMAL, SUPER };
    public Spell.SpellType spellType = Spell.SpellType.GROUND;
}