using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement1 : MonoBehaviour
{
    //gosh dang verbles
    public Vector3 CharacterPosition;
    public float speed = 1.0f;
    private bool HurtZone = false;
    public static float FireRate = 1.0f;
    public static float NextFire;
    Rigidbody2D r2d;
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        r2d.freezeRotation = true;
    }

    public void MoveTo(Vector3 position)
    {
        CharacterPosition = position;
    }

    void Update()
    {
        CharacterPosition = CharacterMovement.Position;
        transform.position = Vector3.MoveTowards(transform.position, CharacterPosition, speed * Time.deltaTime);
        if (HurtZone == true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (NextFire < Time.time)
                {
                    NextFire = Time.time + FireRate;
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Weapon")
        {
            HurtZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Weapon")
        {
            HurtZone = false;
        }
    }
}

