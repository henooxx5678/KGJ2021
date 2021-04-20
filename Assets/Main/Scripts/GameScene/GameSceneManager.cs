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
    public NewspaperManager newspaperManager;

    [Header("Visitable")]
    public ShipRenter shipRenter;
    public Dock       dock;


    public bool HasWon {get; private set;} = false;
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


    public void SendPineapple (int amount) {
        int result = SentCount + amount;

        if (result < SentCount)
            SentCount = System.Int32.MaxValue;
        else
            SentCount = result;
    }


    public void PlayerGoNextDay (bool force = false) {

        bool everyoneEaten = true;
        foreach (Citizen citizen in Citizen.list) {
            if (!citizen.HasEatenToday) {
                everyoneEaten = false;
                break;
            }
        }

        if (!force && !everyoneEaten) {
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

        if (SentCount >= 40000) {
            Win();
            return;
        }

        DayCount += 1;
        IsDayStarted = false;
        IsDayEnded = false;
        UpdateCitizensAtDayStart();

        dock.OnNewDay();
        shipRenter.OnNewDay(dock.IsBeaching);

        Player.current.transform.SetPosXY(playerStartPoint.position);


        if (DayCount == 1) {
            newspaperManager.Play(0);
        }
        else if (DayCount == shipRenter.debutDay) {
            newspaperManager.Play(1);
        }

        Global.current.transitionManager.FadeScreenIn( () => {
            IsDayStarted = true;
        } );
    }

    void Win () {
        HasWon = true;
        newspaperManager.Play(3);
        Global.current.transitionManager.FadeScreenIn( () => {

        } );
    }

}
