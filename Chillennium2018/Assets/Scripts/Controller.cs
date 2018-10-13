using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public enum ControllerType { PLAYER_ONE, PLAYER_TWO, ENEMY };

    protected Character character;

    protected float horizontal;
    protected float vertical;
    protected float horizontalAim;
    protected float verticalAim;

    public virtual float Horizontal { get { return horizontal; } }
    public virtual float Vertical { get { return vertical; } }
    public virtual float HorizontalAim { get { return horizontalAim; } }
    public virtual float VerticalAim { get { return verticalAim; } }

    protected virtual void Awake()
    {
        character = GetComponent<Character>();
    }
    
    protected virtual void Update()
    {

    }
}