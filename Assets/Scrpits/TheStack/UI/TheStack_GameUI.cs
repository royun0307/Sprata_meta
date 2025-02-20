using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class TheStack_GameUI : TheStack_BaseUI
{
    TextMeshProUGUI scoreText;
    TextMeshProUGUI comboText;

    protected override TheStack_UIState GetUIState()
    {
        return TheStack_UIState.Game;
    }

    public override void Init(TheStack_UIManager uiManager)
    {
        base.Init(uiManager);

        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        comboText = transform.Find("ComboText").GetComponent<TextMeshProUGUI>();
    }

    public void SetUI(int score, int combo)
    {
        scoreText.text = score.ToString();
        comboText.text = combo.ToString();
    }
}
