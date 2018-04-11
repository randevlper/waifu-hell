using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public CharacterHealth characterHealth;
    public Rigidbody2D rb2D;
    public Gun gun;
    public float speed;
    public int score;

    public float startingSpeed;

    // Use this for initialization
    void Start()
    {
        characterHealth.OnDeath = Death;
        rb2D.velocity = new Vector2(rb2D.velocity.x, startingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (gun != null)
        {
            gun.Shoot();
        }

    }

    void Death()
    {
        GameManager.Score += score;
        Destroy(gameObject);
    }
}
