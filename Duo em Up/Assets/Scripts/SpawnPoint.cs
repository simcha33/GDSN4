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

    private void Awake()
    {     
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyScript>().wayPoints = null;
            enemy.GetComponent<EnemyScript>().wayPoints = wayPoints;
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
 
}
