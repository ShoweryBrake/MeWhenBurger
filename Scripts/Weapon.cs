using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //gosh dang verbles
    public Vector3 CharacterPosition;
    private float Ymove;
    private float Xmove;
    public static bool attack = true;
    public float speed = 1.0f;
    Rigidbody2D r2d;
    void Start()
    {

    }

    public void MoveTo(Vector3 position)
    {
        CharacterPosition = position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        CharacterPosition = CharacterMovement.Position;
        Ymove = CharacterMovement.YmoveDirection;
        Xmove = CharacterMovement.XmoveDirection;
        //The following make the damage are be in the direction the player is facing
        if (Xmove == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, CharacterPosition + new Vector3(0.0f, 0.5f, 0.0f), 10000000f);
        }
        if (Xmove == -1)
        {
            transform.position = Vector3.MoveTowards(transform.position, CharacterPosition + new Vector3(0.0f, -0.5f, 0.0f), 10000000f);
        }
        if (Ymove == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, CharacterPosition + new Vector3(0.5f, 0.0f, 0.0f), 10000000f);
        }
        if (Ymove == -1)
        {
            transform.position = Vector3.MoveTowards(transform.position, CharacterPosition + new Vector3(-0.5f, 0.0f, 0.0f), 10000000f);
        }
    }

    private void Attack() //Makes the collider do damage
    {

    }
}
