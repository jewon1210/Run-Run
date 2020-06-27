using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingame_Manager : MonoBehaviour
{
    public enum eGameState
    {
        NONE = 0,
        READY,
        GO,
        PLAY,
        END,
        RESULT
    }

    [SerializeField] GameObject[] _prefabsStage;
    [SerializeField] GameObject _prefabsResultWindow;
    [SerializeField] GameObject _PauseButton;
    [SerializeField] GameObject[] _Background;
    [SerializeField] int stage_num;

    eGameState _currentGameState;

    bool _isDeath;
    MessageBox _MsgBox;
    float _timeCheck = 0;
    int _TotalScore = 0;        //획득 점수 저장
    bool _isSuccess;

    Text _txtScore;

    static Ingame_Manager _uniqueInstance;

    public static Ingame_Manager _instance
    {
        get { return _uniqueInstance; }
    }

    public bool _isDead
    {
        set { _isDeath = _isDead; }
        get { return _isDeath; }
    }

    public eGameState _nowGameState
    {
        get { return _currentGameState; }
    }

    void Awake()
    {
        _uniqueInstance = this;
        _isDead = false;
    }

    void Start()
    {
        //GameObject go = GameObject.Find("MessageBG");
        //_MsgBox = go.GetComponent<MessageBox>();
    }

    void Update()
    {
    }

    public void isDead()
    {
        _PauseButton.SetActive(false);
        _Background[0].SetActive(false);
        _Background[1].SetActive(true);
    }

    public void In_game(int stage)
    {
        GameObject go;
        switch (stage)
        {
            case 1:
                go = Instantiate(_prefabsStage[stage]);
                break;
            case 2:
                go = Instantiate(_prefabsStage[stage]);
                break;
            case 3:
                go = Instantiate(_prefabsStage[stage]);
                break;
        }
    }

    public void Restart_Game()
    {
        Scene_Manager_Script.instance.Restart_Game();
    }
    public void Go_Home()
    {
        Scene_Manager_Script.instance.Go_Home();
    }
    public void Pause()
    {
        Obstacle_Manager._instance.MovePause();
    }
    public void Resume_Game()
    {
        Obstacle_Manager._instance.MoveStart();
    }

    public void AddPoint(int point)
    {
        _TotalScore += point;
        //Debug.Log("Score : " + _TotalScore.ToString());
        _txtScore.text = _TotalScore.ToString();
    }

}
