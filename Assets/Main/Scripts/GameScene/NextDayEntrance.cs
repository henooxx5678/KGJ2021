using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

public class NextDayEntrance : MonoBehaviour {

    void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "Player") {
            GameSceneManager.current.PlayerGoNextDay();
        }
    }
}
