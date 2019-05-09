using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;


public class PowerUpClasses : MonoBehaviour
{
    public List<PowerUpsList> PowerUpsList;
    
}

[System.Serializable]
public class PowerUpsList
{
    public string powerUpName;
    public GameObject appearance; 
    public float movementSpeed; //how fast the item moves through the envoriment
    public float deSpawnTime; //how long it takes for the item to despawn
    public float effectTime; //how long does the powerup effect last 

    //influencers 
    public float healthChange;
    public float damageChange; 
    public bool tagChange; 
}




