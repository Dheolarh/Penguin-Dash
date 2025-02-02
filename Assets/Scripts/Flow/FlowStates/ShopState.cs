using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ShopState : FactoryState
{
    public GameObject ShopCanvas;
    public TextMeshProUGUI totalFish;
    public TextMeshProUGUI currentHatName;
    [FormerlySerializedAs("noFish")] public TextMeshProUGUI buyStatus;
    [SerializeField] private Button goToMenu;
    
    //Shop Items
    public GameObject hatPrefab;
    private GameObject hat;

    public Transform hatParent;
    private Hats[] hats;
    public HatsLogic hatLogic;

    protected override void Awake()
    { 
        base.Awake();
        
    } 
    public override void EnterFlow()
    {
        hats = Resources.LoadAll<Hats>("Hat/");
        GameManager.Instance.ChangeCamera(GameCameras.ShopCam);
        totalFish.text = $"x{SaveManager.Instance.saveData.Fish:D5}";
        currentHatName.text = "Shop";
        PopulateShop();
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
        buyStatus.text = "";
        SaveManager.Instance.Save();
    }
    private void PopulateShop()
    {
        foreach (Transform child in hatParent)
        {
            Destroy(child.gameObject);
        }
        
        for (int i = 0 ; i < hats.Length; i++)
        {
            int index = i;
            hat = Instantiate(hatPrefab, hatParent);
            hat.GetComponent<Button>().onClick.AddListener(() => OnHatClick(index));
            hat.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = hats[index].HatName;
            hat.transform.GetChild(1).GetComponent<Image>().sprite = hats[index].Thumbnail;
            hat.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = hats[index].HatPrice.ToString();
            Image buttonImage = hat.GetComponent<Button>().image;
            if(hats[index].HatName == "None")
            {
                hat.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Owned";
            }
            if (SaveManager.Instance.saveData.UnlockedHats[i] == 1)
            {
                buttonImage.color = new Color(1f, 1f, 1f, 110f / 255f);
                hat.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Owned";
            }
            else if (SaveManager.Instance.saveData.UnlockedHats[i] == 0 && (SaveManager.Instance.saveData.Fish >= hats[i].HatPrice))
            {
                buttonImage.color = new Color(0f, 1f, 0f, 110f / 255f);
            }
            else
            {
                buttonImage.color = new Color(1f, 0f, 0f, 110f / 255f);
            }
            if (index == SaveManager.Instance.saveData.CurrentHat)
            {
                hat.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Equipped";
            }
        }
    }

    private void OnHatClick(int i)
    {
        if (SaveManager.Instance.saveData.UnlockedHats[i] == 1)
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
            PopulateShop();
            SaveManager.Instance.Save();
        }
        else if (SaveManager.Instance.saveData.Fish >= hats[i].HatPrice)
        {
            SaveManager.Instance.saveData.Fish -= hats[i].HatPrice;
            SaveManager.Instance.saveData.UnlockedHats[i] = 1;
            SaveManager.Instance.saveData.CurrentHat = i;
            Image soldImage = hat.GetComponent<Button>().image;
            soldImage.color = new Color(1f, 1f, 1f, 110f / 255f);
            hatLogic.SelectHat(i); 
            currentHatName.text = hats[i].HatName;
            totalFish.text = $"x{SaveManager.Instance.saveData.Fish:D5}";
            buyStatus.color = Color.green;
            buyStatus.text = "Hat Purchased";
            hat.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Owned";
            
            PopulateShop();
            SaveManager.Instance.Save();
            Invoke("HideBuyStatus", 2f);
        }
        else
        {
            buyStatus.color = Color.red;
            buyStatus.text = "Not Enough Fish";
            Invoke("HideBuyStatus", 2f);
        }
    }

    private void HideBuyStatus()
    {
        buyStatus.text = "";
    }
} 