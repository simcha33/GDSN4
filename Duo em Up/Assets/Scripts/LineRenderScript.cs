using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class LineRenderScript : MonoBehaviour 
{
	LineRenderer lRender;
    public Transform p1Transform;
    public Transform p2Transform;
	public Vector3 midLine;
    private GameObject player1;
    private GameObject player2;
    public PlayerShip player1Script;
    public PlayerShip player2Script;
	public GameObject magnetCol;
	private Vector3 magnetVect;
	private GameObject magnetClone;
	public bool combined;

    private float Xdist;
    private float Ydist;
    public float Totaldist;
    public float damage;

    private float minWidth = 1f;
    private float maxWidth = 7f;
    private float totalWidth;
    public float maxDist = 8;
    public float minDist = 1;
	public float magnetForce;
	public Text currentDamageLevel; 

    public bool powerUpMode = false; 

    private void Start()
    {
        lRender = GetComponent<LineRenderer>();
        player1 = GameObject.Find("p1");
        player2 = GameObject.Find("p2");
        p1Transform = player1.GetComponent<Transform>();
        p2Transform = player2.GetComponent<Transform>();
        player1Script = player1.GetComponent<PlayerShip>();
        player2Script = player2.GetComponent<PlayerShip>();
    }
    
    private void Update()
    {
        if(player1 == null || player2 == null)
        {
            Destroy(this.gameObject);
        }
		currentDamageLevel.text = "Damage Level: " + damage; 

		midLine = new Vector3((p1Transform.position.x+p2Transform.position.x)/2,(p1Transform.position.y+p2Transform.position.y)/2,2 );
        lRender.SetPosition(0 , p1Transform.position);
        lRender.SetPosition(1, p2Transform.position);

        Xdist = p1Transform.position.x - p2Transform.position.x;
        Ydist = p1Transform.position.y - p2Transform.position.y;

        if (Xdist < 0) Xdist = -Xdist;
        if (Ydist < 0) Ydist = -Ydist;
        Totaldist = Mathf.Sqrt(Mathf.Pow(Xdist, 2) + Mathf.Pow(Ydist, 2));

        lRender.startWidth = Mathf.Clamp((((maxWidth - minWidth) / (maxDist - minDist))/Totaldist), minWidth/10, maxWidth/10);
        lRender.endWidth = Mathf.Clamp((((maxWidth - minWidth) / (maxDist - minDist)) / Totaldist), minWidth/10, maxWidth/10);
 
        if(powerUpMode == false){
        if (Totaldist < 8 && Totaldist > 7) damage = 1;
        else if (Totaldist < 7 && Totaldist > 5) damage = 2;
        else if (Totaldist < 5 && Totaldist > 3) damage = 3;
        else if (Totaldist < 3 && Totaldist > 0 && combined == false) damage = 4;
        else if (Totaldist > 8) damage = 1;
        }
        else if (powerUpMode == true){
            damage = 5; 
        }
		
        if (Totaldist <= 1.0f && !Input.GetKey("p")) Combine();
        else
        {
            player1Script.combinedSingle = false;
            player2Script.combinedSingle = false;
            player1Script.shootingStyle = PlayerShip.ShootingStyle.Regular;
            player2Script.shootingStyle = PlayerShip.ShootingStyle.Regular;
			combined = false;
			Destroy(magnetClone);
        }
		if(magnetClone != null) MoveMagnet();  
    }

    public void Combine()
    {
        if (combined == false)
        {
            player1Script.combinedSingle = true;
            player1Script.shootingStyle = PlayerShip.ShootingStyle.CombinedSingle;
            player2Script.combinedSingle = true;
            player2Script.shootingStyle = PlayerShip.ShootingStyle.CombinedSingle;
            damage = 5;
			Magnetize();			
        }
        lRender.startWidth = 0;
        lRender.endWidth = 0;
    }

	public void Magnetize(){
		combined = true; 
		magnetClone = Instantiate(magnetCol, midLine, Quaternion.identity); 
	}

	public void MoveMagnet(){
		magnetClone.GetComponent<Transform>().position = midLine;
	}
}
