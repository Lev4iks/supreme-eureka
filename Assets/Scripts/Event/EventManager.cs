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


                    CoffeArray[0].SetActive(false);
                    PrinterArray[0].SetActive(false);
                    PCArray[0].SetActive(true);
                    break;
                }

            case 1:
                {


                    PrinterArray[0].SetActive(false);
                    PCArray[0].SetActive(false);
                    CoffeArray[0].SetActive(true);
                    break;
                }

            case 2:
                {

                    PCArray[0].SetActive(false);
                    CoffeArray[0].SetActive(false);
                    PrinterArray[0].SetActive(true);
                    break;
                }
        }
    }
}
