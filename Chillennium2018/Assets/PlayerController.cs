using UnityEngine;

public class PlayerController : Controller
{   
    public ControllerType playerNumber = ControllerType.PLAYER_ONE;

    protected override void Update()
    {
        string hor = "Horizontal1", vert = "Vertical1";
        if (playerNumber == ControllerType.PLAYER_TWO)
        {
            hor = "Horizontal2";
            vert = "Vertical2";
        }
        horizontal = Input.GetAxisRaw(hor);
        vertical = Input.GetAxisRaw(vert);
    }
}
