using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManger : MonoBehaviour {

    public static InGameManger instance;
    public ArriveBox endstage;
         
    public int totalbox;
    public int endgame;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        SetGame();

    }
    void Start ()
    {
      

    }
	
	void Update ()
    {
        GameManager();
    }

    void SetGame()
    {
        totalbox = 0;
        endgame = 5;
    }

    void GameManager()
    {
        if (totalbox == endgame)
        {
            endstage.StageStar();
            Time.timeScale = 0.3f;          
        }
    
    }

}
