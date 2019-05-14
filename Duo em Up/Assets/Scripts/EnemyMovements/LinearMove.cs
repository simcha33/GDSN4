using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LinearMove : MonoBehaviour
{
    EnemyScript enemyScript;
    Rigidbody _rb;
    public Vector3 destination;
    public SpawnPoint spawnScript;

    public void Awake()
    {
        
        enemyScript = GetComponent<EnemyScript>();
        _rb = GetComponent<Rigidbody>();
    }

    void MoveToward()
    {
       // _rb.velocity = destination;
    }

}
