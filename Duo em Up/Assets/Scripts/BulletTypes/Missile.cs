using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Renderer rend;
    Rigidbody _rb;

    public int target;
    public float travelSpeed;
    public float maxTravelSpeed;

    public GameObject player;

    public List<Material> materialList = new List<Material>();

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        rend.material = materialList[Mathf.Clamp(target, 0,1)];

        if (target == 0)
        {
            player = GameObject.Find("p1");
        }
        else player = GameObject.Find("p2");
    }


    private void Update()
    {
        transform.LookAt(player.transform);
        _rb.velocity = transform.forward * travelSpeed;

        travelSpeed += Time.deltaTime;
        if (travelSpeed >= maxTravelSpeed) travelSpeed = maxTravelSpeed;
    }
}
