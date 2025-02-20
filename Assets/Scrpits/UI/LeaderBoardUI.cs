using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoardUI : BaseUI
{
    TextMeshProUGUI gameTitle;
    TextMeshProUGUI bestScore;

    protected override UIState GetUIState()
    {
        return UIState.LeaderBoard;
    }

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        gameTitle = transform.Find("GameTitle").GetComponent<TextMeshProUGUI>();
        bestScore = transform.Find("BestScoreText").GetComponent<TextMeshProUGUI>();
    }

    public void SetText(string title, int score)
    {
        gameTitle.text = title;
        bestScore.text = score.ToString();
    }
}
