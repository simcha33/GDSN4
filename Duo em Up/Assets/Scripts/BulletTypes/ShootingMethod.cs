using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMethod : MonoBehaviour
{
    public enum ShootStyle
    {
        RepeatingFire,
        AnotherOne
    }

    public float fireRate;
    public float fireDelay;
    public GameObject bulletPrefab;
    public int bulletAmount;
    public ShootStyle style;
    Vector3 pos;

    BasicBullet bulletScript;

    public int target;

    private void Awake()
    {
        if (style == ShootStyle.RepeatingFire)
        {
            InvokeRepeating("BasicFire", 3.0f, fireDelay);
        }
    }

    private void Update()
    {
        if(style == ShootStyle.RepeatingFire)
        {
            
        }
    }



    IEnumerator RepeatingFire()
    {
        target = Random.Range(1, 3);
        for(int i = 0; i < bulletAmount; i++)
        {
            pos = this.transform.position;
            GameObject bullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
            bulletScript = bullet.GetComponent<BasicBullet>();
            if (target == 1)
                bulletScript.player = GameObject.Find("p1");
            else if (target == 2)
                bulletScript.player = GameObject.Find("p2");
            else bulletScript.player = null;

            yield return new WaitForSeconds(fireRate);

        }
    }

    void BasicFire()
    {
        StartCoroutine(RepeatingFire());
    }
}
