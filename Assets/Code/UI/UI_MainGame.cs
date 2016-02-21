using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UI_MainGame : MonoBehaviour {


    [Header("UI: Character Panel")]
    public Text witchName;
    public Text familiarName;
    public Image witchImage;
    public Image familiarImage;
    public Image schoolImage;
    public Text dreamsValue;
    public Text potentialValue;
    public Text visionValue;
    public Text koValue;

    [Header("UI: House Panel")]
    public GameObject housePanel;
    public List<Text> ingredientLabel;
    public List<Text> ingredientValue;
    public int ingredientsToShow = 6;
    int ingredientGroup = 0;
    int maxIngredientGroups = -1;


    [Header("UI: Gather Panel")]
    public GameObject gatherPanel;
    public Text zoneName;
    public Text zoneDescription;
    public Image zoneImage;
    public Dropdown gatherQualityDropdown;
    public Dropdown gatherMethodDropdownn;
    public Button gatherButton;

    [Header("UI: Brew Panel")]
    public GameObject brewPanel;

    GameLogic gameLogic;

	// Use this for initialization
	void Start () {

        //grab gameLogic
        try
        {
            gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        }
        catch
        {
            //for testing
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
        
        UpdatePlayerInfo();

        ActivateHousePanel();
	
	}

    public void UpdatePlayerInfo()
    {
        //update all the text labels
        Witch player = gameLogic.GetCurrentWitch();
        witchName.text = player.name;
        witchImage.sprite = player.portrait;
        familiarName.text = player.familiar.name;
        familiarImage.sprite = player.familiar.portait;
        schoolImage.sprite = player.magicSchoolImage;
        dreamsValue.text = player.dreams.ToString();
        potentialValue.text = player.potential.ToString();
        visionValue.text = player.vision.ToString();
        koValue.text = player.ko.ToString();
    }

    public void ActivateHousePanel()
    {
        //disable other panels
        //activate house
        housePanel.SetActive(true);
        brewPanel.SetActive(false);
        gatherPanel.SetActive(false);
        //update house information
        ingredientGroup = 0;
        ShowIngredientGroup();
    }

    public void ShowIngredientGroup()
    {
        int startIndex = ingredientGroup * ingredientsToShow;
        int endIndex = startIndex + ingredientsToShow;
        int currentIndex = -1;
        Witch player = gameLogic.GetCurrentWitch();

        for(int i=startIndex; i<endIndex; i++)
        {
            //offset back to 0-6 for labels and values
            currentIndex = i - ingredientsToShow * ingredientGroup;
            //disable label if there's not enough ingredients
            if(i >= player.house.ingredientStock.Count)
            {
                ingredientLabel[currentIndex].gameObject.SetActive(false);
                ingredientValue[currentIndex].gameObject.SetActive(false);
            }
            else
            {
                ingredientLabel[currentIndex].gameObject.SetActive(true);
                ingredientValue[currentIndex].gameObject.SetActive(true);
                ingredientLabel[currentIndex].text = player.house.ingredientStock[i].name + ":";
                ingredientValue[currentIndex].text = player.house.ingredientStock[i].amount.ToString();
            }
        }

    }

    public void ChangeIngredientGroup(int direction)
    {
        maxIngredientGroups = gameLogic.GetCurrentWitch().house.ingredientStock.Count / ingredientsToShow;
        ingredientGroup += direction;
        if (ingredientGroup < 0) ingredientGroup = maxIngredientGroups;
        if (ingredientGroup > maxIngredientGroups) ingredientGroup = 0;
        ShowIngredientGroup();
    }

    public void ActivateGatherPanel(string targetZone)
    {
        //disable other panels
        //activate Gather
        housePanel.SetActive(false);
        brewPanel.SetActive(false);
        gatherPanel.SetActive(true);
        //load the proper zone and set all the text info
        Zone activeZone = GameDatabase.Instance.GetZoneReferenceByName(targetZone);
#if UNITY_EDITOR
        if (activeZone == null)
        {
            Debug.LogError("ZONE FAILED TO LOAD");
            return;
        }
#endif
        zoneName.text = activeZone.name;
        zoneDescription.text = activeZone.description;
        zoneImage.sprite = activeZone.sprite;

    }

    public void ActivateBrewPanel()
    {
        //disable other panels
        //activate Brew
        housePanel.SetActive(false);
        brewPanel.SetActive(true);
        gatherPanel.SetActive(false);
        //update information
    }


    public void CalculateGatherReaAndTimeCost()
    {
        //if index is 0 bail and disable the gather button
        if (gatherQualityDropdown.value == 0)
        {
            gatherButton.interactable = false;
            return;
        }

        int reaCost = (gatherQualityDropdown.value - 1) * 17;
        
    }

	// Update is called once per frame
	void Update () {
	
	}
}
