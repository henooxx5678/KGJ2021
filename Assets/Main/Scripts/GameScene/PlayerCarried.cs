using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

public class PlayerCarried : MonoBehaviour {

    public GameObject[] carriedGOs;


    void Update () {
        // SWITCH
        for (int i = 0 ; i < carriedGOs.Length ; i++) {
            if (Input.inputString.Contains( (i + 1).ToString() )) {
                SwitchTo(i);
                break;
            }
        }
    }

    public void SwitchTo (int index) {
        for (int i = 0 ; i < carriedGOs.Length ; i++) {
            if (i == index) {
                carriedGOs[i].SetActive(true);
            }
            else {
                carriedGOs[i].SetActive(false);
            }
        }
    }


}
