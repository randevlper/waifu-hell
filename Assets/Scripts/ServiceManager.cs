using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceManager : MonoBehaviour {

	public static BulletManager bulletManager;
	public static GameManager gameManager;
	public static EnemyManager enemyManager;
	//public static Camera mainCamera;

	// Use this for initialization
	void Awake () {
		bulletManager = GetComponent<BulletManager>();
		gameManager = GetComponent<GameManager>();
		enemyManager = GetComponent<EnemyManager>();
		DontDestroyOnLoad(gameObject);
	}
}
