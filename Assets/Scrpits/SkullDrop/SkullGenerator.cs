using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullGenerator : MonoBehaviour
{
    float interval = 0.5f;
    float currentTime = 0;
    float nextTime = 5f;
    bool isFlag = true;
    bool isGameOver = true;

    public int level = 1;
    public int bestLevel = 1;
    int skullNum = 10;

    public GameObject skull;

    public const string BestLevelKey = "Skull_BestScore";//점수 저장 키 

    private void Start()
    {
        bestLevel = PlayerPrefs.GetInt(BestLevelKey, 1);
    }

    private void Update()
    {
        if (!isGameOver)
        {
            currentTime += Time.deltaTime;
            if (currentTime < nextTime && isFlag)
            {
                isFlag = false;
                StartCoroutine(creatSkull());
            }
            else if (currentTime >= nextTime && !isFlag)
            {
                isFlag = true;
                level++;
                Skull_UIManager.Instance.UpdateLevel();
                skullNum += 5;
                currentTime = 0;
            }
        }
    }

    private IEnumerator creatSkull()
    {
        yield return null;
        for (int i = 0; i < skullNum; i++)
        {
            float x = Random.Range(-10f, 10f);
            float y = Random.Range(3f, 5f);

            Instantiate(skull, new Vector3(x, y, 0), Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }

    public void GameOver() 
    {
        isGameOver = true;
        if (bestLevel < level)
        {
            bestLevel = level;
            PlayerPrefs.SetInt(BestLevelKey, level);
        }
        Skull_UIManager.Instance.SetLevelUI();
    }

    public void Restart()
    {
        Skull_UIManager.Instance.UpdateLevel();
        isGameOver = false;
        currentTime = 0;
        level = 1;
        skullNum += 5;
        isFlag = true;
    }
}
