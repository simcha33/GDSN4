using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProjectiles : MonoBehaviour {

	Rigidbody rb; 
	int direction = 1; 
	public float travelSpeed; 

//public int shooter is an int that determines who shot the bullet
//0 is nothing, 1 is player 1, 2 is player 2, 3 is enemy 1, 4 is enemy 2
	public int Shooter;

	void Awake(){
		rb=GetComponent<Rigidbody>(); 
	}
	public void changeDirection() {
		direction*=-1; 
	}

	void Update() {
		rb.velocity = new Vector3 (0, travelSpeed*direction, 0); 
	}

	//het is denk ik beter om de collision check in de speler te doen voor wanneer er meer soorten kogels komen. 
	void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "BulletKill")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag=="EnemyNeutral"){ //checked of de enemy is geraakt hier kunnen we de verschillende types enemies ingooien 
			//other.gameObject.GetComponent<NormaleEnemy>().TakeDamage();
            other.gameObject.GetComponent<EnemyScript>()._health -= 1;
            Destroy(gameObject);}

		else if(other.gameObject.tag=="EnemyRed" && Shooter == 1){ //checked of de enemy is geraakt hier kunnen we de verschillende types enemies ingooien 
			other.gameObject.GetComponent<NormaleEnemy>().TakeDamage(); 
			Debug.Log("redgoodhit"); 
			Destroy(gameObject);
		}
		else if(other.gameObject.tag=="EnemyRed" && Shooter == 2){
				//minscore 
				Debug.Log("Wrong color"); 
			}

		if(other.gameObject.tag=="EnemyBlue" && Shooter == 1){
				//minscore 
				Debug.Log("Wrong color"); 
			}

		else if(other.gameObject.tag=="EnemyBlue" && Shooter == 2){ //checked of de enemy is geraakt hier kunnen we de verschillende types enemies ingooien 
			other.gameObject.GetComponent<NormaleEnemy>().TakeDamage(); 
			Destroy(gameObject);
		}
		
		if(other.gameObject.tag=="Player"){  
			Debug.Log("playergothit");
			other.gameObject.GetComponent<PlayerShip>().TakeDamage(); 
			Destroy(gameObject); 		 
		}	

			if(other.gameObject.tag == "Bounds"){
			Destroy(gameObject); 
			}
	}


    //void OnCollisionEnter(Collision other){
    //	if(other.gameObject.tag == "Bounds"){
    //			Destroy(gameObject); 
    ///	}
    //}
}


