﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public Text Score_UIText;
	public Text Level_UIText;
	public Text LevelStars_UIText;
	public static int levelTracker = 1;
	private GameObject refLevelTest;
	private Object[] itemsToInstantiate;
	// private PlayerMovement refPlayerTest; not used because i only wanna access static movesCount

	// Use this for initialization
	void Awake () {
		if (SceneManager.GetActiveScene ().name == "Main") {
			Instantiate (Resources.Load<GameObject> ("background"));
		} else if (SceneManager.GetActiveScene ().name == "Level1") {
			InstantiateLevel("Default");
			levelTracker = 1;
		} else if (SceneManager.GetActiveScene ().name == "Level2") {
			InstantiateLevel("Default");
			InstantiateLevel("Level2");
			levelTracker = 2;
		} else if (SceneManager.GetActiveScene ().name == "Level3") {
			InstantiateLevel("Default");
			InstantiateLevel("Level3");
			levelTracker = 3;
		} else if (SceneManager.GetActiveScene ().name == "Level4") {
			InstantiateLevel("Default");
			InstantiateLevel("Level4");
			levelTracker = 4;
		}else {
			Instantiate(Resources.Load<GameObject>("background"));
		}
	}
		
	void InstantiateLevel(string toInstantiate) {
		itemsToInstantiate = Resources.LoadAll(toInstantiate);
		foreach (var a in itemsToInstantiate) {
			Instantiate(a);
		}
	}

	void Update() {
		Score_UIText.text = PlayerMovement.movesCount.ToString() + " moves left";
		Level_UIText.text = "Level " + levelTracker.ToString();
		if (Input.GetKeyDown (KeyCode.V)){
			SceneManager.LoadScene ("Main");
			levelTracker = 1;
			PlayerMovement.movesCount = 3;
		}
	}

	public void GameOver() {
		SceneManager.LoadScene ("Main");
		levelTracker = 1;
	}

	public void LevelPassed() {
		levelTracker+=1;
		SceneManager.LoadScene ("Level" + levelTracker.ToString());
		PlayerMovement.movesCount = 3;
	}
}
