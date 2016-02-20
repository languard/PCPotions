using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

    public Witch player;
   

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        GenericItem.GenerateThreshold();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Witch GenerateNewWitch()
    {
        player = new Witch();
        return player;
    }

    public Witch GetCurrentWitch()
    {
        return player;
    }
}
