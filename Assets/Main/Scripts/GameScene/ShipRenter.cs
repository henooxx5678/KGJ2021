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
                    // got ship
                    print("got ship");
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
        if (isBeaching) {
            _defaultDialog = Dialog.lossSoMuch;
        }
        else {
            _defaultDialog = "";
        }
        dialogBox.DialogText = _defaultDialog;
    }

}
