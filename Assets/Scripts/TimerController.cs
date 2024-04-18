using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Slider timerSlider;
    public Text warningText;
    public GameObject failTxt;
    public Text scoreText; // ������ ��Ÿ���� UI Text
    public float totalTime = 30f;
    public int score = 0; // ����
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
        // �ð��� �� ���� �� ���� ���� ���� ���� �߰� ����
        if (timeLeft <= 0)
        {
            timeLeft = 0;

            failTxt.SetActive(true);
        }
        // Slider ������Ʈ
        timerSlider.value = timeLeft;
        // �ð��� ���� ó��
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
            // �ð��� 15�� �ʰ��� ���� �������� ��� ���� ��� �ʱ�ȭ
            timerSlider.fillRect.GetComponentInChildren<Image>().color = Color.green;
            flashing = false;
            warningText.text = "";
        }
    }
   
    public void CardMatchedSuccessfully()
    {
        // ī�带 ���߾��� �� ȣ��Ǵ� �Լ�
        // ���������� ���߾��� �� �߰����� �۾� ���� ����
        score += 10; // ���� 10�� ���� (���ϴ� ��ŭ ���� ����)
        UpdateScoreUI();
    }
    public void UpdateScoreUI()
    {
        scoreText.text = score.ToString() + " ��";
    }
    IEnumerator FlashSlider()
    {
        while (timeLeft <= 5)
        {
            timerSlider.fillRect.GetComponentInChildren<Image>().enabled = !timerSlider.fillRect.GetComponentInChildren<Image>().enabled;
            yield return new WaitForSeconds(0.2f); // �����̴� �ð��� 0.2�ʷ� ����
        }
    }
}
