using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormaleEnemy : MonoBehaviour {

	float xSpeed= 0; 
	public float ySpeed; 
	public float fireSpeed;

	public float hitPoints; 

	public bool canShoot; 

	public GameObject bullet; 

	public float damage; 


	Rigidbody rb; 

	void Awake() {
	rb=GetComponent<Rigidbody>(); 
	//damage = gameObject.GetComponent<LineRenderScript>().damage; 
	}

	void Start() {
		//xSpeed = Random.Range(-1.0f,1.0f);
		if(canShoot){
			InvokeRepeating("Shoot", fireSpeed, fireSpeed); 
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity=new Vector3(xSpeed, ySpeed *-1, 0); 
		//LineRenderScript lineRenderScript = gameObject.GetComponent<LineRenderScript>(); 
		//Debug.Log(damage);
		Debug.Log(hitPoints);  
	}

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag=="Player")
		{
			other.gameObject.GetComponent<PlayerShip>().TakeDamage();
			Die(); 
		}
		if(other.gameObject.tag == "Bounds"){
			Die(); 
		}
	}

	void Shoot(){
		GameObject temp  = (GameObject) Instantiate (bullet,transform.position, Quaternion.identity); 
		playerProjectiles projectilescript = bullet.GetComponent<playerProjectiles>();
		projectilescript.Shooter = 3;
		temp.GetComponent<playerProjectiles>().changeDirection(); 
	}

	public void TakeDamage(){
		
		//hitPoints-= gameObject.GetComponent<LineRenderScript>().damage; 

		hitPoints -= 1; 

		//hierin kan ik dan weer een if statement doen voor de afstand check. Dus if PlayerDistances (voorbeeld) tussen de 4 en 6 zit ofzo
		//doe dan zoveel dmg of we gebruiken het als een soort van multiplier 
		//If(playerDistace == This){
		//hitPoints-=2 	
		//	}
		//If(playerDistace == This){
		//hitPoints-=4	
		//	}

		if(hitPoints <=0 ){
			Die(); 
		}
	}
	void Die(){
		Destroy(gameObject); 
	}

}
