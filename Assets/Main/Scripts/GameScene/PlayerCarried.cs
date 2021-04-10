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

    public Item CurrentCarried {get; private set;} = (Item) 0;

    void Start () {
        SwitchTo((int) CurrentCarried);
    }

    void Update () {
        // SWITCH
        if (Player.current.IsControllable) {
            for (int i = 0 ; i < carriedGOs.Length ; i++) {
                if (Input.inputString.Contains( (i + 1).ToString() )) {
                    SwitchTo(i);
                    break;
                }
            }
        }
    }

    public void SwitchTo (int index) {

        if (index < 0 || index > carriedGOs.Length)
            return;

        CurrentCarried = (Item) index;

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
