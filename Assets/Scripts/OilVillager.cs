using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class OilVillager : MonoBehaviour
{
    // Takes oil from tower when available and carries it to storage.
    
    [SerializeField] private Transform storageLocation;
    [SerializeField] private Transform oilTowerLocation;

    [SerializeField] private Storage storage;
    [SerializeField] private OilTower oilTower;

    [SerializeField] private GameObject oilDisplay;
    [SerializeField] private int carryingOilMax;

    private int _carryingOil;
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    private void Update()
    {
        oilDisplay.GetComponent<TextMeshProUGUI>().text = "Carrying oil: " + _carryingOil + " / " + carryingOilMax;
        
        if (_carryingOil <= 0 && oilTower.TowerOil > 0)
        {
            _navMeshAgent.destination = oilTowerLocation.position;
        }
        else if (_carryingOil > 0)
        {
            _navMeshAgent.destination = storageLocation.position;
        }
    }
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("OilTower"))
        {
            if (oilTower.TowerOil > 0)
            {
                oilTower.TakeOil(1);
                _carryingOil += 1;
            }
        }
        if (other.gameObject.CompareTag("Storage"))
        {
            if (_carryingOil > 0)
            {
                storage.StoreOil(1);
                _carryingOil -= 1;
            }
        }
    }
}
