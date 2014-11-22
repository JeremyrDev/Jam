using UnityEngine;
using System.Collections;

public class backScript : MonoBehaviour {

	public GameObject start;
	public GameObject exit;
	public GameObject info;
	public GameObject highscore;
	void OnMouseDown()
	{
		start.SetActive(true);
		exit.SetActive(true);
		info.SetActive(false);
		highscore.SetActive(true);
		gameObject.SetActive(false);
	}
}
