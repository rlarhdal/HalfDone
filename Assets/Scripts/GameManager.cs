using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Card firstCard;
    public Card secondCard;

    public GameObject endPanel;
    public GameObject RetryBtn;

    public int cardCount = 0;

    private Canvas canvas;

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
        canvas = FindObjectOfType<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        //시간이 0이 되면 실패 표시
        //endTxt.SetActive(true);
        //Time.timeScale = 30.0f;
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;

            Transform targetName = canvas.transform.Find("name_" + firstCard.idx);
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
            firstCard.CloseCard();
            secondCard.CloseCard();

            Transform WrongText = canvas.transform.Find("WrongTxt");
            WrongText.gameObject.SetActive(true);
            StartCoroutine(DeactivateObject(WrongText.gameObject, 1f));
        }

        firstCard = null;
        secondCard = null;
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
        Debug.Log("unretry");
    }
}
