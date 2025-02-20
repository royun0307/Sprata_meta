using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public abstract class Skull_BaseUI : MonoBehaviour
{
    protected Skull_UIManager uiManager;

    public virtual void Init(Skull_UIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    protected abstract Skull_UIState GetUIState();

    public void SetActive(Skull_UIState state)
    {
        gameObject.SetActive(GetUIState() == state);
    }
}
