﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    //Variables for movement
    public float maxSpeed = 4f;
    public static float XmoveDirection = 0;  //-1 is left, 1 is right, 0 is niether
    public static float YmoveDirection = 0;  //-1 is down, 1 is up, 0 is niether
    public static Vector3 Position;
    bool attack = Weapon.attack;
    public int Thealth = 3;
    float FireRate;
    float NextFire;
    int Lhealth = 0;
    public static bool IsAlive = true;

    CircleCollider2D mainCollider;
    Rigidbody2D r2d;
    SpriteRenderer Render;
    void Start()
    {
        mainCollider = GetComponent<CircleCollider2D>();
        r2d = GetComponent<Rigidbody2D>();
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        Render = GetComponent<SpriteRenderer>();
        r2d.freezeRotation = true;
    }

    void Update()
    {
        Position = transform.position;
        // Movement controls (Left + Right)
        if (Input.GetKey(KeyCode.A))
        {
            YmoveDirection = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            YmoveDirection = 1;        
        }
        else
        {
            YmoveDirection = 0;
        }

        // Movement controls (Up + Down)
        if (Input.GetKey(KeyCode.S))
        {
            XmoveDirection = -1;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            XmoveDirection = 1;
        }
        else
        {
            XmoveDirection = 0;
        }

        Attack();
    }

    //Handles the movement of the character
    private void FixedUpdate()
    {
        r2d.velocity = new Vector2((XmoveDirection) * maxSpeed, r2d.velocity.y);
        r2d.velocity = new Vector2((YmoveDirection) * maxSpeed, r2d.velocity.x);
    }

    //Checks to see if the character gets hit by the enemies
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
            Lhealth++;
            if (Lhealth >= Thealth)
            {
                print("lost all health");
                IsAlive = false;
            }
    }

    //Checks to see if the character is attack, then runs the attacking
    private void Attack()
    {
        FireRate = EnemyMovement1.FireRate;
        NextFire = EnemyMovement1.NextFire;
        if (Time.time > NextFire)
        {
            Render.material.SetColor("_Color", Color.red);
        }
        else
        {
            Render.material.SetColor("_Color", Color.white);
        }
    }
}
