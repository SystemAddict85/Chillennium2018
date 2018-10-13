using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    public Spell.SpellType spellType = Spell.SpellType.GROUND;

    public enum Pickup { HEALTH, POWERUP };
    [SerializeField]
    public Pickup pickup;

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            switch (pickup)
            {
                case Pickup.HEALTH:
                    col.gameObject.GetComponent<Player>().Heal();
                    Destroy(gameObject);
                    break;
                case Pickup.POWERUP:
                    col.gameObject.GetComponent<Player>().PowerUp(spellType);
                    Destroy(gameObject);
                    break;
            }
        }

    }
}
