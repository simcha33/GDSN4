using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chalemeon : MonoBehaviour
{
    public List<Material> materialList = new List<Material>();
    public List<string> tagNameList = new List<string>(); 
    int x = 0;
    public GameObject magic;
    ParticleSystem magicCircle;

    Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        magicCircle = magic.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ColorSwitch();
        }
    }

    public void ColorSwitch()
    {
        
        x += 1;
        if (x > materialList.Count -1)
        {
            x = 0;
        }
        rend.material = materialList[x];
        transform.gameObject.tag = tagNameList[x];
        magicCircle.Play();

    }

    public void Activate()
    {
        InvokeRepeating("ColorSwitch", 3.0f, 3.0f);
    }

}
