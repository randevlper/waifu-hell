using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceManager : MonoBehaviour
{

    public static ServiceManager instance;

    public static BulletManager bulletManager;
    public static GameManager gameManager;
    public static EnemyManager enemyManager;
    public static LevelManager levelManager;
    public UIController uiController;
    //public static Camera mainCamera;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
			instance = this;
            bulletManager = GetComponent<BulletManager>();
            gameManager = GetComponent<GameManager>();
            enemyManager = GetComponent<EnemyManager>();
            levelManager = GetComponent<LevelManager>();
        }
		else
		{
			Destroy(gameObject);
		}
    }
}
