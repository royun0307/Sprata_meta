using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public abstract class TheStack_BaseUI : MonoBehaviour
{
    protected TheStack_UIManager uiManager;

    public virtual void Init(TheStack_UIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    protected abstract TheStack_UIState GetUIState();

    public void SetActive(TheStack_UIState state)
    {
        gameObject.SetActive(GetUIState() == state);
    }
}
