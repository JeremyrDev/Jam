using UnityEngine;
using System.Collections;

public class beltMovement : MonoBehaviour {
	
	public float scrollSpeed = .5f;

	void Start () 
	{
		
	}

	void Update () 
	{
		float offset = Time.time * scrollSpeed;
		renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
