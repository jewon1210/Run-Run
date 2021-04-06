using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking_Window_Script : MonoBehaviour
{
    [SerializeField] GameObject[] StageNum;
    [SerializeField] Text HighScoreTxt;
    [SerializeField] Text PageTxt;

    Scene_Manager_Script SM;
    int[] ScoreFromSM;
    int currentPage;

    void Awake()
    {
        GameObject go = GameObject.Find("Scene_Manager");
        SM = go.GetComponent<Scene_Manager_Script>();
        ScoreFromSM = new int[2] { 0, 0};
        currentPage = 0;
    }
    void Start()
    {
    }

    void Update()
    {
        changePage(0);
    }

    public void changePage(int value)
    {
        if ((currentPage + value) == -1 || (currentPage + value) == 2)
            return;

        HighScoreTxt.text = ScoreFromSM[currentPage].ToString() + " <size=50>pt</size>";

        for(int i = 0; i < 4; i++)
        {
            if ((i) == currentPage)
            {
                StageNum[i].SetActive(true);
                PageTxt.text = "Page " + (currentPage+1).ToString() + "/4"; 
            }
            else
                StageNum[i].SetActive(false);
        }
        currentPage = currentPage + value;
    }

    public void FindOutScore()
    {
        //for (int i = 0; i < 4; i++)
        //    ScoreFromSM[i] = SM.HighScoreList(i);
        ScoreFromSM[0] = SM.HighScoreList(0);
        ScoreFromSM[1] = SM.HighScoreList(1);
    }
}
