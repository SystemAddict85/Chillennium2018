using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour {
       
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            var player = col.gameObject.GetComponent<Player>();
            Character.Effectiveness effectiveness = Character.Effectiveness.NORMAL;
            switch (GetComponent<Enemy>().activeSpell)
            {
                case Spell.SpellType.GROUND:
                    switch (player.activeSpell)
                    {
                        case Spell.SpellType.GROUND:
                            effectiveness = Character.Effectiveness.NORMAL;
                            break;
                        case Spell.SpellType.LIGHTNING:
                            effectiveness = Character.Effectiveness.REDUCED;
                            break;
                        case Spell.SpellType.WATER:
                            effectiveness = Character.Effectiveness.SUPER;
                            break;
                    }
                    break;
                case Spell.SpellType.LIGHTNING:
                    switch (player.activeSpell)
                    {
                        case Spell.SpellType.GROUND:
                            effectiveness = Character.Effectiveness.SUPER;
                            break;
                        case Spell.SpellType.LIGHTNING:
                            effectiveness = Character.Effectiveness.NORMAL;
                            break;
                        case Spell.SpellType.WATER:
                            effectiveness = Character.Effectiveness.REDUCED;
                            break;
                    }
                    break;
                case Spell.SpellType.WATER:
                    switch (player.activeSpell)
                    {
                        case Spell.SpellType.GROUND:
                            effectiveness = Character.Effectiveness.REDUCED;
                            break;
                        case Spell.SpellType.LIGHTNING:
                            effectiveness = Character.Effectiveness.SUPER;
                            break;
                        case Spell.SpellType.WATER:
                            effectiveness = Character.Effectiveness.NORMAL;
                            break;
                    }
                    break;
            }
            player.Damage(1, effectiveness);
        }
    }
}
