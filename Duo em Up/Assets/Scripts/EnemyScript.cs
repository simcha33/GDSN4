using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private EnemyClasses enemyClasses;
    string _enemyName;
    Colors _color;
    float _movementSpeed;
    float _stayingTime;
    float _damage;
    float _health;
    public int _materialColor;
    Material _material;
    Renderer rend;


    public int index;

    private void Start()
    {
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
        Debug.Log(_material.name);
    }
}
