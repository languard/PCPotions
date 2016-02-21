using UnityEngine;
using System.Collections;
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
    public Text ingredientOneLabel;
    public Text ingredientTwoLabel;
    public Text ingredientThreeLabel;
    public Text ingredientFourLabel;
    public Text ingredientFiveLabel;
    public Text ingredientSixLabel;
    public Text ingredientOneValue;
    public Text ingredientTwoValue;
    public Text ingredientThreeValue;
    public Text ingredientFourValue;
    public Text ingredientFiveValue;
    public Text ingredientSixValue;

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
	
	// Update is called once per frame
	void Update () {
	
	}
}
