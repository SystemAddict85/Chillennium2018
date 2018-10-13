using System;
using UnityEngine;

public class PlayerController : Controller
{
    public ControllerType playerNumber = ControllerType.PLAYER_ONE;    

    protected override void Update()
    {
        GetMovementVector();
        GetRightStick();
    }

    private void GetRightStick()
    {
        string hor = "HorizontalRight", vert = "VerticalRight";
        if (playerNumber == ControllerType.PLAYER_ONE)
        {
            hor += "1";
            vert += "1";
        }
        else
        {
            hor += "2";
            vert += "2";
        }
        horizontalAim = Input.GetAxisRaw(hor);
        if (horizontalAim < 0)
            horizontalAim = -1;
        else if(horizontalAim > 0)
            horizontalAim = 1;
        verticalAim = Input.GetAxisRaw(vert);
        if (verticalAim < 0)
            verticalAim = -1;
        else if (verticalAim > 0)
            verticalAim = 1;
    }

    public int GetSpellButtons()
    {
        string spell1, spell2, spell3;
        spell1 = "Ground";
        spell2 = "Lightning";
        spell3 = "Ice";

        if (playerNumber == ControllerType.PLAYER_ONE)
        {
            spell1 += "1";
            spell2 += "1";
            spell3 += "1";
        }
        else
        {
            spell1 += "2";
            spell2 += "2";
            spell3 += "2";
        }

        if (Input.GetButtonDown(spell1))
            return 0;
        else if (Input.GetButtonDown(spell2))
            return 1;
        else if (Input.GetButtonDown(spell3))
            return 2;
        else
            return -1;

    }

    private void GetMovementVector()
    {
        string hor = "Horizontal", vert = "Vertical";
        if (playerNumber == ControllerType.PLAYER_ONE)
        {
            hor += "1";
            vert += "1";
        }
        else
        {
            hor += "2";
            vert += "2";
        }
        horizontal = Input.GetAxisRaw(hor);
        vertical = Input.GetAxisRaw(vert);
    }
}
