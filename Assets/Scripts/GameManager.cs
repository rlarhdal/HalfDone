using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("# 변수")]
    public int cardCount = 0;
    int attempts = 0;
    float time = 0.0f;
    int lv;

    [Header("# 컴포넌트")]
    public Text timeTxt;
    public Text attemptsTxt;
    public Board board;

    [Header("# 스크립트")]
    public Card firstCard;
    public Card secondCard;

    [Header("# 게임오브젝트")]
    public GameObject lvUi;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        attemptsTxt.text = attempts.ToString();
        //시간이 0이 되면 실패 표시
        //endTxt.SetActive(true);
        //Time.timeScale = 30.0f;
        if (time > 30.0f)
            GameOver();
    }

    public void Matched()
    {
        attempts++;
        if (firstCard.idx == secondCard.idx)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;

            //팀원의 이름 표시
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }
    void GameOver()
    {
        Time.timeScale = 0.0f;
    }

    //레벨 별 보드 초기화
    public void easyMode()
    {
        lv = 0;
        board.InitBoard(lv);
        lvUi.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void normalMode()
    {
        lv = 1;
        board.InitBoard(lv);
        lvUi.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void hardMode()
    {
        lv = 2;
        board.InitBoard(lv);
        lvUi.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
