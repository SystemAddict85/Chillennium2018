using System;
using UnityEngine;

public class PlayerController : Controller
{
    public ControllerType playerNumber = ControllerType.PLAYER_ONE;
    private bool isDashing = false;
    private Vector2 lastMove;

    private Ultimate ultimate;

    private bool isUltimateReady = true;

    protected override void Awake()
    {
        base.Awake();
        ultimate = GetComponentInChildren<Ultimate>();
    }

    protected override void Update()
    {
        if (hasControl)
        {
            if (!CheckForUltimate())
            {
                GetMovementVector();
                GetRightStick();
            }
            else
            {
                lastMove = Vector2.zero;
            }
        }
        else
        {
            lastMove = Vector2.zero;
        }

    }

    private void LateUpdate()
    {
        if (hasControl && lastMove != Vector2.zero && !isDashing)
        {
            GetDashButton();
        }
    }

    private bool CheckForUltimate()
    {
        if (isUltimateReady) {
            var input = "Ultimate" + ((int)playerNumber + 1).ToString();            
            if (Input.GetButtonDown(input))
            {
                isUltimateReady = false;
                ultimate.ActivateUltimate();
                return true;
            }
        }
        return false;
    }

    public void EnableUltimate()
    {
        isUltimateReady = true;
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
        string spell1, spell2, spell3;
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
        if (hasControl)
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
        else
        {
            lastMove = new Vector3(0f, 0f);
        }
    }
}
