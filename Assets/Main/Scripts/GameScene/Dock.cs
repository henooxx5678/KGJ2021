using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

public class Dock : Visitable {

    public float beachPossibility = 0.5f;

    [Header("REFS")]
    public DialogBox dialogBox;
    public AudioSource visitSound;


    public bool IsBeaching {get; set;} = false;
    public bool HasSentToday {get; set;} = false;


    public override void Visited (Item item) {

        if (HasSentToday)
            return;

        bool eventTriggerd = false;

        if (GameSceneManager.current.HasShip) {

            if (IsBeaching) {
                dialogBox.ShowDialog(Dialog.shipBeached, false);
            }
            else {
                if (!HasSentToday) {
                    if (item == Item.Pineapple) {

                        print("go go pineapple");
                        GameSceneManager.current.overlayEventManager.PlayEvent(4);
                        eventTriggerd = true;

                        dialogBox.ShowDialog("", false);
                        GameSceneManager.current.SentCount += 100;
                        HasSentToday = true;
                    }
                    else {
                        dialogBox.ShowDialog(Dialog.shipOnlyForPineapple, false);
                    }
                }
            }
        }
        else {
            if (GameSceneManager.current.DayCount < GameSceneManager.current.shipRenter.debutDay) {
                dialogBox.ShowDialog(Dialog.dockClosed, false);
            }
            else {
                dialogBox.ShowDialog(Dialog.noShip, false);
            }
        }

        if (!eventTriggerd) {
            if (visitSound != null) {
                visitSound.Stop();
                visitSound.Play();
            }
        }
    }

    public override void OnExit () {
        dialogBox.IsReturnable = true;
    }

    public void OnNewDay () {

        if (IsBeaching) {
            IsBeaching = false;
        }

        if (HasSentToday) {
            if (Random.value <= beachPossibility) {
                IsBeaching = true;
            }
        }

        HasSentToday = false;
    }

}
