using UnityEngine;
using System.Collections;

public class infoTextScript : MonoBehaviour 
{
	public TextMesh info;

	void OnEnable()
	{
		info.text = PlayerPrefs.GetFloat("Highscore").ToString();
		if(PlayerPrefs.GetFloat("Highscore") == 0 || PlayerPrefs.GetFloat("Highscore") == null)
			info.text = "Nothing here yet!";
	}
}
