using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

public class MenuSceneManager : MonoBehaviour {

    public Text versionInfo;

    void Start () {
        versionInfo.text = Application.version;
    }

    void Update () {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            print("Quit");
            Application.Quit();
        }
        else if (Input.anyKeyDown) {
            Global.current.transitionManager.FadeScreenOut( () => {
                SceneManager.LoadScene("GameScene");
            } );

        }
    }

}
