using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearSpawn : MonoBehaviour
{
    [Header("Only add 1 Enemy per Linear Spawner")]
    public GameObject enemies;
    Vector3 pos;

    public GameObject wayPoint;

    public float strafeTime;
    public float moveForce;

    private void Awake()
    {
        pos = this.transform.position;
        enemies.GetComponent<EnemyScript>().wayPoints = new List<GameObject>();
        enemies.GetComponent<EnemyScript>().wayPoints.Add(wayPoint);
        enemies.GetComponent<StrafeMovement>().strafeTime = strafeTime;
        enemies.GetComponent<StrafeMovement>().moveForce = moveForce;

    }

    void Start()
    {
        GameObject enemy = Instantiate(enemies, pos, Quaternion.identity);
    }

}
