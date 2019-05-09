using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public enum Colors {colorless = 0, red = 1, blue = 2};
public class EnemyClasses : MonoBehaviour
{
    public List<Enemy> enemyList = new List<Enemy>();
    public GameObject[] enemies;    
}

[System.Serializable]
public class Enemy
{
    public string enemyName;
    public Colors color;
    public float movementSpeed;
    public float stayingTime;
    public float damage;
    public float health;
    public EnemySpawn enemySpawn;

}


