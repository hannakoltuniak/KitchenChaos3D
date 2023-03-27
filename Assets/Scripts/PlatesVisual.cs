using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesVisual : MonoBehaviour
{
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private Transform plateVisualPrefab;
    [SerializeField] private Plates plates;

    private List<GameObject> platesOnVisualGameObjectList;

    private void Awake()
    {
        platesOnVisualGameObjectList = new List<GameObject>();
    }

    private void Start()
    {
        plates.OnPlateSpawned += Plates_OnPlateSpawned;
        plates.OnPlateRemoved += Plates_OnPlateRemoved;
    }

    private void Plates_OnPlateRemoved(object sender, System.EventArgs e)
    {
        GameObject plateGameObjet = platesOnVisualGameObjectList[platesOnVisualGameObjectList.Count - 1];
        platesOnVisualGameObjectList.Remove(plateGameObjet);
        Destroy(plateGameObjet);
    }

    private void Plates_OnPlateSpawned(object sender, System.EventArgs e)
    {
        Transform plateVisualTranform = Instantiate(plateVisualPrefab, counterTopPoint);

        float plateOffSetY = 0.1f;
        plateVisualTranform.localPosition = new Vector3(0, plateOffSetY * platesOnVisualGameObjectList.Count, 0);

        platesOnVisualGameObjectList.Add(plateVisualTranform.gameObject);
    }
}
