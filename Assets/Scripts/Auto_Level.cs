using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Level : MonoBehaviour
{
    public GameObject last_ring;
    public GameObject prefab_ring;
    public GameObject final_ring;
    public GameObject Cylinder;
    public Material unsafeMaterialRef;
    public Material safeMaterialRef;
    public GameManager gm;
    int level;
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        level = PlayerPrefs.GetInt("level");
        int rn = level / 3 + 10; // Ring Number
        for (int i = 0; i < rn; i++)
        {
            create_ring();
        }
        create_finalring();
    }

    void Update()
    {

    }

    public void create_ring()
    {
        Vector3 direction = new Vector3(0, -2.2f, 0);
        var rotationVector = transform.rotation.eulerAngles;
        float rotn = (float)(level * 1.2);
        rotationVector.y = (int)(Random.Range(0, rotn));
        last_ring = Instantiate(prefab_ring, last_ring.transform.position + direction, Quaternion.Euler(rotationVector), Cylinder.transform);
        //for(int k = 0; k < 8; k++)
        //{
        //    GameObject child = last_ring.transform.GetChild(k).gameObject;
        //    child.SetActive(true);
        //    child.GetComponent<Renderer>().material = safeMaterialRef;
        //}
        int minUnsafeColor = -1 + level/20;
        if(minUnsafeColor < 0) { minUnsafeColor = 0; }
        if (minUnsafeColor > 4) { minUnsafeColor = 4; }
        int maxUnsafeColor = 3 + level/20;
        if (maxUnsafeColor > 7) { maxUnsafeColor = 7; }
        int setUnsafeColor = Random.Range(minUnsafeColor, maxUnsafeColor);
        for (int k = 0; k < setUnsafeColor;)
        {
            int whichOneIsSelected = Random.Range(0, 8);
            GameObject child3 = last_ring.transform.GetChild(whichOneIsSelected).gameObject;
            if (child3.GetComponent<Renderer>().material.name == "Unsafe Color (Instance)") { }
            else
            {
                child3.GetComponent<Renderer>().material = unsafeMaterialRef;
                k++;
            }
        }
        int maxDisabledNumber = 9 - maxUnsafeColor;
        if (maxDisabledNumber > 5) { maxDisabledNumber = 5; }

        int howManyDisabled = Random.Range(1, maxDisabledNumber);
        for (int j = 0; j < howManyDisabled;)
        {
            int whichOneIsDisabled = Random.Range(0, 8);
            GameObject child2 = last_ring.transform.GetChild(whichOneIsDisabled).gameObject;
            if (child2.GetComponent<Renderer>().material.name == "Unsafe Color (Instance)") { }
            else if(child2.active)
            {
                child2.SetActive(false);
                j++;
            }
        }
    }

    public void create_finalring()
    {
        Vector3 direction = new Vector3(0, -2.4f, 0);
        final_ring = Instantiate(final_ring, last_ring.transform.position + direction, last_ring.transform.rotation, Cylinder.transform);
        final_ring.SetActive(true);
    }
}
