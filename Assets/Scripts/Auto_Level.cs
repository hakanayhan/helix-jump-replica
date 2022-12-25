using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Level : MonoBehaviour
{
    [SerializeField] private GameObject _lastRing;
    [SerializeField] private GameObject _prefabRing;
    [SerializeField] private GameObject _finalRing;
    [SerializeField] private GameObject _cylinder;
    [SerializeField] private Material _unsafeMaterialRef;
    private GameManager gm;
    int level;
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        level = PlayerPrefs.GetInt("level");
        int number_of_rings = CalculateNumberOfRings(level);
        for (int i = 0; i < number_of_rings; i++)
        {
            CreateRing();
        }
        CreateFinalRing();
    }

    void Update()
    {

    }

    private void CreateRing()
    {
        Vector3 direction = new Vector3(0, -2.2f, 0);
        var rotationVector = transform.rotation.eulerAngles;
        float rotn = (float)(level * 1.2);
        rotationVector.y = (int)(Random.Range(0, rotn));
        _lastRing = Instantiate(_prefabRing, _lastRing.transform.position + direction, Quaternion.Euler(rotationVector), _cylinder.transform);
        int maxUnsafeColor = SetUnsafeColors(level);
        SetDisabledColors(maxUnsafeColor);
    }

    private void CreateFinalRing()
    {
        Vector3 direction = new Vector3(0, -2.4f, 0);
        _finalRing = Instantiate(_finalRing, _lastRing.transform.position + direction, _lastRing.transform.rotation, _cylinder.transform);
        _finalRing.SetActive(true);
    }

    private int SetUnsafeColors(int level)
    {
        int minUnsafeColor = -1 + level / 20;
        if (minUnsafeColor < 0) { minUnsafeColor = 0; }
        if (minUnsafeColor > 4) { minUnsafeColor = 4; }

        int maxUnsafeColor = 3 + level / 20;
        if (maxUnsafeColor > 7) { maxUnsafeColor = 7; }

        int setUnsafeColor = Random.Range(minUnsafeColor, maxUnsafeColor);
        for (int k = 0; k < setUnsafeColor;)
        {
            int whichOneIsSelected = Random.Range(0, 8);
            GameObject child3 = _lastRing.transform.GetChild(whichOneIsSelected).gameObject;
            if (child3.GetComponent<Renderer>().material.name != "Unsafe Color (Instance)")
            {
                child3.GetComponent<Renderer>().material = _unsafeMaterialRef;
                k++;
            }
        }

        return maxUnsafeColor;
    }

    private void SetDisabledColors(int maxUnsafeColor)
    {
        int maxDisabledNumber = 9 - maxUnsafeColor;
        if (maxDisabledNumber > 5) { maxDisabledNumber = 5; }

        int howManyDisabled = Random.Range(1, maxDisabledNumber);
        for (int j = 0; j < howManyDisabled;)
        {
            int whichOneIsDisabled = Random.Range(0, 8);
            GameObject child2 = _lastRing.transform.GetChild(whichOneIsDisabled).gameObject;
            if (child2.GetComponent<Renderer>().material.name != "Unsafe Color (Instance)" && child2.active)
            {
                child2.SetActive(false);
                j++;
            }
        }
    }
    private int CalculateNumberOfRings(int level) => level / 3 + 10;
}
