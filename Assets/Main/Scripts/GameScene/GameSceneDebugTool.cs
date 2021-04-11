using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

public class GameSceneDebugTool : MonoBehaviour {

    #if UNITY_EDITOR

    public float hor;
    public float vert;
    public float time;
    public bool  isDayRunning;
    public bool  isOverlayEventPlaying;
    public bool  isPlayerControllable;

    void Update () {

        time = Time.time;

        if (Input.GetKeyDown(KeyCode.Q)) {
            GameSceneManager.current.SentCount += 1;
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            GameSceneManager.current.DayCount += 1;
        }
        for (int i = 0 ; i < GameSceneManager.current.overlayEventManager.events.Length ; i++) {
            if (Input.inputString.Contains((i + 5).ToString())) {
                GameSceneManager.current.overlayEventManager.PlayEvent(i);
            }
        }

        hor = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");

        isDayRunning = GameSceneManager.current.IsDayRunning;
        isOverlayEventPlaying = GameSceneManager.current.overlayEventManager.IsEventPlaying;
        isPlayerControllable = Player.current.IsControllable;

    }

    #endif

}
