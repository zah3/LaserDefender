using UnityEngine;
using System.Collections;

public class EnemyFormation : MonoBehaviour {
	
	public float health = 150;
	public GameObject projectile;
	public float projectSpeed = 10;
	public float shotsPerSeconds = 0.5f;
	public int scoreValue = 150;
	private ScoreKeeper scoreKeeper;
	
	public AudioClip fireSound;
	public AudioClip deadSound;
	
	void Start(){
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	void Update(){
		float probability = Time.deltaTime * shotsPerSeconds;
		if(Random.value < probability){
			Fire ();
		}
	}
	void Fire(){
		Vector3 startPosition = transform.position + new Vector3(0,-1,0);
		GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
		missile.rigidbody2D.velocity = new Vector2(0,-projectSpeed);
		AudioSource.PlayClipAtPoint(fireSound, startPosition);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if(missile){
			health -= missile.GetDamage();
			missile.Hit();
			if(health <= 0){
				Die();
			}
		}	
		
	}
	void Die(){
		AudioSource.PlayClipAtPoint(deadSound, transform.position);
		Destroy(gameObject);
		scoreKeeper.Score(scoreValue);
	}
}
