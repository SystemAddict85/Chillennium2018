using System;
using UnityEngine;

public class PlayerController : Controller
{
    public ControllerType playerNumber = ControllerType.PLAYER_ONE;
    private bool isDashing = false;
    private Vector2 lastMove;

    protected override void Update()
    {
        GetMovementVector();
        GetRightStick();
    }

    private void LateUpdate()
    {
        if (lastMove != Vector2.zero && !isDashing)
        {
            GetDashButton();
        }
    }

    public void FinishDashing()
    {
        isDashing = false;
    }

    public void GetDashButton()
    {
        string dash = "Dash";
        if (playerNumber == ControllerType.PLAYER_ONE)
            dash += "1";
        else
            dash += "2";

        if (Input.GetButtonDown(dash))
        {
            isDashing = true;
            GetComponent<Dashing>().SetDashDirection(lastMove);
        }
    }

    private void GetRightStick()
    {
        if (!isDashing)
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
            else if (horizontalAim > 0)
                horizontalAim = 1;
            verticalAim = Input.GetAxisRaw(vert);
            if (verticalAim < 0)
                verticalAim = -1;
            else if (verticalAim > 0)
                verticalAim = 1;
        }
    }

    public int GetSpellButtons()
    {
        string spell1, spell2, spell3, dash;
        spell1 = "Ground";
        spell2 = "Lightning";
        spell3 = "Water";

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
        lastMove = new Vector2(horizontal, vertical);
    }
}
