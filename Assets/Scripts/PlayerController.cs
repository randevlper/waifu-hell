using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public Camera mainCamera;
    public CharacterHealth characterHealth;
    public Rigidbody2D rb2D;
    public Gun gun;
    public float speed;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        characterHealth.OnDamage = Damage;
        characterHealth.OnDeath = Death;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        PlayerInput();

        if (Input.GetButton("Fire1"))
        {
            gun.Shoot();
        }

        if( Input.GetKeyDown(KeyCode.Escape) && !(characterHealth.Health <= 0))
        {
            ServiceManager.instance.uiController.TogglePause();
        }
    }

    void PlayerInput()
    {
        Vector2 movementInput = Gold.InputManager.GetMovementAxis();
        rb2D.velocity = movementInput * speed;

        Vector2 pos = transform.position;

        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 bottomRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0));
        Vector3 topLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0));
        //Vector3 topRight =    mainCamera.ViewportToWorldPoint(new Vector3(1,1,0));

        pos.x = Mathf.Clamp(pos.x, bottomLeft.x, bottomRight.x);
        pos.y = Mathf.Clamp(pos.y, bottomLeft.y, topLeft.y);

        transform.position = pos;
    }

    void Damage(Gold.Interfaces.DamageData hit)
    {
        //Become immune for a few secconds
        characterHealth.canTakeDamage = false;
        characterHealth.DelaySetCanTakeDamage(1, true);
        
        //ServiceManager.enemyManager.KillAll();
        //Kill all on screen enemies
    }

    void Death()
    {
        characterHealth.canTakeDamage = false;
        ServiceManager.instance.uiController.TogglePause();
        //Lose a life
        //Respawn 
    }
}
