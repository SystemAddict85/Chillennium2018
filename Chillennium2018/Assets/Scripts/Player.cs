using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : Character
{

    [SerializeField]
    private GameObject gameOverText;

    public bool isPlayerDead = false;

    public PlayerController controller;

    private void Awake()
    {
        maxHealth = 6;
        currentHealth = maxHealth;
        controller = GetComponent<PlayerController>();
    }

    public override void Die()
    {
        isPlayerDead = true;

        if (!LevelManager.Instance.isOnePlayerDead)
        {
            LevelManager.Instance.isOnePlayerDead = true;
            DisablePlayer();
        }
        else
        {
            GlobalStuff.FreezeSpawning();
            GlobalStuff.FreezeAllMovement();
            Debug.Log("Game Over");
            gameOverText.SetActive(true);

            StartCoroutine(EndGameWait());
            // TODO: GameOver
        }

    }

    private void DisablePlayer()
    {
        controller.hasControl = false;
        GetComponent<Movement>().canMove = false;
        foreach (var col in GetComponentsInChildren<Collider2D>())
        {
            col.enabled = false;
        }

        foreach (var rend in GetComponentsInChildren<SpriteRenderer>())
        {
            rend.enabled = false;
        }
        foreach (var anim in GetComponentsInChildren<Animator>())
        {
            anim.enabled = false;
        }
    }

    public void HidePlayer()
    {
        GetComponentInChildren<SpriteRenderer>().enabled = false;
    }

    public void ShowPlayer()
    {
        GetComponentInChildren<SpriteRenderer>().enabled = true;
    }

    public override void Damage(int amount, Effectiveness effectiveness, PlayerController passedController = null)
    {
        base.Damage(amount, effectiveness);
        if (controller.playerNumber == Controller.ControllerType.PLAYER_ONE)
        {
            UIController.Instance.UpdateHearts(0);
        }
        else if (controller.playerNumber == Controller.ControllerType.PLAYER_TWO)
        {
            UIController.Instance.UpdateHearts(1);
        }
    }

    public void PowerUp(Spell.SpellType spellType)
    {
        switch (spellType)
        {
            case Spell.SpellType.GROUND:
                break;
            case Spell.SpellType.LIGHTNING:
                break;
            case Spell.SpellType.WATER:
                break;
        }
    }

    public void Heal()
    {
        int toHeal = Random.Range(1, 3);
        if (currentHealth < maxHealth)
        {
            currentHealth += toHeal;
            if (currentHealth > maxHealth)
                currentHealth = maxHealth;
        }
        if (controller.playerNumber == Controller.ControllerType.PLAYER_ONE)
        {
            UIController.Instance.UpdateHearts(0);
        }
        else if (controller.playerNumber == Controller.ControllerType.PLAYER_TWO)
        {
            UIController.Instance.UpdateHearts(1);
        }
    }

    IEnumerator EndGameWait()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("Waiting");
        SceneManager.LoadScene("GameOver");
    }
}
