using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chalemeon : MonoBehaviour
{
    public List<Material> materialList = new List<Material>();
    int x = 0;

    Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    public void ColorSwitch()
    {
        x += 1;
        if (x > materialList.Count)
        {
            x = 0;
        }
        rend.material = materialList[x];
        
    }

}
