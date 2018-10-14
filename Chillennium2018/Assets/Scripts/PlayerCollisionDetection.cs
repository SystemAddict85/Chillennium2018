using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{

    private bool player1Entered = false;
    private bool player2Entered = false;

    private float currentPlayer1Time = 0f;
    private float currentPlayer2Time = 0f;
    private float invincibilityPlayer1Duration;
    private float invincibilityPlayer2Duration;

    private Player player1;
    private Player player2;

    private void Update()
    {
        if (player1Entered)
        {
            currentPlayer1Time += Time.deltaTime;
            if (currentPlayer1Time >= invincibilityPlayer1Duration)
            {
                currentPlayer1Time = 0f;
                player1.Damage(1, Character.DetermineAttackEffect(GetComponent<Enemy>().activeSpell, player1.activeSpell));
            }
        }
        if (player2Entered)
        {
            currentPlayer2Time += Time.deltaTime;
            if (currentPlayer2Time >= invincibilityPlayer2Duration)
            {
                currentPlayer2Time = 0f;
                player2.Damage(1, Character.DetermineAttackEffect(GetComponent<Enemy>().activeSpell, player2.activeSpell));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (gameObject.tag != "SightRange")
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                CollideWithPlayer(col.collider);
            }         
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (gameObject.tag != "SightRange")
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                var playerNum = col.gameObject.GetComponent<PlayerController>().playerNumber;

                if (playerNum == PlayerController.ControllerType.PLAYER_ONE)
                {
                    player1Entered = false;
                }
                else if (playerNum == PlayerController.ControllerType.PLAYER_TWO)
                {
                    player2Entered = false;
                }
            }
        }
    }

    private void CollideWithPlayer(Collider2D col)
    {
        var playerNum = col.gameObject.GetComponent<PlayerController>().playerNumber;

        if (playerNum == Controller.ControllerType.PLAYER_ONE)
        {
            player1Entered = true;
            player1 = col.gameObject.GetComponent<Player>();
            invincibilityPlayer1Duration = player1.invincibilityDuration;
        }
        else if (playerNum == Controller.ControllerType.PLAYER_TWO)
        {
            player2Entered = true;
            player2 = col.gameObject.GetComponent<Player>();
            invincibilityPlayer2Duration = player2.invincibilityDuration;
        }

        var player = col.gameObject.GetComponent<Player>();
        if (!player.canBeDamaged)
            return;

        player.Damage(1, Character.DetermineAttackEffect(GetComponent<Enemy>().activeSpell, player.activeSpell));
    }
}
