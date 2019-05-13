using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PathMove : MonoBehaviour
{
    EnemyScript enemyScript;

    public void Awake()
    {
        enemyScript = GetComponent<EnemyScript>();
        StartCoroutine(EnemyMove());
    }

    IEnumerator EnemyMove()
    {
        yield return transform.DOPath(enemyScript.wayPointVector3.ToArray(), enemyScript._movementSpeed, PathType.CubicBezier, PathMode.Ignore);
    }

}
