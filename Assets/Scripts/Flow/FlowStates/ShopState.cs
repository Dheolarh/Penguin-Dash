using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopState : FactoryState
{
    public GameObject ShopCanvas;
    public TextMeshProUGUI totalFish;
    public TextMeshProUGUI currentHatName;
    [SerializeField] private Button goToMenu;
    
    //Shop Items
    public GameObject hatPrefab;
    public Transform hatParent;
    private Hats[] hats;
    public HatsLogic hatLogic;

    protected override void Awake()
    { 
        base.Awake();
        hats = Resources.LoadAll<Hats>("Hat/");
        PopulateShop();
    } 
    public override void EnterFlow()
    {
        GameManager.Instance.ChangeCamera(GameCameras.ShopCam);
        totalFish.text = $"x{SaveManager.Instance.saveData.Fish:D5}";
        currentHatName.text = "Shop";
        ShopCanvas.SetActive(true);
    }
    
    public override void UpdateFlow()
    {
        goToMenu.onClick.AddListener(GoToMenu);
    }

    public void GoToMenu()  
    {
        flow.ChangeFlow(GetComponent<InitializeGame>());
    }
    
    public override void ExitFlow()
    {
        ShopCanvas.SetActive(false);
    }
    private void PopulateShop()
    {
        for (int i = 0 ; i < hats.Length; i++)
        {
            int index = i;
            GameObject hat = Instantiate(hatPrefab, hatParent);
            hat.GetComponent<Button>().onClick.AddListener(() => OnHatClick(index));
            hat.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = hats[index].HatName;
            hat.transform.GetChild(1).GetComponent<Image>().sprite = hats[index].Thumbnail;
            hat.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = hats[index].HatPrice.ToString();
        }
    }

    private void OnHatClick(int i)
    {
        SaveManager.Instance.saveData.CurrentHat = i;
       hatLogic.SelectHat(i);
       if (hats[i].HatName == String.Empty)
       {
           currentHatName.text = "Shop";
       }
       else
       {
              currentHatName.text = hats[i].HatName;
       }
       SaveManager.Instance.Save();
    }
} 