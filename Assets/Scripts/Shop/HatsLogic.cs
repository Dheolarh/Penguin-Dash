using System.Collections.Generic;
using UnityEngine;

public class HatsLogic : MonoBehaviour
{
    [SerializeField] private Transform penguinHead;
    private List<GameObject> hatModels = new List<GameObject>();
    private Hats[] hats;

    private void Start()
    {
        hats = Resources.LoadAll<Hats>("Hat");
        SpawnHats();
        SelectHat(SaveManager.Instance.saveData.currentHat);
    }

    private void SpawnHats()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            hatModels.Add(Instantiate(hats[i].Hat, penguinHead) as GameObject);
        }
    }
 
    public void DisableAllHats()
    {
        for (int i = 0; i < hatModels.Count; i++)
        {
            hatModels[i].SetActive(false);
        }
    }

    public void SelectHat(int index)
    {
        DisableAllHats();
        hatModels[index].SetActive(true);
    }
}