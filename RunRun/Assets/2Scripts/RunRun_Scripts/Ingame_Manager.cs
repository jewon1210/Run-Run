using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingame_Manager : MonoBehaviour
{
    public enum eGameState
    {
        STORY = 0,
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
    [SerializeField] GameObject _prefabsStoryWindow;

    public int stageNum;

    eGameState _currentGameState;

    bool _isDeath, _isEnd, _isSuccess, _isClicked;
    float _timeCheck = 0, _waitReadyTime = 3.0f;
    int _TotalScore = 0;        //획득 점수 저장

    Obstacle_Manager obManger;
    MessageBox _MsgBox;
    Player_Control _player;
    Monster_Control _monster;
    GameObject go;
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
        set { _currentGameState = _nowGameState; }
        get { return _currentGameState; }
    }

    void Awake()
    {
        stageNum = Scene_Manager_Script.instance._nowStage;

        _uniqueInstance = this;
        _isDead = false;
        _isEnd = false;
        _isSuccess = false;
        _isClicked = false;

        stageSelect(stageNum);

        go = GameObject.FindGameObjectWithTag("stage");
        obManger = go.transform.GetChild(0).GetComponent<Obstacle_Manager>();
        go = GameObject.FindGameObjectWithTag("Monster");
        _monster = go.GetComponent<Monster_Control>();
        go = GameObject.FindGameObjectWithTag("Player");
        _player = go.GetComponent<Player_Control>();
        go = GameObject.Find("MessageBG");
        _MsgBox = go.GetComponent<MessageBox>();
        go = GameObject.Find("ScoreBG");
        _txtScore = go.transform.GetChild(1).GetComponent<Text>();
    }

    void Start()
    {
        GameStory();
    }

    void LateUpdate()
    {
        switch (_currentGameState)
        {
            case eGameState.STORY:
                if (_isClicked)
                {
                    storyWindowControl();
                    GameReady();
                }
                break;
            case eGameState.READY:
                _timeCheck += Time.deltaTime;
                if (_timeCheck >= _waitReadyTime)
                    GameGO();
                break;
            case eGameState.GO:
                _timeCheck += Time.deltaTime;
                if (_timeCheck >= 0.5f)
                    GamePlay();
                break;
            case eGameState.END:
                _timeCheck += Time.deltaTime;
                if (_timeCheck >= 1.0f)
                    resultWindowOpen(_isSuccess);
                break;
        }
    }

    public void stageSelect(int num)
    {
        switch (stageNum)
        {
            case 0:
                go = Instantiate(_prefabsStage[num]);
                break;
            case 1:
                go = Instantiate(_prefabsStage[num]);
                break;
        }
    }

    public void GameStory()
    {
        _currentGameState = eGameState.STORY;
        ControlObject(false);
        _player.ani_pause();
        _monster.isPause();
    }
    public void GameReady()
    {
        _currentGameState = eGameState.READY;
        _MsgBox.EnableMessage(true, "Ready~");
    }
    public void GameGO()
    {
        _currentGameState = eGameState.GO;
        _MsgBox.EnableMessage(true, "Run~!!");
        _timeCheck = 0;
    }
    public void GamePlay()
    {
        _currentGameState = eGameState.PLAY;

        _MsgBox.EnableMessage();

        ControlObject(true);
        _player.ani_start();
        _monster.isMove();
    }
    public void GameNextStage()
    {
        go = GameObject.FindGameObjectWithTag("stage");
        Destroy(go);
        ++stageNum;
        stageSelect(stageNum);
    }


    public void isEnd(bool isSuccess)
    {
        _currentGameState = eGameState.END;
        _isEnd = true;
        if (isSuccess)
            _isSuccess = isSuccess;
        else
            _isDead = isSuccess;
        ControlObject(false);
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
        obManger.MovePause();
        _player.ani_pause();
        _monster.isPause();
    }
    public void Resume_Game()
    {
        obManger.MoveStart();
        _player.ani_start();
        _monster.isMove();
    }

    public void AddPoint(int point)
    {
        _TotalScore += point;
        _txtScore.text = _TotalScore.ToString();
    }

    public void resultWindowOpen(bool isSuccess)
    {
        _currentGameState = eGameState.RESULT;

        GameObject go = Instantiate(_prefabsResultWindow);
        ResultWindowScript Rwnd = go.GetComponent<ResultWindowScript>();
        Rwnd.OpenWindow(isSuccess, _TotalScore);
        Scene_Manager_Script.instance.HighScoreSave(stageNum, _TotalScore);
    }

    public void ControlObject(bool control)//true 받으면 출발
    {
        if (control)
            obManger.MoveStart();
        else
            obManger.MovePause();

        _Background[0].SetActive(control);  // true이면 출발
        _Background[1].SetActive(!control); // true이면 멈춤
        _PauseButton.SetActive(control); 
    }

    public void storyWindowControl()
    {
        _prefabsStoryWindow.SetActive(false);
    }
    public void StoryQuitButton()
    {
        _isClicked = true;
    }
}
