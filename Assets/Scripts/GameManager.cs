using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("# ����")]
    public int cardCount = 0;
    int attempts = 0;
    float time = 0.0f;
    int lv;

    [Header("# ������Ʈ")]
    public Text timeTxt;
    public Text attemptsTxt;
    public Board board;

    [Header("# ��ũ��Ʈ")]
    public Card firstCard;
    public Card secondCard;

    [Header("# ���ӿ�����Ʈ")]
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
        //�ð��� 0�� �Ǹ� ���� ǥ��
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

            //������ �̸� ǥ��
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

    //���� �� ���� �ʱ�ȭ
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
