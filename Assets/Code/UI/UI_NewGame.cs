using UnityEngine;
using System.Collections;

public class UI_NewGame : MonoBehaviour {

    [Header("Witch Portrait")]
    public UnityEngine.UI.Image witchImage;
    public UnityEngine.UI.InputField witchName;
    public System.Collections.Generic.List<Sprite> witchPortraitList;
    public int selectedWitchPortrait = 0;

    [Header("Familiar Portrait")]
    public UnityEngine.UI.Image familiarImage;
    public UnityEngine.UI.InputField familiarName;
    public System.Collections.Generic.List<Sprite> familiarPortraitList;
    public int selectedFamiliarPortrait = 0;

    [Header("School Setup")]
    public UnityEngine.UI.Image schoolImage;
    public System.Collections.Generic.List<Sprite> schoolImageList;
    public int selectedSchoolImage = 1; //To make chaosah default

    [Header("Game Logic Refence")]
    public GameLogic gameLogic;

	// Use this for initialization
	void Start () {

        witchImage.sprite = witchPortraitList[0];
        familiarImage.sprite = familiarPortraitList[0];
        schoolImage.sprite = schoolImageList[1];

        //grab game logic
        try
        {
            gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        }
        catch
        {
            //for testing
            if (gameLogic == null) UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ClickNavigateWitchPortrait(int direction)
    {
        selectedWitchPortrait += direction;
        if (selectedWitchPortrait < 0) selectedWitchPortrait = witchPortraitList.Count - 1;
        if (selectedWitchPortrait >= witchPortraitList.Count) selectedWitchPortrait = 0;
        witchImage.sprite = witchPortraitList[selectedWitchPortrait];
    }

    public void ClickNavigateFamiliarPortrait(int direction)
    {
        selectedFamiliarPortrait += direction;
        if (selectedFamiliarPortrait < 0) selectedFamiliarPortrait = familiarPortraitList.Count - 1;
        if (selectedFamiliarPortrait >= familiarPortraitList.Count) selectedFamiliarPortrait = 0;
        familiarImage.sprite = familiarPortraitList[selectedFamiliarPortrait];
    }

    public void ClickNavigateSchoolImage(int direction)
    {
        selectedSchoolImage += direction;
        if (selectedSchoolImage < 0) selectedSchoolImage = schoolImageList.Count - 1;
        if (selectedSchoolImage >= schoolImageList.Count) selectedSchoolImage = 0;
        schoolImage.sprite = schoolImageList[selectedSchoolImage];
    }

    public void ClickStartGame()
    {
        Witch player = gameLogic.GenerateNewWitch();
        //witch name
        player.name = witchName.text.Trim();
        if (player.name.Length == 0) player.name = "Nameless";
        //witch portrait
        player.portrait = witchPortraitList[selectedWitchPortrait];
        //familiar name
        player.familiar.name = familiarName.text;
        //familiar protrait
        player.familiar.portait = familiarPortraitList[selectedFamiliarPortrait];
        //magic school
        player.magicSchoolImage = schoolImageList[selectedSchoolImage];
        player.magicSchool = player.magicSchoolImage.name; 
    }
}
