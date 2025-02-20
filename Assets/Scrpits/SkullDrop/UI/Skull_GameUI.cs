using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Skull_GameUI : Skull_BaseUI
{
    TextMeshProUGUI scoreText;

    protected override Skull_UIState GetUIState()
    {
        return Skull_UIState.Game;
    }

    public override void Init(Skull_UIManager uiManager)
    {
        base.Init(uiManager);

        scoreText = transform.Find("LevelText").GetComponent<TextMeshProUGUI>();
    }

    public void SetUI(int score)
    {
        scoreText.text = score.ToString();
    }
}
