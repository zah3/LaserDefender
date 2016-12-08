using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public GameObject enemyPrefab;
	public float width = 10f;
	public float hight = 3f;
	
	
	// Use this for initialization
	void Start () {
		foreach (Transform child in transform){
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	public void OnDrowGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, hight));	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
