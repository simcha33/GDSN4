using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StrafeMovement : MonoBehaviour
{
    public float strafeTime;
    Rigidbody _rb;
    public float moveForce;
    public float timer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        _rb.AddForce(-moveForce, 0, 0);

        if(timer >= strafeTime)
        {
            timer = 0;
            moveForce = -moveForce;
        }
    }


    IEnumerator StrafeLeft()
    {
        
        Debug.Log("GoingLeft");
        _rb.AddForce(-1 * moveForce, 0, 0);
        yield return new WaitForSeconds(strafeTime);
    }

    IEnumerator StrafeRight()
    {
        
        Debug.Log("GoingRight");
        _rb.AddForce(1 * moveForce, 0, 0);
        yield return new WaitForSeconds(strafeTime);
    }

}
