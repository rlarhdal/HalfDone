using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TimerController timerController;
    AudioSource audioSource;
    public AudioClip match;
    public AudioClip miss;

    [Header("# 변수")]
    public int cardCount = 0;
    int attempts = 0;
    float time = 0.0f;
    int lv;
   // int score = 0;
    [Header("# 컴포넌트")]
    public Text timeTxt;
    public Text attemptsTxt;
    public Board board;

    [Header("# 스크립트")]
    public Card firstCard;
    public Card secondCard;

    [Header("# 게임오브젝트")]
    public GameObject lvUi;
    public GameObject endPanel;
    public GameObject RetryBtn;
    public GameObject WrongText;
    public List<GameObject> namelist;

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
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.3f;

        //timerController = GetComponent<TimerController>();
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
            audioSource.PlayOneShot(match);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            //score += 10;
            timerController.CardMatchedSuccessfully();
            //GameObject targetName = GameObject.Find("name_" + firstCard.idx);
            GameObject targetName = namelist[firstCard.idx];
            targetName.gameObject.SetActive(true);
            // 일정 시간 후에 비활성화
            StartCoroutine(DeactivateObject(targetName.gameObject, 1f));


            if (cardCount == 0)
            {

                endPanel.SetActive(true);
                RetryBtn.SetActive(true);

            }
        }
        else
        {
            audioSource.PlayOneShot(miss);
            firstCard.CloseCard();
            secondCard.CloseCard();

            //WrongText = GameObject.Find("WrongTxt");
            WrongText.gameObject.SetActive(true);
            StartCoroutine(DeactivateObject(WrongText.gameObject, 1f));
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

    IEnumerator DeactivateObject(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }

    public void Retry()
    {
        endPanel.SetActive(false);
        RetryBtn.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }
}
