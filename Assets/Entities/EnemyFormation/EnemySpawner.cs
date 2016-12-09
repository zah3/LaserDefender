using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public GameObject enemyPrefab;
	public float width = 14f;
	public float hight = 6f;
	public float speed = 5f;
	private bool movingRight = true;
	private float xMax;
	private float xMin;
	
	
	// Use this for initialization
	void Start () {
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint( new Vector3(1,0, distanceToCamera));
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint( new Vector3(0,0, distanceToCamera));
		xMax = rightBoundary.x;
		xMin = leftBoundary.x;
		foreach (Transform child in transform){
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width,hight));	
	}
	
	// Update is called once per frame
	void Update () {
		if(movingRight){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		float rightEgdeOfFormation = transform.position.x +(0.5f*width);
		float leftEdgeOfFormation = transform.position.x -(0.5f*width);
		if(leftEdgeOfFormation < xMin ){
			movingRight = true;
		}else if(rightEgdeOfFormation > xMax){
			movingRight = false;
		}
	}
}
