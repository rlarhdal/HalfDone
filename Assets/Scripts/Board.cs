using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject card;
    // Start is called before the first frame update
    void Start()
    {
        //보드 초기화
        InitBoard();
    }

    void InitBoard()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5};

        // 카드 배치 - 강의 코드
        //arr = arr.OrderBy(x => Random.Range(0, arr.Length)).ToArray();

        //for (int i = 0; i < 12; i++)
        //{
        //    GameObject go = Instantiate(card, this.transform);

        //    float x = (i % 3) * 1.4f - 2.1f;
        //    float y = (i / 3) * 1.4f - 3.0f;

        //    go.transform.position = new Vector2(x, y);
        //    go.GetComponent<Card>().Setting(arr[i]);
        //}

        //// 카드 배치 - 다른 코드(배열 이용)
        for (int i = 0; i < arr.Length; i++)
        {
            //카드 섞기
            int j = Random.Range(i, arr.Length);
            if (i != j)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
            //카드 프리팹 생성
            GameObject go = Instantiate(card, this.transform);
            //위치 변경
            float x = (i % 3) * 1.6f - 1.6f;
            float y = (i / 3) * 1.6f - 3.5f;

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(arr[i]);
        }

        GameManager.instance.cardCount = arr.Length;

    }
}
