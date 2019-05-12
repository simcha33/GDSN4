﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerShip : MonoBehaviour {

	Rigidbody rb; 

	int triggerDelay; 

	public int projectileCooldown; 
	public float hSpeed; 
	public float vSpeed;
    public float dragModifier;

	public float playerHealth;  
 

	public Text healthText; 

	public int playerNum;

	public float damageAmt; 

	public GameObject projectile; 

	public GameObject barrel;

	public LineRenderScript lineScript; 

	public bool combinedSingle; 

	public GameObject bulletSmall;
	public GameObject bulletBig;
	public Transform gunCombineSingle;
	public Transform gunCombineDouble1;
	public Transform gunCombineDouble2;

    private GameObject otherPlayer;
    private PlayerShip otherPlayerScript;

    public float xAxis;
    public float yAxis;

    public float xDrag;
    public float yDrag;

	public enum ShootingStyle
    {
        Regular,
        CombinedDouble,
        CombinedSingle
    }
    public ShootingStyle shootingStyle;
	void Awake(){
	
		rb=GetComponent<Rigidbody>(); 
		
		lineScript = GameObject.Find("LineRenderer").GetComponent<LineRenderScript>();

        

		if(playerNum == 1){
			barrel=transform.Find("barrelp1").gameObject; 
			gunCombineSingle = GameObject.Find("barrelCombinep1").GetComponent<Transform>();
			gunCombineDouble1 = barrel.transform;
			gunCombineDouble2 = GameObject.Find("barrelp2").GetComponent<Transform>();
            otherPlayer = GameObject.Find("p2");
		}
		if(playerNum == 2){
			barrel=transform.Find("barrelp2").gameObject; 
			gunCombineSingle = GameObject.Find("barrelCombinep2").GetComponent<Transform>();
			gunCombineDouble1 = barrel.transform;
			gunCombineDouble2 =  GameObject.Find("barrelp1").GetComponent<Transform>();
            otherPlayer = GameObject.Find("p1");
		}
        otherPlayerScript = otherPlayer.GetComponent<PlayerShip>();
    }

	void Update (){
		//movement
		if(playerNum==1){
		rb.AddForce(new Vector3(Input.GetAxisRaw("Horizontal")*hSpeed,0));  
		rb.AddForce(new Vector3(0, Input.GetAxisRaw("Vertical")*vSpeed));  
		}

		if (playerNum==2){
		rb.AddForce(new Vector3(Input.GetAxisRaw("Horizontal2")*hSpeed,0));  
		rb.AddForce(new Vector3(0, Input.GetAxisRaw("Vertical2")*vSpeed)); 
		}

		//shooting
		//if(Input.GetKey(KeyCode.L) && triggerDelay> projectileCooldown && playerNum == 1){
		//	Shoot(); 
		//}
		//else if(Input.GetButton("Fire1") && triggerDelay> projectileCooldown && playerNum == 2){
		//	Shoot(); 
		//}
		triggerDelay++; 

		healthText.text = "Health:" + playerHealth;
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        //style of shooting
		ShootingSyles(); 

        //magnet system
        if(lineScript.Totaldist <= 1.0f && lineScript.combined == true)
        {
            Magnetize();
            NoDrag();
        }
        else GetComponent<Rigidbody>().drag = 10;
        
    }

	public void TakeDamage(){
		playerHealth-=1; 
		//zelfde hier voor de speler als bij enemies eigenlijk

		if(playerHealth<=0){
			Destroy(gameObject);  
		}
	}
	void Shoot(){
		triggerDelay=0; 
		Instantiate(projectile, barrel.transform.position, Quaternion.identity); 
		playerProjectiles projectilescript = projectile.GetComponent<playerProjectiles>();
		projectilescript.Shooter = playerNum;
		
		//gameObject.GetComponent<playerProjectiles>().

	}

	void ShootingSyles(){

	switch (shootingStyle)
        {
            case ShootingStyle.Regular:  
			if(Input.GetKey(KeyCode.L) && triggerDelay> projectileCooldown && playerNum == 1){
				Shoot(); 
			}
			else if(Input.GetButton("Fire1") && triggerDelay> projectileCooldown && playerNum == 2){
				Shoot(); 
		}
                break;
            case ShootingStyle.CombinedDouble:
                if (Input.GetKey(KeyCode.L)&& triggerDelay> projectileCooldown && playerNum == 1 || Input.GetButton("Fire1") && triggerDelay> projectileCooldown && playerNum == 2)
                {
					triggerDelay=0; 
                    Rigidbody bulletInstance1;
                    bulletInstance1 = Instantiate(bulletSmall, gunCombineDouble1.position, gunCombineDouble1.rotation).GetComponent<Rigidbody>();
                    //bulletInstance1.AddForce(gunCombineDouble1.up * 300);
                    Rigidbody bulletInstance2;
                    bulletInstance2 = Instantiate(bulletSmall, gunCombineDouble2.position, gunCombineDouble2.rotation).GetComponent<Rigidbody>();
                   //bulletInstance2.AddForce(gunCombineDouble2.up * 300);
                    Debug.Log("DOUBLE BULLET");
                }
                break;
            case ShootingStyle.CombinedSingle:
                if (Input.GetKey(KeyCode.L)&& triggerDelay> projectileCooldown && playerNum == 1 || Input.GetButton("Fire1") && triggerDelay> projectileCooldown && playerNum == 2)
                {
					triggerDelay=0; 
                    Rigidbody bulletInstance;
                    bulletInstance = Instantiate(bulletBig, gunCombineSingle.position, gunCombineSingle.rotation).GetComponent<Rigidbody>();
                    //bulletInstance.AddForce(gunCombineSingle.up * 300);
                }
                break;
        }
	}

    void Magnetize()
    {
        
        GetComponent<Rigidbody>().drag = lineScript.Totaldist * dragModifier;
    }

    void NoDrag()
    {
        
        if (xAxis > 0 && otherPlayerScript.xAxis > 0 || xAxis < 0 && otherPlayerScript.xAxis < 0)
        {
            if(yAxis > 0 && otherPlayerScript.yAxis > 0 || yAxis < 0 && otherPlayerScript.yAxis < 0)
                GetComponent<Rigidbody>().drag = 10;
        }
        

        if (xAxis > 0 && otherPlayerScript.xAxis > 0 || xAxis < 0 && otherPlayerScript.xAxis < 0)
        {
           // if(yAxis > 0 && otherPlayerScript > 0.1f)
        }

        // if P1 gaat Links && P2 gaat Links doe dit
        // else P1 gaat links && P2 gaat rechts

    }
}
