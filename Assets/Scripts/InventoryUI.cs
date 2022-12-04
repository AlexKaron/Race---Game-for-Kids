using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI beansText;

    void Start()
    {
        beansText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateBeansText(PlayerInventory playerInventory)
    {
        beansText.text = playerInventory.NumberOfBeans.ToString();
    }
    
}
