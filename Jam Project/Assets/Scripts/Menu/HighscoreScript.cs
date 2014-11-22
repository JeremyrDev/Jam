using UnityEngine;
using System.Collections;

public class HighscoreScript : MonoBehaviour {

	public GameObject start;
	public GameObject exit;
	public GameObject info;
	public GameObject back;

	bool show = false;

	void OnMouseDown()
	{
		if(!show)
		{
			start.SetActive(false);
			exit.SetActive(false);
			info.SetActive(true);
			back.SetActive(true);
			gameObject.SetActive(false);
		}
		else
		{
			start.SetActive(true);
			exit.SetActive(true);
			info.SetActive(false);
			back.SetActive(false);
			gameObject.SetActive(true);
		}
	}
}
