using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiveManager : MonoBehaviour
{
    public GameObject[] levelLock;
    public GameObject[] levelUnlock;

    enum Achive { Normal, Hard }
    Achive[] achives;

    private void Awake()
    {
        achives = (Achive[])Enum.GetValues(typeof(Achive));

        if (!PlayerPrefs.HasKey("MyData"))
        {
            Init();
        }
    }

    void Init()
    {
        PlayerPrefs.SetInt("MyData", 1);

        foreach(Achive achive in achives)
        {
            PlayerPrefs.SetInt(achive.ToString(), 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UnlockLevel();
    }

    void UnlockLevel()
    {
        for(int i = 0; i < levelLock.Length; i++)
        {
            string achiveName = achives[i].ToString();
            bool isUnlock = PlayerPrefs.GetInt(achiveName) == 1;
            levelLock[i].SetActive(!isUnlock); //비활성화
            levelUnlock[i].SetActive(isUnlock); //활성화
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        foreach (Achive achive in achives)
        {
            CheckAchivement(achive);
        }
    }

    void CheckAchivement(Achive achive)
    {
        bool isAchive = false;

        switch (achive)
        {
            case Achive.Normal:
                isAchive = GameManager.instance.endPanel.activeSelf == true;
                if (isAchive && PlayerPrefs.GetInt(achive.ToString()) == 0)
                {
                    PlayerPrefs.SetInt(achive.ToString(), 1);
                }
                break;
            case Achive.Hard:
                isAchive = GameManager.instance.endPanel.activeSelf == true;
                if (GameManager.instance.isPlayed == true && isAchive && PlayerPrefs.GetInt(achive.ToString()) == 0)
                {
                    PlayerPrefs.SetInt(achive.ToString(), 1);
                }
                break;
        }
    }
}
