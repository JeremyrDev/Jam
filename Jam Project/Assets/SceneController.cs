using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SceneController : MonoBehaviour 
{
	//Object pool
	public GameObject s;
	List<GameObject> sheep;

	//Parent objects
	public GameObject Sheep;
	public GameObject Cow;
	public GameObject Goat;

	public int houseFoodLevel = 100;
	int houseFoodCapacity = 100;
	int numberOfSheep = 20;

	float spawnTimer = 0;
	float timerLimit = 1;

	string info;

	public GUIStyle infoStyle;

	void OnGUI()
	{
		GUI.Label (new Rect (0,0,100,50), info, infoStyle);
	}

	void Start () 
	{
		sheep = new List<GameObject>();
		
		for(int i = 0; i < numberOfSheep; i++)
		{
			GameObject obj = (GameObject)Instantiate(s);
			obj.SetActive(false);
			obj.name = "sheep"+i;
			obj.transform.parent = Sheep.transform;
			sheep.Add(obj); 
		}
	}

	void Update () 
	{
		info = "Spawn: " + spawnTimer + "\n" + "Food level: " + houseFoodLevel;
		spawnTimer += 1*Time.deltaTime;
		if(spawnTimer > timerLimit)
		{
			spawnTimer = 0;
			spawnAnimal("s");
		}
		if(houseFoodLevel <= 0)
		{
			info = "Game Over!";
			Time.timeScale = 0;
		}
	}
	public void spawnAnimal(string type)
	{
		if(type == "s")
		{
			int counter = 0;
			for(int i = 0; i < numberOfSheep;i++)
			{
				if(!sheep[i].activeInHierarchy)
				{
					sheep[i].transform.position = new Vector3(-21.2f, 1f, Random.Range(7.1f, 9f));
					sheep[i].SetActive(true);
					return;
				}
				counter++;
				if(counter == numberOfSheep)
				{
					GameObject obj = (GameObject)Instantiate(s);
					obj.SetActive(true);
					obj.name = "sheep"+(i+1);
					obj.transform.parent = Sheep.transform;
					sheep.Add(obj);
					numberOfSheep++;
					sheep[i+1].transform.position = new Vector3(-21.2f, 1f, Random.Range(7.1f, 9f));
					return;
				}
			}
		}
	}
}
