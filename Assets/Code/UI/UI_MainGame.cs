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
    public Text elapsedTimeValue;

    [Header("UI: House Panel")]
    public GameObject housePanel;
    public List<Text> ingredientLabel;
    public List<Text> ingredientValue;
    public List<Text> ingredientQualityLabel;
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
    public Text gatherReaCostValue;
    public Text gatherTimeCostValue;
    public Text gatherIngredientNameLabel;
    public Ingredient gatherActiveIngredient;
    public int gatherIngredientIndex;
    public Dropdown gatherSelectIngredient;
    public Text gatherBonusQualityValue;
    public Dropdown gatherReaInfusionDropdown;

    Zone activeZone;
    

    //HAAAAAAAAACKS!!!!!!11!1!
    public List<Sprite> zoneBackgrounds;

    [Header("UI: Brew Panel")]
    public GameObject brewPanel;
    public List<Dropdown> brewIngredients;
    public Dropdown brewMethodDropdown;
    public Dropdown brewInfuseDropdown;
    public Dropdown brewPotionList;
    public Text brewIngredientQualityValue;
    public Text brewTimeValue;
    public Text brewReaCostValue;
    public Text brewPotionQualityValue;
    public Button brewPotionButton;
    Potion activePotion;
    Ingredient[] selectedPotionIngredients = new Ingredient[3];

    GameLogic gameLogic;
    int reaCost = 0;
    int timeCost = 0;
    int bonusQuality = 0;
    int ingredientQuality = 0;
    bool missingIngredient = false;

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
        elapsedTimeValue.text = player.GetTime();
    }

    public void ActivateHousePanel()
    {
        //disable other panels
        //activate house
        housePanel.SetActive(true);
        brewPanel.SetActive(false);
        gatherPanel.SetActive(false);
        //make sure house is cleaned up
        gameLogic.GetCurrentWitch().house.CleanUpIngredients();
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
                ingredientQualityLabel[currentIndex].gameObject.SetActive(false);
            }
            else
            {
                ingredientLabel[currentIndex].gameObject.SetActive(true);
                ingredientValue[currentIndex].gameObject.SetActive(true);
                ingredientQualityLabel[currentIndex].gameObject.SetActive(true);
                ingredientLabel[currentIndex].text = player.house.ingredientStock[i].name + ":";
                ingredientValue[currentIndex].text = player.house.ingredientStock[i].amount.ToString();
                ingredientQualityLabel[currentIndex].text = GenericItem.GetThresholdName(player.house.ingredientStock[i].quality);
            }
        }

        //check for empty list
        if(player.house.ingredientStock.Count == 0)
        {
            ingredientLabel[2].text = "There is nothing here";
            ingredientLabel[2].gameObject.SetActive(true);
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
        activeZone = GameDatabase.Instance.GetZoneReferenceByName(targetZone);
#if UNITY_EDITOR
        if (activeZone == null)
        {
            Debug.LogError("ZONE FAILED TO LOAD");
            return;
        }
#endif
        zoneName.text = activeZone.name;
        zoneDescription.text = activeZone.description;
        for(int i=0; i< zoneBackgrounds.Count; i++)
        {
            if(zoneBackgrounds[i].name == activeZone.spriteName)
            {
                zoneImage.sprite = zoneBackgrounds[i];
                break;
            }
        }

        //setup dropdown to select ingredient
        gatherSelectIngredient.ClearOptions();
        //generate string list
        List<string> temp = new List<string>();
        for(int i=0; i<activeZone.ingredients.Count; i++)
        {
            temp.Add(activeZone.ingredients[i].name);
        }
        gatherSelectIngredient.AddOptions(temp);

        SetGatherActiveIngredient();

        CalculateGatherReaAndTimeCost();

    }

    public void SetGatherActiveIngredient()
    {
        gatherActiveIngredient = activeZone.ingredients[gatherSelectIngredient.value];
        gatherIngredientNameLabel.text = gatherActiveIngredient.name;
    }

    public void ActivateBrewPanel()
    {
        //disable other panels
        //activate Brew
        housePanel.SetActive(false);
        brewPanel.SetActive(true);
        gatherPanel.SetActive(false);
        //update information
        //populate potion dropdown
        List<string> potionNames = new List<string>();
        List < Potion > potionList = GameDatabase.Instance.GetPotionListReference();
        foreach(Potion curPotion in potionList)
        {
            potionNames.Add(curPotion.name);
        }
        brewPotionList.ClearOptions();
        brewPotionList.AddOptions(potionNames);
        activePotion = GameDatabase.Instance.GetPotionReferenceByName(potionNames[0]);

        SetActivePotion();
    }

    public void SetActivePotion()
    {
        activePotion = GameDatabase.Instance.GetPotionReferenceByIndex(brewPotionList.value);
        //print(brewPotionList.captionText.text);
        BrewSetIngredients();
        BrewUpdateSelectedIngredient();
        BrewUpdateCostTimeQuality();
    }

    public void BrewSetIngredients()
    {
        Witch player = gameLogic.GetCurrentWitch();

        //clear the three lists
        brewIngredients[0].ClearOptions();
        brewIngredients[1].ClearOptions();
        brewIngredients[2].ClearOptions();

        //load in the needed ingredients
        missingIngredient = false;
        for(int i=0; i<3; i++)
        {
            List<Ingredient> availableIngredients = player.house.GetIngredientsByID(activePotion.ingredientList[i].ID);
            List<string> ingredientNames = new List<string>();
            for(int j=0; j<availableIngredients.Count; j++)
            {
                ingredientNames.Add(availableIngredients[j].name + " - " + GenericItem.GetThresholdName(availableIngredients[j].quality));
            }

            //account for no ingredients
            if(availableIngredients.Count == 0)
            {
                ingredientNames.Add("Missing - " + activePotion.ingredientList[i].name);
            }
            brewIngredients[i].AddOptions(ingredientNames);
        }

        BrewUpdateSelectedIngredient();
    }

    public void BrewUpdateCostTimeQuality()
    {
        Witch player = gameLogic.GetCurrentWitch();
        int tempCost = 0;

        bonusQuality = 0;
        timeCost = 0;
        reaCost = activePotion.baseReaCost;

        brewPotionButton.interactable = true;

        //method first
        if(brewMethodDropdown.value == 0)
        {
            brewPotionButton.interactable = false;
        }
        else if(brewMethodDropdown.value == 1)
        {
            //plain old standard time
            timeCost = activePotion.brewTime;
        }
        else if(brewMethodDropdown.value == 2)
        {
            timeCost = Mathf.CeilToInt(activePotion.brewTime / 2.0f);
            tempCost = 17 * activePotion.brewTime / 3 - player.vision;  //floor op
            if(tempCost < Mathf.CeilToInt(activePotion.brewTime / 6.0f) * 17)  //ceil ensures cost is at least 17
            {
                tempCost = Mathf.CeilToInt(activePotion.brewTime / 6.0f) * 17;
            }
            reaCost += tempCost;
        }
        else if(brewMethodDropdown.value == 3)
        {
            //picky, 2x time +quality
            timeCost = activePotion.brewTime * 2;
            bonusQuality += 1;
        }
        else if(brewMethodDropdown.value == 4)
        {
            //intense, 2x time, + quality
            timeCost = activePotion.brewTime * 2;
            player.dreams += 17 + player.potential;
        }

        //infusion
        tempCost = brewInfuseDropdown.value - 1;
        if (tempCost < 0) tempCost = 0;
        bonusQuality += tempCost;   //at this point it is equal to level
        tempCost = tempCost * 17 - player.vision;
        reaCost += tempCost;

        //update labels
        brewTimeValue.text = timeCost.ToString() + " Minutes";

        if(reaCost > player.dreams)
        {
            brewPotionButton.interactable = false;
            brewReaCostValue.text = "<color=red>" + reaCost.ToString() + "</color>";
        }
        else
        {
            brewReaCostValue.text = "<color=black>" + reaCost.ToString() + "</color>";
        }

        //final quality
        brewPotionQualityValue.text = (bonusQuality + ingredientQuality).ToString();

        //missing ingredients?
        if (missingIngredient) brewPotionButton.interactable = false;
    }

    public void BrewUpdateSelectedIngredient()
    {
        //ensure all ingredients are valid
        ValidateIngredients();

        int temp = 0;

        //sum up the contribution of all ingredients
        ingredientQuality = 0;
        for(int i=0; i<3; i++)
        {
            if(selectedPotionIngredients[i] != null)
            {
                temp += GenericItem.GetThresholdValue(selectedPotionIngredients[i].quality);
            }
        }
        print("Value lookup is " + temp);
        ingredientQuality = GenericItem.GetThresholdLevel(temp) + 1;
        if (temp > 0) brewIngredientQualityValue.text = ingredientQuality.ToString();
        else brewIngredientQualityValue.text = "0";
    }

    public void ClickBrewPotionButton()
    {
        int temp = (int)(activePotion.valueBase + activePotion.qualityScale * GenericItem.GetThresholdValue(bonusQuality + ingredientQuality));
        Witch player = gameLogic.GetCurrentWitch();
        player.ko += temp;
        player.dreams -= reaCost;
        player.house.ConsumeIngredients(selectedPotionIngredients);
        gameLogic.GetCurrentWitch().ElapseTime(timeCost);
        SetActivePotion();  //force all potion information to update
        UpdatePlayerInfo();
    }

    public bool ValidateIngredients()
    {
        bool result = true;
        missingIngredient = false;

        for(int i=0; i<3; i++)
        {
            string[] temp = brewIngredients[i].captionText.text.Split('-');
            if(temp[0].Trim() == "Missing")
            {
                result = false;
                selectedPotionIngredients[i] = null;
                missingIngredient = true;
            }
            else
            {
                //get  name
                string ingName = temp[0].Trim();
                //get quality
                int ingQuality = GenericItem.GetQualityByName(temp[1].Trim()) + 1;      //index is returned, not quality level
                //print("Name is " + ingName + " and quality is " + ingQuality.ToString());
                selectedPotionIngredients[i] = gameLogic.GetCurrentWitch().house.GetIngredientByNameAndQuality(ingName, ingQuality);
            }
        }

        return result;
    }

    public void CalculateGatherReaAndTimeCost()
    {

        Witch player = gameLogic.GetCurrentWitch();

        gatherButton.interactable = true;
        bonusQuality = 0;

        //set Rea cost to zero and disable gather button if no quality is set
        if (gatherQualityDropdown.value == 0)
        {
            gatherButton.interactable = false;
            reaCost = 0;
            bonusQuality = 0;
        }
        else
        {
            reaCost = (gatherQualityDropdown.value - 1) * 17;
            bonusQuality = gatherQualityDropdown.value - 1;
        }

        //set time cost to 0 and disable gather button if no method set
        if(gatherMethodDropdownn.value == 0)
        {
            gatherButton.interactable = false;
            timeCost = 0;
        }
        else if(gatherMethodDropdownn.value == 1)
        {
            //normal
            timeCost = gatherActiveIngredient.gatherTime;
        }
        else if(gatherMethodDropdownn.value == 2)
        {
            //quickly, 1/2 time
            timeCost = Mathf.CeilToInt(gatherActiveIngredient.gatherTime / 2.0f);
            int tempCost = 17 * gatherActiveIngredient.gatherTime / 2 - player.vision;  //this is a floor, basically
            if (tempCost < Mathf.CeilToInt(gatherActiveIngredient.gatherTime / 4) * 17)   //need to make sure cost is at least 1.
            {
                tempCost = Mathf.CeilToInt(gatherActiveIngredient.gatherTime / 4) * 17;
            }
        }
        else if(gatherMethodDropdownn.value == 3)
        {
            //picky, 2x time, + quality
            timeCost = gatherActiveIngredient.gatherTime * 2;
            bonusQuality += 1;
        }
        else if(gatherMethodDropdownn.value == 4)
        {
            //intently, 2x time, +Rea
            timeCost = gatherActiveIngredient.gatherTime * 2;
            reaCost -= (17 + player.potential);
        }

        //infusion
        if(gatherReaInfusionDropdown.value > 1)
        {
            bonusQuality += gatherReaInfusionDropdown.value - 1;
            reaCost += (gatherReaInfusionDropdown.value - 1) * 17 - player.vision;
        }

        //update labels
        if (reaCost > player.dreams)
        {
            gatherReaCostValue.text = "<color=red>" + reaCost.ToString() + "</color>";
            gatherButton.interactable = false;
        }
        else
        {
            gatherReaCostValue.text = "<color=black>" + reaCost.ToString() + "</color>";
        }

        gatherTimeCostValue.text = timeCost.ToString() + " minutes";
        gatherBonusQualityValue.text = bonusQuality.ToString();

    }

    public void ClickGatherIngredient()
    {
        //reduce Rea
        gameLogic.GetCurrentWitch().dreams -= reaCost;
        //increment time
        gameLogic.GetCurrentWitch().ElapseTime(timeCost);

        //add ingredient
        Ingredient temp = gatherActiveIngredient.Clone() as Ingredient;
        temp.quality += bonusQuality;
        gameLogic.GetCurrentWitch().house.AddIngredient(temp);

        UpdatePlayerInfo();
        CalculateGatherReaAndTimeCost();
    }

	// Update is called once per frame
	void Update () {
	
	}
}
