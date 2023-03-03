using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveVisual : MonoBehaviour
{
    [SerializeField] private GameObject stoveOnGameObject;
    [SerializeField] private GameObject particlesGameObject;
    [SerializeField] private Stove stove;

    private void Start()
    {
        stove.OnStateChanged += Stove_OnStateChanged;
    }

    private void Stove_OnStateChanged(object sender, Stove.OnStateChangedEventArgs e)
    {
        bool showVisual = e.state == Stove.State.Frying || e.state == Stove.State.Fried;
        stoveOnGameObject.SetActive(showVisual);
        particlesGameObject.SetActive(showVisual);
    }
}
