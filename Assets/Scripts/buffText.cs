using UnityEngine.UI;

/*
* buffText
* Stores the text object of a buff as well as how many skill points it costs
* Used by the skillMenu/skillTree to show, visually, if a skill is activated to the user
*/

[System.Serializable]
public class buffText{

	public Text text;
	public int cost;

}
