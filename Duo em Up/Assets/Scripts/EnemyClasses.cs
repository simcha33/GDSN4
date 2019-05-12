using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public enum Colors { colorless = 0, red = 1, blue = 2 };
public class EnemyClasses : MonoBehaviour
{
    public List<Enemy> enemyList = new List<Enemy>();
    public List<Material> materialList;
}

[System.Serializable]
public class Enemy
{
    public string enemyName;
    public Colors color;
    //IMPORTANT since the movement speed for now is used as the time it takes for the movement animation to complete...
    //...the lower the movement speed, the faster the enemy will move
    public float movementSpeed;
    public float stayingTime;
    public float damage;
    public float health;

    public int materialColor(Colors color)
    {
        if (color == Colors.colorless) return 0;
        if (color == Colors.red) return 1;
        if (color == Colors.blue) return 2;
        else return 0;

    }

}


