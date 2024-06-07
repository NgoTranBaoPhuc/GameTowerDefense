using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    private void Awake()
    {
        instance = this; 
    }
    public int currentMoney;

    

    void Start()
    {
        UIController.instance.goldText.text = currentMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveMoney(int amoutToGive)
    {
        currentMoney += amoutToGive;
        UIController.instance.goldText.text = currentMoney.ToString();
    }
    public bool SpendMoney(int amoutToSpend)
    {
        bool canSpend = false;
        if(amoutToSpend <= currentMoney)
        {
            canSpend = true;
            Debug.Log("Spent "+ amoutToSpend);
            currentMoney -= amoutToSpend;
        }
        UIController.instance.goldText.text = currentMoney.ToString();

        return canSpend;
    }
}
