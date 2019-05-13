using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LinearMove : MonoBehaviour
{
    EnemyScript enemyScript;

    public void Awake()
    {
        enemyScript = GetComponent<EnemyScript>();
        StartCoroutine(EnemyMove());
    }

    IEnumerator EnemyMove()
    {
        yield return transform.DOPath(enemyScript.wayPointVector3.ToArray(), enemyScript._movementSpeed, PathType.Linear, PathMode.Ignore);
    }

}
