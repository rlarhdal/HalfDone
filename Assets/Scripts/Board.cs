using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject card;

    public void InitBoard(int lv)
    {
        switch (lv)
        {
            case 0:
                int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };

                // ī�� ��ġ - �ٸ� �ڵ�(�迭 �̿�)
                for (int i = 0; i < arr.Length; i++)
                {
                    //ī�� ����
                    int j = Random.Range(i, arr.Length);
                    if (i != j)
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                    //ī�� ������ ����
                    GameObject go = Instantiate(card, this.transform);
                    //��ġ ����
                    float x = (i % 3) * 1.6f - 1.6f;
                    float y = (i / 3) * 1.6f - 3.5f;

                    go.transform.position = new Vector2(x, y);
                    go.GetComponent<Card>().Setting(arr[i]);
                }
                GameManager.instance.cardCount = arr.Length;
                break;

            case 1:
                int[] arr1 = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

                // ī�� ��ġ - �ٸ� �ڵ�(�迭 �̿�)
                for (int i = 0; i < arr1.Length; i++)
                {
                    //ī�� ����
                    int j = Random.Range(i, arr1.Length);
                    if (i != j)
                    {
                        int temp = arr1[i];
                        arr1[i] = arr1[j];
                        arr1[j] = temp;
                    }
                    //ī�� ������ ����
                    GameObject go = Instantiate(card, this.transform);
                    //��ġ ����
                    float x = (i % 4) * 1.4f - 2.1f;
                    float y = (i / 4) * 1.4f - 3.0f;

                    go.transform.position = new Vector2(x, y);
                    go.GetComponent<Card>().Setting(arr1[i]);
                }
                GameManager.instance.cardCount = arr1.Length;
                break;
            default:
                int[] arr2 = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };

                // ī�� ��ġ - �ٸ� �ڵ�(�迭 �̿�)
                for (int i = 0; i < arr2.Length; i++)
                {
                    //ī�� ����
                    int j = Random.Range(i, arr2.Length);
                    if (i != j)
                    {
                        int temp = arr2[i];
                        arr2[i] = arr2[j];
                        arr2[j] = temp;
                    }
                    //ī�� ������ ����
                    GameObject go = Instantiate(card, this.transform);
                    //��ġ ����
                    float x = (i % 4) * 1.4f - 2.1f;
                    float y = (i / 4) * 1.4f - 4.0f;

                    go.transform.position = new Vector2(x, y);
                    go.GetComponent<Card>().Setting(arr2[i]);
                }
                GameManager.instance.cardCount = arr2.Length;
                break;
        }
    }
}
