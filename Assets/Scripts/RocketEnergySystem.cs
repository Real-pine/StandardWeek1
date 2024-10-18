using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketEnergySystem : MonoBehaviour
{
    [SerializeField] Image fuelImage;
    [SerializeField] Button _button;

    private float maxFuel = 100f;
    private float curFuel;
    private readonly float FUELPERSHOOT = 10f;
    private readonly float FuelCharge = 1f;
    
    void Awake()
    {
        curFuel = maxFuel;
        _button.onClick.AddListener(EnergyPerShoot);
    }
    private void Update()
    {
        EnergyChargeSystem();
        FuelbarUpdate();
    }
    private void EnergyPerShoot()
    {
        if (curFuel >= FUELPERSHOOT)
        {
            _button.interactable = true;
            curFuel -= FUELPERSHOOT; 
        }
        else
        { 
            _button.interactable = false;
        }
        
    }

    private void EnergyChargeSystem()
    {
        if( curFuel < maxFuel )
        {
            curFuel += FuelCharge * Time.deltaTime;
            if( curFuel > maxFuel )
            {
                curFuel = maxFuel ;
            }
        }
        Debug.Log("Fuel after charge: " + curFuel);
    }
    private void FuelbarUpdate()
    {
        fuelImage.fillAmount = curFuel / maxFuel;
    }
}
