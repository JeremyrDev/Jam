using UnityEngine;
using System.Collections;

public class SheepScript : MonoBehaviour 
{
	Vector3 endPos;
	
	public float maxHealth = 100;
	public float health = 100;
	float speed = 10;
	float spawnTimer = 0;
	
	int wayPointCounter = 0;
	
	
	public bool target = false;
	
	//public Material enemy;
	//public Material enemyTarget;
	
	public GameObject c;
	//public GameObject healthBar;
	
	SceneController sc;
	
	void OnEnable()
	{
		wayPointCounter = 0;
		transform.position = new Vector3(-21.2f, 1f, Random.Range(7.1f, 9f));
		endPos = new Vector3(-17.1f, 1f, 8.1f);
		maxHealth+=10;
		health = maxHealth;
		//healthBar.transform.localScale = new Vector3(.1f, .14f, .009f);
	}

	void Start () 
	{
		c = GameObject.Find("Camera");
		sc = c.GetComponent<SceneController>();
		transform.position = new Vector3(-21.2f, 1f, Random.Range(7.1f, 9f));
		endPos = new Vector3(-17.1f, 1f, 8.1f);
	}

	public void ApplyDamage(float damage)
	{
		health-=damage;
	}

	void Update () 
	{
		float h = health/maxHealth;
		
		//healthBar.transform.localScale = new Vector3(h/10, .14f, .009f);
		
		if(health <=0){
			gameObject.SetActive(false);
			//sc.killCounter++;
		}
		
		transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime * speed);
		//rotate towards waypoint
		transform.LookAt(endPos);
		if(wayPointCounter == 0){
			if(transform.position == endPos)
			{
				wayPointCounter++;
				endPos = new Vector3(.23f, 1f, 8.1f);

			}
		}
		if(wayPointCounter == 1){
			if(transform.position == endPos)
			{
				wayPointCounter++;
				endPos = new Vector3(.23f, 1f, -.86f);
			}
		}
		if(wayPointCounter == 2){
			if(transform.position == endPos)
			{
				wayPointCounter++;
				endPos = new Vector3(-9.1f, 1f, -.86f);
			}
		}
		if(wayPointCounter == 3){
			if(transform.position == endPos)
			{
				wayPointCounter++;
				endPos = new Vector3(-9.1f, 1f, 4.3f);
			}
		}
		if(wayPointCounter == 4){
			if(transform.position == endPos)
			{
				wayPointCounter++;
				endPos = new Vector3(-16.4f, 1f, 4.3f);
			}
		}
		if(wayPointCounter == 5){
			if(transform.position == endPos)
			{
				wayPointCounter++;
				endPos = new Vector3(-16.4f, 1f, -6.1f);
			}
		}
		if(wayPointCounter == 6){
			if(transform.position == endPos)
			{
				wayPointCounter++;
				endPos = new Vector3(7.7f, 1f, -6.1f);
			}
		}
		if(wayPointCounter == 7){
			if(transform.position == endPos)
			{
				wayPointCounter++;
				endPos = new Vector3(7.7f, 1f, 4.5f);
			}
		}
		if(wayPointCounter == 8){
			if(transform.position == endPos)
			{
				wayPointCounter++;
				endPos = new Vector3(13.6f, 1f, Random.Range(3.5f, 5.5f));
			}
		}
		if(wayPointCounter == 9){
			if(transform.position == endPos)
			{
				//decrease house food capacity

				sc.houseFoodLevel--;

				//gameObject.SetActive(false);
			}
		}
	}
}
