using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMethod : MonoBehaviour
{
    public enum ShootStyle
    {
        SingleFire,
        RepeatingFire,
        SpreadFire,
        MissileFire,
        Balrog,
        Chalemeon,
        RandomSpread
    }

    public float fireRate;
    public float fireDelay;
    public GameObject bulletPrefab;
    public int bulletAmount;
    public ShootStyle style;
    Vector3 pos;

    [Header("Single Fire Variables")]
    public float waitTime;
    
    //[Header("Repeating Fire Variables")]
    [Header("Spread Fire Variables")]
    public float bulletSpeed;
    GameObject player;


    [Header("Missile Fire Variables")]
    public GameObject missilePrefab;

    [Header("Balrog Variables")]
    public int maxBerserkCount;
    int berserkCount;
    public float fireRateBerserk;
    bool berserkMode;
    GameObject berserkFlames = null;
    ParticleSystem flames = null;
    private const float radius = 1f;
    
    BasicBullet bulletScript;

    [Header("Don't touch the following")]
    public int target;

    private void Awake()
    {
        if (style == ShootStyle.SingleFire)
        {
            target = Random.Range(1, 3);
            StartCoroutine(SingleShoot());
        }

        if (style == ShootStyle.RepeatingFire)
        {
            InvokeRepeating("BasicFire", 3.0f, fireDelay);
        }

        if(style == ShootStyle.MissileFire)
        {
            MissileFire();
        }

        if(style == ShootStyle.SpreadFire)
        {
            InvokeRepeating("SpreadFire", 3.0f, fireDelay);
        }

        if(style == ShootStyle.Balrog)
        {
            InvokeRepeating("SpreadFire", 3.0f, fireDelay);
            berserkFlames = this.transform.Find("CFX3_Fire_Shield").gameObject;
            
            flames = berserkFlames.GetComponent<ParticleSystem>();
        }

        if(style == ShootStyle.Chalemeon)
        {
            Chalemeon chalemeon = GetComponent<Chalemeon>();
            chalemeon.Activate();
            InvokeRepeating("RandomSpreadFire", 3.0f, fireDelay);

        }

        if(style == ShootStyle.RandomSpread)
        {
            InvokeRepeating("RandomSpreadFire", 3.0f, fireDelay);
            
        }

        berserkMode = false;
    }

    private void Update()
    {
        if(berserkCount >= maxBerserkCount && !berserkMode && berserkCount != 0)
        {
            CancelInvoke();
            flames.Play();
            fireDelay = fireRateBerserk;
            bulletAmount = 16;
            InvokeRepeating("circularShot", 3.0f, fireDelay);
            berserkMode = true;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            RandomSpreadFire();
        }

        
    }



    IEnumerator RepeatingFire()
    {
        ChooseTarget();

        for (int i = 0; i < bulletAmount; i++)
        {
            pos = this.transform.position;
            GameObject bullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
            bulletScript = bullet.GetComponent<BasicBullet>();
            
            bullet.transform.LookAt(player.transform);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
            yield return new WaitForSeconds(fireRate);

        }
    }
    
    IEnumerator RandomSpread()
    {
        ChooseTarget();
        for (int i = 0; i < bulletAmount; i++)
        {
            pos = this.transform.position;
            GameObject bullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
            bulletScript = bullet.GetComponent<BasicBullet>();
            
            bullet.transform.LookAt(player.transform);
            Quaternion currentRot = bullet.transform.rotation;
            bullet.transform.localRotation = Quaternion.Euler(0, 0, bullet.transform.rotation.z + Random.Range(-30,30)) * currentRot;

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
            yield return new WaitForSeconds(fireRate);

        }
    }

    IEnumerator SingleShoot()
    {
        ChooseTarget();
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i < bulletAmount; i++)
        {
            pos = this.transform.position;
            GameObject bullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
            bulletScript = bullet.GetComponent<BasicBullet>();
            bullet.transform.LookAt(player.transform);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

            yield return new WaitForSeconds(fireRate); 
        }
    }
    
    IEnumerator SpreadFiring()
    {
        ChooseTarget();
        for (int i = 0; i < bulletAmount; i++)
        {
            pos = this.transform.position;
            for (int j = 1; j < 6; j++)
            {
                GameObject bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
                bullet.transform.LookAt(player.transform);
                Quaternion currentRot = bullet.transform.rotation;
                bullet.transform.localRotation = Quaternion.Euler(0, 0, bullet.transform.rotation.z + 10 * j - 30) * currentRot;

                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
            }
            yield return new WaitForSeconds(fireRate);
        }
    }
 

    void BasicFire()
    {
        StartCoroutine(RepeatingFire());
    }

    void SpreadFire()
    {
        StartCoroutine(SpreadFiring());
    }

    void MissileFire()
    {
        target = Random.Range(1, 3);
        pos = this.transform.position;
        Instantiate(missilePrefab, pos, Quaternion.identity);
    }

    public void BerserkCounter()
    {
        berserkCount += 1;
    }

    private void ChooseTarget()
    {
        target = Random.Range(1, 3);
        if (target == 1) player = GameObject.Find("p1");
        else if (target == 2) player = GameObject.Find("p2");
        else player = null;

        if (target == 1 && player == null)
        {
            player = GameObject.Find("p2");
        }
        else if (target == 2 && player == null)
        {
            player = GameObject.Find("p1");
        }
    }


    /*
        void SpreadProjectiles()
        {
            target = Random.Range(1, 3);
            pos = this.transform.position;
            if (target == 1) player = GameObject.Find("p1");
            else if (target == 2) player = GameObject.Find("p2");
            else player = null;

            Vector3 forward = (player.transform.position - this.transform.position).normalized * coneLength;
            Vector3 perp = new Vector3(forward.y, forward.x, 0).normalized;
            GameObject bullet0 = Instantiate(bulletPrefab, pos, Quaternion.identity);
            bullet0.transform.forward = forward;
            for (int i = 0; i < bulletAmount/2; i++)
            {
                Vector3 offset = (forward + (perp * (i) * (coneWidth / bulletAmount))).normalized;
                Vector3 offset2 = (forward - (perp * (i) * (coneWidth / bulletAmount))).normalized;

                GameObject bullet1 = Instantiate(bulletPrefab, pos, Quaternion.identity);
                bullet1.transform.forward = offset;
                bullet1.GetComponent<Rigidbody>().velocity = bullet1.transform.forward * bulletSpeed;

                GameObject bullet2 = Instantiate(bulletPrefab, pos, Quaternion.identity);
                bullet2.transform.forward = offset2;
                bullet2.GetComponent<Rigidbody>().velocity = bullet2.transform.forward * bulletSpeed;

            }


        } 

    */

    void circularShot()
    {
        float angleStep = 360f / bulletAmount;
        float angle = 0f;
        
        for(int i = 0; i <= bulletAmount -1; i++)
        {
            pos = this.transform.position;
            
            float projectileDirXPosition = pos.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = pos.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - pos).normalized * bulletSpeed;

            GameObject bullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirection.x, projectileMoveDirection.y, 0);

            angle += angleStep;
        }
    }

    void RandomSpreadFire()
    {
        StartCoroutine(RandomSpread());
    }


}
