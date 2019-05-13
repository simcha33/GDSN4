using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class EnemyShooting : MonoBehaviour
{
    //the time it takes before the enemies shoot bullets
    public float bulletTime;
    //time between bullets
    public float fireRate;
    public int bulletAmount;
    public GameObject bulletPrefab;
    Vector3 pos;

    public bool bulletFollow;

    BasicBullet bulletScript;

    //target = 0 is straight down ,target = 1 is RED, target = 2 is BLUE player, 
    public int target;

    private void Awake()
    {
        if (bulletFollow)
            target = Random.Range(1, 3);
        else target = 0;

        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(bulletTime);
        for (int i = 0; i < bulletAmount; i++)
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
}
