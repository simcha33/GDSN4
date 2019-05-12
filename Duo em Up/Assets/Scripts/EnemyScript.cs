using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyScript : MonoBehaviour
{
    //this is all imported from the EnemyClasses script
    private EnemyClasses enemyClasses;
    string _enemyName;
    Colors _color;
    float _movementSpeed;
    float _stayingTime;
    float _damage;
    float _health;
    int _materialColor;
    Material _material;
    Renderer rend;
    Rigidbody _rb;

    
    public int index;
    //location in the map the enemy will move towards after spwaning
    //if you want the enenmy
    public GameObject moveDest;
    Vector3 _moveDest;

    //if you want the enemies to move over a path, add the waypoints on the path to this list
    //IMPORTANT: add waypoints in multiples of 3.
    public List<GameObject> wayPoints;
    public List<Vector3> wayPointVector3;


    private void Start()
    {
        
        _rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        enemyClasses = GameObject.Find("Manager").GetComponent<EnemyClasses>();
        _enemyName = enemyClasses.enemyList[index].enemyName;
        _color = enemyClasses.enemyList[index].color; ;
        _movementSpeed = enemyClasses.enemyList[index].movementSpeed;
        _stayingTime = enemyClasses.enemyList[index].stayingTime;
        _damage = enemyClasses.enemyList[index].damage;
        _health = enemyClasses.enemyList[index].health;

        _materialColor = enemyClasses.enemyList[index].materialColor(_color);
        _material = enemyClasses.materialList[_materialColor];
        rend.material = _material;
        _moveDest = new Vector3(moveDest.transform.position.x, moveDest.transform.position.y, 0);

        StartCoroutine(EnemyPath());

        foreach(GameObject waypoint in wayPoints)
        {
            Vector3 newWayPoint = new Vector3(waypoint.transform.position.x,waypoint.transform.position.y,0);
            wayPointVector3.Add(newWayPoint);
        }
        StartCoroutine(EnemyPath());
    }

    IEnumerator EnemyMovement()
    {
        yield return transform.DOMove(_moveDest, _movementSpeed);
    }

    
    IEnumerator EnemyPath()
    {
        yield return transform.DOPath(wayPointVector3.ToArray(), _movementSpeed, PathType.Linear, PathMode.Ignore);
    }
    
}
