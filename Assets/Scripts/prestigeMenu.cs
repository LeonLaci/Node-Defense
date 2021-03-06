﻿using UnityEngine;
using UnityEngine.UI;

public class prestigeMenu : MonoBehaviour {

	[Header ("Buttons")]
	public Button prestigeButton;

	[Header ("Prestige Text Setup")]
	public GameObject prestigeGO;
	public buffText[] prestigeTexts;

	[Header ("Colors")]
	public Color activeColor;
	public Color inactiveColor;

	private int levelsNeededToPrestige = 30;

	//Sets up the texts automatically instead of having to input the texts manually
	void Awake(){
		Transform[] tempTexts = new Transform[prestigeGO.transform.childCount];

		for (int i = 0; i < tempTexts.Length; i++) {
			tempTexts [i] = prestigeGO.transform.GetChild (i);
		}

		//Get the texts into the prestige texts list automatically
		for(int i = 0; i < tempTexts.Length; i++) {
			prestigeTexts[i].text = tempTexts[i].gameObject.GetComponent<Text> ();
		}
	}

    // Called when this game object is enabled/set active
	void OnEnable(){
		setActivePrestigeLabels ();
	}

	// Use this for initialization
	void Start () {
        // Make the prestige button uninteractable
		prestigeButton.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerStats.current.getLevel () >= levelsNeededToPrestige) //Only make the prestige button interactive if the player is above the required level
			prestigeButton.interactable = true;
		else
			prestigeButton.interactable = false;
	}

	//Add a prestige point to the player
	public void prestige(){
		playerStats.current = new playerStats (playerStats.current);
		setActivePrestigeLabels ();
	}

	//Lets the user know which buffs are active by changing their color
	void setActivePrestigeLabels(){
		//int count = 0;
		foreach (buffText t in prestigeTexts) {
			if (playerStats.current.getPrestige () >= t.cost) {
				t.text.color = activeColor;
				//playerStats.current.activateBuffs (treeIndex, count);
			} else {
				t.text.color = inactiveColor;
				//playerStats.current.deactivateBuffs (treeIndex, count);
			}
			//count++;
		}
	}
}
