using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LinearMove : MonoBehaviour
{
    EnemyScript enemyScript;
    public Vector3 destination;
    public SpawnPoint spawnScript;
    StrafeMovement strafeScript;

    public void Awake()
    {
        
        enemyScript = GetComponent<EnemyScript>();
        strafeScript = GetComponent<StrafeMovement>();
        StartCoroutine(EnemyMove());


    }

    IEnumerator EnemyMove()
    {
        yield return transform.DOPath(enemyScript.wayPointVector3.ToArray(), enemyScript._movementSpeed, PathType.Linear, PathMode.Ignore);
        yield return new WaitForSeconds(enemyScript._movementSpeed);
        ActivateStrafe();
    }
    
    void ActivateStrafe()
    {
        strafeScript.enabled = true;
    }
}
