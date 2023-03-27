using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIgredientAddedEventArgs> OnIngredientAdded;
    public class OnIgredientAddedEventArgs : EventArgs
    {
        public KitchenObjectSO kitchenObjectSO;
    }

    private List<KitchenObjectSO> kitchenObjectSOList;

    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSO;

    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();   
    }

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if(!validKitchenObjectSO.Contains(kitchenObjectSO))
            return false;

        if (kitchenObjectSOList.Contains(kitchenObjectSO))
            return false;
        else
        {
            kitchenObjectSOList.Add(kitchenObjectSO);

            OnIngredientAdded?.Invoke(this, new OnIgredientAddedEventArgs
            {
                kitchenObjectSO = kitchenObjectSO
            });

            return true;
        }
    }

    public List<KitchenObjectSO> GetKitchenObjectSOList()
    {
        return kitchenObjectSOList;
    }
}
