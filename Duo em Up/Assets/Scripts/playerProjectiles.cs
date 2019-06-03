using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProjectiles : MonoBehaviour {

	Rigidbody rb; 
	int direction = 1; 
	public float travelSpeed;
    float damage;

    public GameObject hit;
    GameObject lRender;
    public LineRenderScript lRenderScript;


//public int shooter is an int that determines who shot the bullet
//0 is last man standing, 1 is player 1, 2 is player 2, 3 is enemy 1, 4 is enemy 2
	public int Shooter;

	void Awake(){
		rb=GetComponent<Rigidbody>();
        lRender = GameObject.Find("LineRenderer");
        if(lRender != null)
            lRenderScript = lRender.GetComponent<LineRenderScript>();

        if(lRenderScript == null)
        {
            damage = 5;
        }
	}
	public void changeDirection() {
		direction*=-1; 
	}

	void Update() {
		rb.velocity = new Vector3 (0, travelSpeed*direction, 0);
        if (lRenderScript != null)
        {
            damage = lRenderScript.damage;
        }
        else damage = 5;
	}

	//het is denk ik beter om de collision check in de speler te doen voor wanneer er meer soorten kogels komen. 
	void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "BulletKill")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag=="EnemyNeutral"){ //checked of de enemy is geraakt hier kunnen we de verschillende types enemies ingooien 
			//other.gameObject.GetComponent<NormaleEnemy>().TakeDamage();
            other.gameObject.GetComponent<EnemyScript>()._health -= damage;
            GameObject hitEffect = Instantiate(hit, this.transform.position, Quaternion.identity);
            Destroy(hitEffect, 1f);
            Destroy(gameObject);}

		else if(other.gameObject.tag=="EnemyRed" && (Shooter == 1 || Shooter == 0)){ //checked of de enemy is geraakt hier kunnen we de verschillende types enemies ingooien 
			//other.gameObject.GetComponent<NormaleEnemy>().TakeDamage();
            other.gameObject.GetComponent<EnemyScript>()._health -= damage;
            GameObject hitEffect = Instantiate(hit, this.transform.position, Quaternion.identity);
            Destroy(hitEffect, 1f);
            Debug.Log("redgoodhit"); 

			Destroy(gameObject);
		}
		else if(other.gameObject.tag=="EnemyRed" && Shooter == 2){
				//minscore 
				Debug.Log("Wrong color");
            other.gameObject.GetComponent<EnemyScript>().ShieldOn();
            if (other.gameObject.GetComponent<ShootingMethod>().style == ShootingMethod.ShootStyle.Balrog)
            {
                other.gameObject.GetComponent<ShootingMethod>().BerserkCounter();
            }
            Destroy(gameObject);
        }

		if(other.gameObject.tag=="EnemyBlue" && Shooter == 1){
				//minscore 
				Debug.Log("Wrong color");
            other.gameObject.GetComponent<EnemyScript>().ShieldOn();
            if(other.gameObject.GetComponent<ShootingMethod>().style == ShootingMethod.ShootStyle.Balrog)
            {
                other.gameObject.GetComponent<ShootingMethod>().BerserkCounter();
            }
            Destroy(gameObject);
        }

		else if(other.gameObject.tag=="EnemyBlue" && (Shooter == 2 || Shooter == 0)){ //checked of de enemy is geraakt hier kunnen we de verschillende types enemies ingooien 
			//other.gameObject.GetComponent<NormaleEnemy>().TakeDamage(); 
            other.gameObject.GetComponent<EnemyScript>()._health -= damage;
            GameObject hitEffect = Instantiate(hit, this.transform.position, Quaternion.identity);
            Destroy(hitEffect, 1f);
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


