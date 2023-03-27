using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct KitchenObjectS0_GameObject
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }

    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private List<KitchenObjectS0_GameObject> kitchenObjectS0GameObjectsList;

    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;

        foreach (KitchenObjectS0_GameObject kitchenObjectS0_GameObject in kitchenObjectS0GameObjectsList)
        {
            kitchenObjectS0_GameObject.gameObject.SetActive(false);
        }
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIgredientAddedEventArgs e)
    {
        foreach (KitchenObjectS0_GameObject kitchenObjectS0_GameObject in kitchenObjectS0GameObjectsList)
        {
            if (kitchenObjectS0_GameObject.kitchenObjectSO == e.kitchenObjectSO)
                kitchenObjectS0_GameObject.gameObject.SetActive(true);
        }
    }
}
