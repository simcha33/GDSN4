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

        if (player != null)
            transform.LookAt(player.transform);
        
        destination = new Vector3(0, -1 * travelSpeed, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            _rb.velocity = transform.forward * travelSpeed;
        else _rb.velocity = -transform.up * travelSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BulletKill")
        {
            Destroy(this.gameObject);
        }
    }


}
