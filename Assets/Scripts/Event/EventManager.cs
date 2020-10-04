using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    List <GameObject> PCArray;

    [SerializeField]
    List<GameObject> CoffeArray;

    [SerializeField]
    List<GameObject> PrinterArray;

    private int _currentIndex = 0;

    private int _coffeIndex = -1;
    private int _pcIndex = -1;
    private int _printerIndex = -1;

    
    private void Start()
    {
        for (int i = 1; i < PCArray.Count; i++)
            PCArray[i].SetActive(false);
        
        for (int i = 0; i < CoffeArray.Count; i++)
            CoffeArray[i].SetActive(false);
        
        for (int i = 0; i < PrinterArray.Count; i++)
            PrinterArray[i].SetActive(false);

    }

    public void SwitchEvent()
    {
        if (_currentIndex < 3)
            _currentIndex++;
        else
            _currentIndex = 0;
        
        switch (_currentIndex)
        {
            case 0:
                {
                    //If this is our first time, we do not need to delete element
                    if (_pcIndex > -1)
                    {
                        PCArray[_pcIndex].SetActive(false);
                        PCArray.RemoveAt(_pcIndex);
                    }
                    _pcIndex = Random.Range(0, PCArray.Count);

                    PCArray[_pcIndex].SetActive(true);
                    break;
                }

            case 1:
                {
                    //If this is our first time, we do not need to delete element
                    if (_coffeIndex > -1)
                    {
                        CoffeArray[_coffeIndex].SetActive(false);
                        CoffeArray.RemoveAt(_coffeIndex);
                    }
                    _coffeIndex = Random.Range(0, CoffeArray.Count);
                   
                    CoffeArray[_coffeIndex].SetActive(true);
                    break;
                }

            case 2:
                {
                    //If this is our first time, we do not need to delete element
                    if (_printerIndex > -1)
                    {
                        PrinterArray[_printerIndex].SetActive(false);
                        PrinterArray.RemoveAt(_printerIndex);
                    }
                    _printerIndex = Random.Range(0, PrinterArray.Count);
                    Debug.Log($"Works! {_printerIndex}");
                    PrinterArray[_printerIndex].SetActive(true);
                    break;
                }
        }
    }
}
