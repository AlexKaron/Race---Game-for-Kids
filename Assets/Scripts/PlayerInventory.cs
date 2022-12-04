using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfBeans {get; private set;}

    public UnityEvent<PlayerInventory> OnBeansCollected;

    public void BeansCollected()
    {
        NumberOfBeans++;
        OnBeansCollected.Invoke(this);
    }
}
