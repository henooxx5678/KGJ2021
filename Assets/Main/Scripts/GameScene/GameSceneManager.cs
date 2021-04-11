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

    [Header("Visitable")]
    public ShipRenter shipRenter;
    public Dock       dock;


    public bool HasShip {get; set;} = false;

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
        NewDayAndStart();
    }


    public void PlayerGoNextDay () {

        bool everyoneEaten = true;
        foreach (Citizen citizen in Citizen.list) {
            if (!citizen.HasEatenToday) {
                everyoneEaten = false;
                break;
            }
        }

        if (!everyoneEaten) {
            overlayEventManager.PlayEvent(5);  // someone not eaten!
            return;
        }

        IsDayEnded = true;

        Global.current.transitionManager.FadeScreenOut( () => {
            NewDayAndStart();
        } );
    }


    void UpdateAllDynamicTextDisplay () {
        foreach (var display in DynamicTextDisplay.list) {
            display.UpdateDisplay();
        }
    }

    void UpdateCitizensAtDayStart () {
        foreach (Citizen citizen in Citizen.list) {
            citizen.OnNewDay();
        }
    }

    void NewDayAndStart () {
        DayCount += 1;
        IsDayStarted = false;
        IsDayEnded = false;
        UpdateCitizensAtDayStart();

        dock.OnNewDay();
        shipRenter.OnNewDay(dock.IsBeaching);

        Player.current.transform.SetPosXY(playerStartPoint.position);

        Global.current.transitionManager.FadeScreenIn( () => {
            IsDayStarted = true;
        } );
    }

}
