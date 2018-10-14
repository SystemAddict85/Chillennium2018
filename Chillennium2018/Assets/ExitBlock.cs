using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBlock : MonoBehaviour {

    private SpriteRenderer rend;
    private BoxCollider2D box;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
        Unblock();
    }

    public void Block()
    {
        rend.enabled = true;
        box.enabled = true;
    }

    public void Unblock()
    {
        rend.enabled = false;
        box.enabled = false;
    }
}
