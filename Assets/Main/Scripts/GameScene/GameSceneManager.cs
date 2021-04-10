using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

public class GameSceneManager : SingletonMonoBehaviour<GameSceneManager> {

    int _dayCount = 1;
    public int DayCount {
        get => _dayCount;
        set {
            _dayCount = value;
            UpdateAllDynamicTextDisplay();
        }
    }

    int _sentCuont = 0;
    public int SentCount {
        get => _sentCuont;
        set {
            _sentCuont = value;
            UpdateAllDynamicTextDisplay();
        }
    }


    protected override void Awake () {
        base.Awake();
    }

    void Start () {
        UpdateAllDynamicTextDisplay();
    }



    void UpdateAllDynamicTextDisplay () {
        foreach (var display in DynamicTextDisplay.list) {
            display.UpdateDisplay();
        }
        print("updated text displays");
    }

}
