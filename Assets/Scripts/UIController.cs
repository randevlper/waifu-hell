using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	private void Awake()
	{
		PlayerController.instance.characterHealth.OnHealthChanged = SetHealth;
		GameManager.OnScoreChange = SetScore;
	}

	[SerializeField] private Text scoreText;
	public void SetScore(int score)
	{
		scoreText.text = score.ToString();
	}

	[SerializeField] private Text healthText;
	public void SetHealth(int health)
	{
		healthText.text = health.ToString();
	}
}
