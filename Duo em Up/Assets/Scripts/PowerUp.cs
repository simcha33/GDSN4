using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public enum PowerUps{TagUp, HealthUp, LineUp};  

    public PowerUps powerUpSort; 

    private PowerUpClasses powerUpClasses; 

    public float deSpawnTime;
    public float effectTime = 20f; 

    public LineRenderScript lRenderScript;

    public int index; 

    private bool pickedUp = false; 

    private float healthPickUpAmt = 10; 

    public GameObject healthFx; 

    //public string _powerUpName;
   // public GameObject _appearance;
   // public float _movementSpeed;

    //influencers 
   // public float _healthChange;
   // public float _damageChange; 
  //  public bool _tagChange;
 

    void Start()
    {
        // powerUpClasses = GameObject.Find("Manager").GetComponent<PowerUpClasses>();    
       //  _powerUpName = powerUpClasses.PowerUpsList[index].powerUpName;
       //  _appearance = powerUpClasses.PowerUpsList[index].appearance; 
      //   _movementSpeed = powerUpClasses.PowerUpsList[index].movementSpeed; 
      //   _deSpawnTime = powerUpClasses.PowerUpsList[index].deSpawnTime; 
    }

    // Update is called once per frame
    void Update()
    {
        if(pickedUp==false)
            deSpawnTime-=Time.deltaTime;
        
       // Debug.Log(effectTime); 
       // Debug.Log(_deSpawnTime); 

        if (deSpawnTime <=0 ){ 
            DestroyStuff(); 
        }

        //variables from the class script    
    }

    void OnTriggerEnter(Collider other) {
        if ((other.gameObject.tag == "Player" && deSpawnTime > 0)) {
            StartCoroutine(ActivatePowerUp(other)); 
            pickedUp = true; 

        }
    }

    IEnumerator ActivatePowerUp(Collider Player){
        
        Debug.Log("power up picked up"); 
        GetComponent<MeshRenderer>().enabled = false; 
        GetComponent<Collider>().enabled = false;
        PowerUpKind(Player); 
        yield return new WaitForSeconds(effectTime); 
        DestroyStuff(); 
        ReverseEffect(); 
    }

    void PowerUpKind(Collider Player){

        PlayerShip stats = Player.GetComponent<PlayerShip>(); 

        //Selects a power up based on the enum kind 
        switch(powerUpSort)
            {
                 //the players health will increase with x amount 
                case PowerUps.HealthUp:   
                    if (powerUpSort == PowerUps.HealthUp)
                    {
                        if (stats.playerHealth < stats.maxPlayerHealth){
                        stats.playerHealth+=healthPickUpAmt; 
                        
                        Instantiate(healthFx, Player.transform.position, Quaternion.identity);
                        }
                        else if (stats.playerHealth >= stats.maxPlayerHealth){
                        stats.playerHealth = stats.maxPlayerHealth; 
                        }
                    }
                break; 

                //Player can hit both tags 
                case PowerUps.TagUp:
                    if (powerUpSort == PowerUps.TagUp)
                    {
                    Debug.Log("Nomoretagio"); 
                    }                 
                break; 

                //The line distance damage is maxed 
                 case PowerUps.LineUp:
                    if (powerUpSort == PowerUps.LineUp)
                    {
                    Debug.Log("tagsswitching"); 
                    lRenderScript.powerUpMode = true;
                    }                 
                break; 
        }
    }

    void ReverseEffect(){
    
        //Reverts the power up effect if needed 
        switch(powerUpSort)
            {  
                 case PowerUps.LineUp:
                    if (powerUpSort == PowerUps.LineUp)
                     lRenderScript.powerUpMode = false;
                                   
                break; 

                case PowerUps.TagUp:
                    if (powerUpSort == PowerUps.TagUp){}

                    break; 
    }
    }
        
    

    void DestroyStuff(){ 
       Destroy(gameObject); 
    }
}


//probleem oplossen waarbij een pick up opgepakt kan worden zelfs als dit niet hoort. Bijvoorbeeld een player is op max health en kan nog steeds health oppakken wat niks doet 