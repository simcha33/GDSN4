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
        StartCoroutine(Destroy());
    }

    IEnumerator EnemyMove()
    {
        yield return transform.DOPath(enemyScript.wayPointVector3.ToArray(), enemyScript._movementSpeed, PathType.CubicBezier, PathMode.Ignore);
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(enemyScript._movementSpeed);
        Destroy(this.gameObject);
    }
}
