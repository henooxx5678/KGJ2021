using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

public class GameSceneDebugTool : MonoBehaviour {


    #if UNITY_EDTIOR

    void Update () {
        if (Input.GetKeyDown(KeyCode.Q)) {
            GameSceneManager.current.SentCount += 1;
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            GameSceneManager.current.DayCount += 1;
        }
    }

    #endif

}
