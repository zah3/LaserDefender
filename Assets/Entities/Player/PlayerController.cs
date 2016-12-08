﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;
	public float padding = 1.0f;
	
	float xmin =-5;
	float xmax = 5;
	
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0, distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
	}
	
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left * speed * Time.deltaTime;
		}else if(Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
		//restrict player to game space
		float newX = Mathf.Clamp(transform.position.x,xmin,xmax);
		transform.position = new Vector3(newX,transform.position.y, transform.position.z);
	}
}
