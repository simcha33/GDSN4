using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScroll : MonoBehaviour
{
    Rigidbody _rb;
    public float scrollSpeed; 

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _rb.velocity = -transform.up * scrollSpeed;
    }
}
