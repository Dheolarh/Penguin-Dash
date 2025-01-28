using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopState : FactoryState
{
    public GameObject ShopCanvas;
    public TextMeshProUGUI totalFish;
    
    //Shop Items
    public GameObject ShopItemPrefab;
    public Transform ShopItemParent;
    public override void EnterFlow()
    {
        GameManager.Instance.ChangeCamera(GameCameras.ShopCam);
        totalFish.text = $"x{SaveManager.Instance.saveData.Fish:D5}";
        ShopCanvas.SetActive(true);
    }

    public void GoToMenu()
    {
        flow.ChangeFlow(GetComponent<InitializeGame>());
    }
    
    public override void ExitFlow()
    {
        ShopCanvas.SetActive(false);
    }
}

