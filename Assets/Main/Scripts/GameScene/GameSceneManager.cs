using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

public class GameSceneManager : SingletonMonoBehaviour<GameSceneManager> {

    [Header("REFS")]
    public OverlayEventManager overlayEventManager;
    public Transform playerStartPoint;


    public bool IsDayStarted {get; private set;} = false;
    public bool IsDayEnded {get; private set;} = false;
    public bool IsDayRunning => IsDayStarted && !IsDayEnded;

    int _dayCount = 0;
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
        NewDay();
    }


    public void PlayerGoNextDay () {
        IsDayEnded = true;

        Global.current.transitionManager.FadeScreenOut( () => {
            NewDay();
            Global.current.transitionManager.FadeScreenIn( () => {
                IsDayStarted = true;
            } );
        } );
    }


    public void OnPineappleSent () {
        overlayEventManager.PlayEvent(0);
    }

    public void OnMangoSent () {
        overlayEventManager.PlayEvent(1);
    }


    void UpdateAllDynamicTextDisplay () {
        foreach (var display in DynamicTextDisplay.list) {
            display.UpdateDisplay();
        }
    }

    void UpdateCitizensAtDayStart () {
        foreach (Citizen citizen in Citizen.list) {
            citizen.InitDecision();
            citizen.dialogBox.SetToAllFine();
        }
    }

    void NewDay () {
        DayCount += 1;
        IsDayStarted = false;
        IsDayEnded = false;
        UpdateCitizensAtDayStart();
        Player.current.transform.SetPosXY(playerStartPoint.position);
    }

}
