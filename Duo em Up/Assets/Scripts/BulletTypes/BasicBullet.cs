using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    Rigidbody _rb;
    public GameObject player;
    Vector3 destination;

    public float travelSpeed;
  
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

      
        
        destination = new Vector3(0, -1 * travelSpeed, 0);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BulletKill")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("playergothit");
            other.gameObject.GetComponent<PlayerShip>().TakeDamage();
            Destroy(gameObject);
        }
    }


}
