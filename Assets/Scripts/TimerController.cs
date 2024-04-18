using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Slider timerSlider;
    public Text warningText;
    public GameObject failTxt;
    public Text scoreText; // 점수를 나타내는 UI Text
    public float totalTime = 30f;
    public int score = 0; // 점수
    private float timeLeft;
    private bool flashing;
    void Start()
    {
        timeLeft = totalTime;
        flashing = false;
        timerSlider.maxValue = totalTime;
        UpdateScoreUI();
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        // 시간이 다 됐을 때 게임 오버 등의 로직 추가 가능
        if (timeLeft <= 0)
        {
            timeLeft = 0;

            failTxt.SetActive(true);
        }
        // Slider 업데이트
        timerSlider.value = timeLeft;
        // 시간에 따른 처리
        if (timeLeft <= 15)
        {
            timerSlider.fillRect.GetComponentInChildren<Image>().color = Color.red;
            if (timeLeft <= 5)
            {
                if (!flashing)
                {
                    flashing = true;
                    StartCoroutine(FlashSlider());
                }
                warningText.text = "Warning!";
            }
            else
            {
                flashing = false;
                warningText.text = "";
            }
        }
        else
        {
            // 시간이 15초 초과일 때는 빨간색과 경고 문자 모두 초기화
            timerSlider.fillRect.GetComponentInChildren<Image>().color = Color.green;
            flashing = false;
            warningText.text = "";
        }
    }
   
    public void CardMatchedSuccessfully()
    {
        // 카드를 맞추었을 때 호출되는 함수
        // 성공적으로 맞추었을 때 추가적인 작업 수행 가능
        score += 10; // 점수 10점 증가 (원하는 만큼 수정 가능)
        UpdateScoreUI();
    }
    public void UpdateScoreUI()
    {
        scoreText.text = score.ToString() + " 점";
    }
    IEnumerator FlashSlider()
    {
        while (timeLeft <= 5)
        {
            timerSlider.fillRect.GetComponentInChildren<Image>().enabled = !timerSlider.fillRect.GetComponentInChildren<Image>().enabled;
            yield return new WaitForSeconds(0.2f); // 깜빡이는 시간을 0.2초로 변경
        }
    }
}
