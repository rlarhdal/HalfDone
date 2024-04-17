using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;

    public GameObject front;
    public GameObject openCount;
    public GameObject back;

    public Animator anim;

    public SpriteRenderer frontImage;
    public SpriteRenderer backImage;

    float openTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.firstCard == this)
        {
            openTime += Time.deltaTime;
        }
        if (openTime > 2.0f)
        {
            openCount.SetActive(false);
            Invoke("CloseCardInvoke", 0.0f);
            GameManager.instance.firstCard = null;
        }
    }
    public void Setting(int num)
    {
        idx = num;
        frontImage.sprite = Resources.Load<Sprite>($"{idx}");
    }


    public void OpenCard()
    {
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);
        anim.SetBool("isOpen_1", true);

        if (GameManager.instance.firstCard == null)
        {
            openCount.SetActive(true);
            GameManager.instance.firstCard = this;
        }
        else
        {
            openCount.SetActive(false);
            GameManager.instance.secondCard = this;
            GameManager.instance.Matched();
        }
    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 0.5f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }

    //카드 닫기 함수
    void CloseCardInvoke()
    {
        anim.SetBool("isOpen_1", false);
        front.SetActive(false);
        back.SetActive(true);
        anim.SetBool("isOpen", false);
        backImage.color = new Color(backImage.color.r - 0.1f, backImage.color.g - 0.1f, backImage.color.b - 0.1f);
        openTime = 0.0f;
    }
}
