using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public GameObject spawnPoint;

    void Awake()
    {
        spawnPoint = transform.Find("Spawner").gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reader")
        {
            Debug.Log("Spawn");
            spawnPoint.SetActive(true);
        }
    }

}
