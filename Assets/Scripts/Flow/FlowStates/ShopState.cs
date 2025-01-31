using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopState : FactoryState
{
    public GameObject ShopCanvas;
    public TextMeshProUGUI totalFish;
    [SerializeField] private Button goToMenu;
    
    //Shop Items
    public GameObject hatPrefab;
    public Transform hatParent;
    private Hats[] hats;

    private void Awake()
    { 
        hats = Resources.LoadAll<Hats>("Hat/");
        PopulateShop();
    }


    public override void EnterFlow()
    {
        base.Awake();
        GameManager.Instance.ChangeCamera(GameCameras.ShopCam);
        totalFish.text = $"x{SaveManager.Instance.saveData.Fish:D5}";
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
            GameObject hat = Instantiate(hatPrefab, hatParent);
            hat.GetComponent<Button>().onClick.AddListener(() => OnHatClick(i));
            hat.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = hats[i].HatName;
            hat.transform.GetChild(1).GetComponent<Image>().sprite = hats[i].Thumbnail;
            hat.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = hats[i].HatPrice.ToString();
        }
    }

    private void OnHatClick(int i)
    {
       
    }
} 