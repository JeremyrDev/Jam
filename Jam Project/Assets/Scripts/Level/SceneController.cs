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

	public float houseFoodLevel = 100;
	int houseFoodCapacity = 100;
	int numberOfSheep = 20;
	int cycle = 0;

	float spawnTimer = 0;
	float timerLimit = 1;
	float grannyCookTimer = 0;
	public float grannyCookRate = 2;
	public float grannyCookAmount = 5;

	string info;

	public GUIStyle infoStyle;

	public TextMesh grannyFoodAddedText;

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
		info = "Spawn: " + spawnTimer + "\n" + "Food level: " + houseFoodLevel.ToString("f0")
			+"\n Granny Cooking Timer: "+grannyCookTimer+"\n Spawn Cycle: "+cycle;

		grannyCookTimer+=1*Time.deltaTime;
		if(grannyCookTimer >= grannyCookRate)
		{
			grannyCookTimer = 0;
			houseFoodLevel+=grannyCookAmount;
			//animate granny text up from house with amount added
		}


		spawnTimer += 1*Time.deltaTime;
		if(spawnTimer > timerLimit)
		{
			spawnTimer = 0;
			spawnAnimal("s");

			if(cycle == 0)
				timerLimit = .5f;

			if(cycle == 5)
				timerLimit = 2;
			if(cycle == 8)
				timerLimit = .9f;
			cycle++;
			if(cycle == 15)
			{
				cycle = 0;
				timerLimit = 2;
			}
		}
		if(houseFoodLevel <= 0)
		{
			info = "Game Over!";
			//Time.timeScale = 0;
		}

		if (Input.GetMouseButton(0)) 
		{
			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			Debug.DrawRay(ray.origin, ray.direction * 100, Color.blue);
			
			if (Physics.Raycast ( ray.origin, ray.direction, out hit, 1000 )) 
			{
				if(hit.collider.tag == "t" || hit.collider.tag == "t2")
				{
					//selectedTower = hit.collider.gameObject;
				}
				else if(hit.collider.tag == "Ground")
				{
//					spawnPosition = new Vector3(ray.origin.x, 1.54f, ray.origin.z);
//					if(!gotTower)
//						if(spawnObject == t)
//							spawnTower(0);
//					else if(spawnObject == t2)
//						spawnTower (1);
				}
				Debug.Log(hit.collider.tag);
			}

			//spawnPosition = new Vector3(ray.origin.x, 1.54f, ray.origin.z);
			//selectedTower.transform.position = spawnPosition;
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
					sheep[i].transform.position = new Vector3(-25.2f, 1f, Random.Range(6.5f, 10.5f));
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
					sheep[i+1].transform.position = new Vector3(-25.2f, 1f, Random.Range(6.5f, 10.5f));
					return;
				}
			}
		}
	}
}
