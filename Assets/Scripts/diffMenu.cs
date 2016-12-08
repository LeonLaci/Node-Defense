﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class diffMenu : MonoBehaviour {

	//Multiplier values for experience gains after a game ends
	public static float easyEnemyMult = 0.3f, easyMapMult = 0.8f, medEnemyMult = 0.7f, medMapMult = 1f, hardEnemyMult = 1f, hardMapMult = 1.2f;

	[Header ("Buttons")]
	public Button start;
	public Button medEnemy, medMap;
	public Button hardEnemy, hardMap;

	[Header ("Text")]
	public Text bonusText;

	[Header ("Values")]
	public int medUnlock;
	public int hardUnlock;

	//private int bonusVal = ;

	void Update(){

		if (gameStats.enemyDiff >= 0 && gameStats.mapDiff >= 0)
			bonusText.text = (gameStats.enemyDiff * gameStats.mapDiff * 100).ToString () + "%";
		else
			bonusText.text = "0%";

		//Don't allow the player to start unless they've selected a difficulty/map yet
		if (gameStats.enemyDiff >= 0 && gameStats.mapDiff >= 0) {
			start.enabled = true;
		} else {
			start.enabled = false;
		}

		//Unlocks medium and hard difficulties at certain levels
		if (playerStats.current.getLevel () >= hardUnlock) {
			medEnemy.interactable = true;
			medMap.interactable = true;
			hardEnemy.interactable = true;
			hardMap.interactable = true;
		} else if (playerStats.current.getLevel () >= medUnlock) {
			medEnemy.interactable = true;
			medMap.interactable = true;
			hardEnemy.interactable = false;
			hardMap.interactable = false;
		} else {
			medEnemy.interactable = false;
			medMap.interactable = false;
			hardEnemy.interactable = false;
			hardMap.interactable = false;
		}
	}

	public void startGame(){
		SceneManager.LoadScene (gameStats.mapDiffDelta);
	}

	public void changeMap(float diff){
		gameStats.setMapDiff(diff);
	}

	public void setEnemyDiff(float diff){
		gameStats.setEnemyDiff (diff);
	}

}
