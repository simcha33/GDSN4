using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissile : MonoBehaviour
{
    public GameObject missile;
    Vector3 launcherLeft;
    Vector3 launcherRight;
    int target;

    private void Awake()
    {
        
    }

    void FireMissile()
    {
        GameObject missileShotLeft = Instantiate(missile, launcherLeft, Quaternion.identity);
        GameObject missileShotRight = Instantiate(missile, launcherRight, Quaternion.identity);
    }
}
