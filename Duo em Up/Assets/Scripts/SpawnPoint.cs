using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [Header("List of Enemies")]
    public List<GameObject> enemies;
    public float spawnRate;
    Vector3 pos;

    [Header("List of Movement Waypoints")]
    public List<GameObject> wayPoints = new List<GameObject>();
    LinearMove linearMove = null;

    private void Awake()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyScript>().wayPoints = null;
        }

        if (enemies[0].GetComponent<LinearMove>() == true)
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<EnemyScript>().wayPoints = null;
                enemy.GetComponent<EnemyScript>().wayPoints = wayPoints;
            }
            //insert code that sets the destination for the enemies using Linear Move here
            //except this one doesnt work for some ungodly reason!!!!!!!!!!!!!!!!!!!
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].GetComponent<LinearMove>().destination = wayPoints[i].transform.position;
            }
            
        }
        else
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<EnemyScript>().wayPoints = null;
                enemy.GetComponent<EnemyScript>().wayPoints = wayPoints;
            }
        }
     

    }

    void Start()
    {
        StartCoroutine(SpawnEnemies()); 
    }

   IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            pos = this.transform.position;
            GameObject enemy = Instantiate(enemies[i], pos, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }

    IEnumerator SetDestination()
    {
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].GetComponent<LinearMove>().destination = wayPoints[i].transform.position;
        }
    }

 
}
