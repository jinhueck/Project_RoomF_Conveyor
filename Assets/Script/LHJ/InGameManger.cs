using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InGameManger : MonoBehaviour
{

    public static InGameManger instance;


    public int boxcount;
    public int endgame;
    public int checkstar;
    public Image[] star;
    public Image Gage;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        SetGame(10);
        Time.timeScale = 1f;
    }

    void Update()
    {
        GameManager();
        StageStar();
    }

    void SetGame(int totalbox)
    {


        boxcount = 0;
        endgame = totalbox;
    }



    void GameManager()
    {
        if (boxcount >= endgame)
        {
            if (checkstar == 0)
                star[3].gameObject.SetActive(true);

            Time.timeScale = 0f;
        }

    }


    public void StageStar()
    {
        Gage.fillAmount = (float)checkstar / (float)endgame;
        if(checkstar==1)
        {
            star[0].gameObject.SetActive(true);
        }
        else if((float)checkstar>= (float)endgame /2)
        {
            star[1].gameObject.SetActive(true);
        }
        else if(checkstar== endgame)
        {
            star[2].gameObject.SetActive(true);
        }
    }
}
