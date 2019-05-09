using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private PowerUpClasses powerUpClasses; 

    public string _powerUpName;
    public GameObject _appearance;
    public float _movementSpeed;
    public float _deSpawnTime;

    //influencers 
    public float _healthChange;
    public float _damageChange; 
    public bool _tagChange; 

    public int index; 

    void Start()
    {
         powerUpClasses = GameObject.Find("Manager").GetComponent<PowerUpClasses>();    
         _powerUpName = powerUpClasses.PowerUpsList[index].powerUpName;
         _appearance = powerUpClasses.PowerUpsList[index].appearance; 
         _movementSpeed = powerUpClasses.PowerUpsList[index].movementSpeed; 
         _deSpawnTime = powerUpClasses.PowerUpsList[index].deSpawnTime; 
    }

    // Update is called once per frame
    void Update()
    {
        _deSpawnTime-=Time.deltaTime;
        if (_deSpawnTime <=0 ){ 
            DestroyStuff(); 
        }

        //variables from the class script    
    }

    void OnCollisionEnter(Collision other) {
        if ((other.gameObject.tag == "Player" && _deSpawnTime > 0) || (other.gameObject.tag == "Player Projectile" && _deSpawnTime > 0)) {
            ActivatePowerUp(); 
        }
    }

    void ActivatePowerUp(){
        Debug.Log("power up picked up"); 
        DestroyStuff(); 
    }

    void DestroyStuff(){
        Destroy(gameObject); 
    }
}
