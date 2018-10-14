using UnityEngine;
using System.Collections;
using System;

public class Projectile : MonoBehaviour
{    
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lifeDuration;
    private Vector2 direction;

    public Spell.SpellType spellType = Spell.SpellType.GROUND;

    private PlayerController controller;

    private Movement move;
    private ProjectilePool parentPool;
    private bool timerStarted = false;

    private float currentTime = 0f;

    private LayerMask oppositeLayer;

    void Awake()
    {
        SetOppositeLayer();
        move = GetComponent<Movement>();
        lifeDuration = 5f;
    }

    private void SetOppositeLayer()
    {
        if(gameObject.layer == LayerMask.NameToLayer("Player Projectile"))
        {
            oppositeLayer = LayerMask.NameToLayer("Enemy");
        }
        else if(gameObject.layer == LayerMask.NameToLayer("Enemy Projectile"))
        {
            oppositeLayer = LayerMask.NameToLayer("Player");
        }
    }

    private void OnEnable()
    {
        currentTime = 0f;
    }

    public void SetPool(ProjectilePool pool)
    {
        parentPool = pool;
    }

    public void Shoot(Vector2 dir, PlayerController contr = null)
    {
        controller = contr;
        timerStarted = false;
        currentTime = 0f;
        direction = dir;
        move.SetSpeed(speed);
        gameObject.SetActive(true);
        timerStarted = true;
    }

    private void Update()
    {
        if (move.canMove)
        {
            if (timerStarted)
            {
                currentTime += Time.deltaTime;
                if (currentTime >= lifeDuration)
                {
                    timerStarted = false;
                    currentTime = 0f;
                    gameObject.SetActive(false);
                    parentPool.Return(this);
                }
            }

            move.Move(direction);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == oppositeLayer)
        {
            if(oppositeLayer == LayerMask.NameToLayer("Enemy"))
            {

                var enemy = col.gameObject.GetComponent<Enemy>();
                enemy.Damage(1, Character.DetermineAttackEffect(spellType, enemy.activeSpell), controller);
            }            
            else if(oppositeLayer == LayerMask.NameToLayer("Player"))
            {
                var player = col.gameObject.GetComponent<Player>();
                player.Damage(1, Character.DetermineAttackEffect(spellType, player.activeSpell));
            }

            timerStarted = false;
            currentTime = 0f;
            gameObject.SetActive(false);
            parentPool.Return(this);
        }
    }

    

}
