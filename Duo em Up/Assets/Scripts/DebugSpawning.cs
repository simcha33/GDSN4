using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSpawning : MonoBehaviour
{

    public GameObject enemy;
    Vector3 place;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            place = new Vector3(0, 6, 0);
            Instantiate(enemy, place,Quaternion.identity);
        }
    }
}
