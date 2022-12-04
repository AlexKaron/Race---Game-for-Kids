using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beans : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.BeansCollected();
            gameObject.SetActive(false);
        }
    }
}
