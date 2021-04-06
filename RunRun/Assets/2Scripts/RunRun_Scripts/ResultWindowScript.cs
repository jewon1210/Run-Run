using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultWindowScript : MonoBehaviour
{
    [SerializeField] GameObject _SuccessWind;
    [SerializeField] GameObject _FailedWind;
    [SerializeField] Text _textScoreSucc;
    [SerializeField] Text _textScoreFail;

    int _targetScore;
    float _curScore;
    bool _isCount, _isSuccess;

    void Start()
    {
    }

    void Update()
    {
        if (!_isCount)
            return;
        _curScore += (Time.deltaTime * _targetScore) / 3;
        if (_curScore >= _targetScore)
        {
            _curScore = _targetScore;
            _isCount = false;
        }
        ShowScore((int)_curScore);

    }
    void ShowScore(int nowScore)
    {
        if(_isSuccess)
            _textScoreSucc.text = nowScore.ToString() + " <size=50>pt</size>";
        else
            _textScoreFail.text = nowScore.ToString() + " <size=50>pt</size>";
    }

    public void OpenWindow(bool isSuccess, int score)
    {
        _isSuccess = isSuccess;
        _SuccessWind.SetActive(isSuccess);
        _FailedWind.SetActive(!isSuccess);
        _targetScore = score;
        _isCount = true;
        _curScore = 0;

        if (isSuccess)
            BGM_Manager_Script._instance.PlayBGMSound(BGM_Manager_Script.eTypeBGM.GAMEOVER);
        else
            BGM_Manager_Script._instance.PlayBGMSound(BGM_Manager_Script.eTypeBGM.FAIL);
    }

    public void ClickHomeButton()
    {
        Scene_Manager_Script.instance.Go_Home();

    }
    public void ClickRestartButton()
    {
        Scene_Manager_Script.instance.Restart_Game();
    }
    public void ClickNextButton()
    {
        Scene_Manager_Script.instance.Next_Stage();
    }

}
