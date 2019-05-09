using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawn : MonoBehaviour {

    public EnemyClasses ecScript;
	public float spawnRate; 
	public GameObject[] enemies;
   
	private float leftEnd = -8.5f; 
	private float rightEnd = 8.5f; 
	private float SpawnHeight = 7.0f;

    public float healthGet;

	public int groups; 
	void Start () {

        ecScript = GetComponent<EnemyClasses>();

		InvokeRepeating("SpawnEnemy", spawnRate, spawnRate);
	}

    // Update is called once per frame
    void SpawnEnemy () {
		for(int i=0; i<groups; i++)
		Instantiate(enemies[(int)Random.Range(0,enemies.Length)], new Vector3(Random.Range(leftEnd, rightEnd), SpawnHeight), Quaternion.identity); 
	}
}
