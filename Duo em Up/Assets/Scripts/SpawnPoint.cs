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
    public List<GameObject> wayPoints;
    LinearMove linearMove = null;

    private void Awake()
    {
       

        linearMove = enemies[0].GetComponent<LinearMove>();
        
        if(linearMove != null)
        {
            //ok this is super weird, hear  me out:
            //I add waypoints to my enemies' lists, but they remember what was added during play sessions..... this shouldn't be happening...
            StartCoroutine(AddToList());
        }
        else if (linearMove == null)
        {
            foreach (GameObject enemy in enemies)
            {
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

    IEnumerator AddToList()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            
            enemies[i].GetComponent<EnemyScript>().wayPoints.Add(wayPoints[1]);
        }
        yield return null;
    }
}
