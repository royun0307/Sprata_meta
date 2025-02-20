using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skull_ScoreUI : Skull_BaseUI
{
    TextMeshProUGUI scoreText;
    TextMeshProUGUI bestScoreText;

    Button startButton;
    Button exitButton;

    protected override Skull_UIState GetUIState()
    {
        return Skull_UIState.Score;
    }

    public override void Init(Skull_UIManager uiManager)
    {
        base.Init(uiManager);

        scoreText = transform.Find("LevelText").GetComponent<TextMeshProUGUI>();
        bestScoreText = transform.Find("BestLevelText").GetComponent<TextMeshProUGUI>();
        startButton = transform.Find("StartButton").GetComponent<Button>();
        exitButton = transform.Find("ExitButton").GetComponent<Button>();

        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void SetUI(int score, int bestLevel)
    {
        scoreText.text = score.ToString();
        bestScoreText.text = bestLevel.ToString();
    }

    void OnClickStartButton()
    {
        uiManager.OnClickStart();
    }

    void OnClickExitButton()
    {
        uiManager.OnClickExit();
    }
}
