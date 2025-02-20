using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skull_HomeUI : Skull_BaseUI
{
    Button startButton;
    Button explainButton;
    Button exitButton;

    public Image explain;

    bool isExplain = false;

    protected override Skull_UIState GetUIState()
    {
        return Skull_UIState.Home;
    }

    public override void Init(Skull_UIManager uiManager)
    {
        base.Init(uiManager);

        startButton = transform.Find("StartButton").GetComponent<Button>();
        explainButton = transform.Find("ExplainButton").GetComponent<Button>();
        exitButton = transform.Find("ExitButton").GetComponent<Button>();
        explain = transform.Find("Explain").GetComponent<Image>();

        startButton.onClick.AddListener(OnClickStartButton);
        explainButton.onClick.AddListener(OnClickExplainButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    void OnClickStartButton()
    {
        uiManager.OnClickStart();
    }

    void OnClickExitButton()
    {
        uiManager.OnClickExit();
    }

    void OnClickExplainButton()
    {
        isExplain = !isExplain;
        uiManager.OnClickExplain(isExplain);
    }
}
