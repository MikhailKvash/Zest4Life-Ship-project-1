using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OilTower : MonoBehaviour
{
    // Generates oil automatically, stores it and shows amount in menu.
    
    [SerializeField] private int oil;
    [SerializeField] private int oilMax;

    [SerializeField] private GameObject oilDisplay;

    private int _oilSpeed = 1;

    public int TowerOil => oil;

    private void Start()
    {
        StartCoroutine(GenerateOil());
    }

    private void Update()
    {
        oilDisplay.GetComponent<TextMeshProUGUI>().text = "Oil in tower: " + oil + " / " + oilMax;
    }

    public void TakeOil(int value)
    {
        oil -= value;
    }

    private IEnumerator GenerateOil()
    {
        if (oil < oilMax)
        {
            yield return new WaitForSeconds(5);
            oil += _oilSpeed;
            StartCoroutine(GenerateOil());
        }
    }
}
