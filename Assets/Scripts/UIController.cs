using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	private void Awake()
	{
		PlayerController.instance.characterHealth.OnHealthChanged = SetHealth;
		GameManager.OnScoreChange = SetScore;
		pauseMenu.SetActive(false);
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
	
	[SerializeField] private GameObject pauseMenu;
	bool isPaused;
	public void TogglePause()
	{
		if(isPaused)
		{
			pauseMenu.SetActive(false);
			Time.timeScale = 1;
		}
		else
		{
			pauseMenu.SetActive(true);
			Time.timeScale = 0;
		}
	}
}
