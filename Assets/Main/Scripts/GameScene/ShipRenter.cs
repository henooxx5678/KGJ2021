using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

public class ShipRenter : Visitable {

    public int debutDay = 4;

    [Header("REFS")]
    public DialogBox dialogBox;

    int _pineappleGotCount = 0;
    string _defaultDialog = "";

    public override void Visited (Item item) {

        if (GameSceneManager.current.HasShip) {
            dialogBox.ShowDialog(Dialog.afterRent, false, _defaultDialog);
        }
        else {
            if (item == Item.Pineapple) {
                _pineappleGotCount++;

                if (_pineappleGotCount >= 2) {

                    print("got ship");
                    GameSceneManager.current.overlayEventManager.PlayEvent(3);

                    dialogBox.ShowDialog("", false, _defaultDialog);
                    GameSceneManager.current.SentCount += 1000;

                    GameSceneManager.current.HasShip = true;
                }
                else if (_pineappleGotCount == 1) {
                    dialogBox.ShowDialog(Dialog.confirmRent, false, _defaultDialog);
                }
            }
            else {
                _pineappleGotCount = 0;

                dialogBox.ShowDialog(Dialog.howToRent, false, _defaultDialog);
            }
        }
    }

    public void OnNewDay (bool isBeaching) {
        if (GameSceneManager.current.DayCount < debutDay) {
            gameObject.SetActive(false);
        }
        else {
            gameObject.SetActive(true);

            if (isBeaching) {
                _defaultDialog = Dialog.lossSoMuch;
            }
            else {
                _defaultDialog = "";
            }
            dialogBox.DialogText = _defaultDialog;
        }
    }

}