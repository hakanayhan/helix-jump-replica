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
    void Start()
    {
        for (int i = 0; i < 20; i++)
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
        last_ring = Instantiate(prefab_ring, last_ring.transform.position + direction, last_ring.transform.rotation, Cylinder.transform);
        //for(int k = 0; k < 8; k++)
        //{
        //    GameObject child = last_ring.transform.GetChild(k).gameObject;
        //    child.SetActive(true);
        //    child.GetComponent<Renderer>().material = safeMaterialRef;
        //}

        int howManyDisabled = Random.Range(1, 4);
        for(int j = 0; j < howManyDisabled; j++)
        {
            int whichOneIsDisabled = Random.Range(0, 8);
            GameObject child2 = last_ring.transform.GetChild(whichOneIsDisabled).gameObject;
            child2.SetActive(false);
        }

        int setUnsafeColor = Random.Range(0, 5);
        for (int k = 0; k < setUnsafeColor; k++)
        {
            int whichOneIsSelected = Random.Range(0, 8);
            GameObject child3 = last_ring.transform.GetChild(whichOneIsSelected).gameObject;
            child3.GetComponent<Renderer>().material = unsafeMaterialRef;
        }
    }

    public void create_finalring()
    {
        Vector3 direction = new Vector3(0, -2.4f, 0);
        final_ring = Instantiate(final_ring, last_ring.transform.position + direction, last_ring.transform.rotation, Cylinder.transform);
        final_ring.SetActive(true);
    }
}
