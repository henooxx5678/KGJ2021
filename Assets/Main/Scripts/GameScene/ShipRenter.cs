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
    public AudioSource visitSound;


    public string DefaultDialog {
        get {
            if (GameSceneManager.current.dock.IsBeaching)
                return Dialog.lossSoMuch;
            else
                return "";
        }
    }

    int _pineappleGotCount = 0;

    public override void Visited (Item item) {

        bool eventTriggered = false;

        if (GameSceneManager.current.HasShip) {
            if (GameSceneManager.current.dock.IsBeaching) {
                dialogBox.ShowDialog(Dialog.excavatorSent, false, DefaultDialog);
            }
            else {
                dialogBox.ShowDialog(Dialog.afterRent, false, DefaultDialog);
            }
        }
        else {
            if (item == Item.Pineapple) {
                _pineappleGotCount++;

                if (_pineappleGotCount >= 2) {

                    print("got ship");
                    GameSceneManager.current.overlayEventManager.PlayEvent(3);
                    eventTriggered = true;

                    dialogBox.ShowDialog("", false, DefaultDialog);
                    GameSceneManager.current.SentCount += 1000;

                    GameSceneManager.current.HasShip = true;
                    GameSceneManager.current.dock.UpdateShipShowing();
                }
                else if (_pineappleGotCount == 1) {
                    dialogBox.ShowDialog(Dialog.confirmRent, false, DefaultDialog);
                }
            }
            else {
                _pineappleGotCount = 0;

                dialogBox.ShowDialog(Dialog.howToRent, false, DefaultDialog);
            }
        }

        if (!eventTriggered && visitSound != null) {
            visitSound.Stop();
            visitSound.Play();
        }
    }

    public override void OnExit () {
        dialogBox.IsReturnable = true;
    }

    public void OnNewDay (bool isBeaching) {
        if (GameSceneManager.current.DayCount < debutDay) {
            gameObject.SetActive(false);
        }
        else {
            gameObject.SetActive(true);

            dialogBox.DialogText = DefaultDialog;
        }
    }

}
