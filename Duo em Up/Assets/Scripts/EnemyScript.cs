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
    public float _movementSpeed;
    float _stayingTime;
    float _damage;
    public float _health;
    int _materialColor;
    string _tagName;
    Material _material;
    Renderer rend;
    Rigidbody _rb;

    public GameObject shield;
    public ParticleSystem hit;


    public int index;

    //if you want the enemies to move over a path, add the waypoints on the path to this list
    //IMPORTANT: add waypoints in multiples of 3.
    public List<GameObject> wayPoints;
    public List<Vector3> wayPointVector3;
    public GameObject linearWayPoint;


    private void Awake()
    {
        //this is very important, dont touch it
        _rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        enemyClasses = GameObject.Find("Manager").GetComponent<EnemyClasses>();
        _enemyName = enemyClasses.enemyList[index].enemyName;
        _color = enemyClasses.enemyList[index].color;
        _movementSpeed = enemyClasses.enemyList[index].movementSpeed;
        _stayingTime = enemyClasses.enemyList[index].stayingTime;
        _damage = enemyClasses.enemyList[index].damage;
        _health = enemyClasses.enemyList[index].health;

        _materialColor = enemyClasses.enemyList[index].materialColor(_color);
        _material = enemyClasses.materialList[_materialColor];
        rend.material = _material;
        _tagName = enemyClasses.enemyList[index].tagName(_color);
        transform.gameObject.tag = _tagName;

        //MAYBE THE PROBLEM FOR LINEAR MOVEMENT LIES HERE
        foreach (GameObject waypoint in wayPoints)
        {
            Vector3 newWayPoint = new Vector3(waypoint.transform.position.x, waypoint.transform.position.y, 0);
            wayPointVector3.Add(newWayPoint);
        }
    }

    private void Update()
    {
        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void ShieldOn()
    {
        StartCoroutine(ShieldActivate());
    }

    IEnumerator ShieldActivate()
    {
        shield.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        shield.SetActive(false);
    }
}
