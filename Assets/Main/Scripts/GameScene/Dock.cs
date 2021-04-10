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

    public DialogBox dialogBox;

    public bool IsBeaching {get; set;} = false;
    public bool HasSentToday {get; set;} = false;


    public override void Visited (Item item) {

        if (GameSceneManager.current.HasShip) {

            if (IsBeaching) {
                dialogBox.ShowDialog(Dialog.shipBeached, false);
            }
            else {
                if (!HasSentToday) {
                    if (item == Item.Pineapple) {
                        // go go
                        print("go go pineapple");
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
            dialogBox.ShowDialog(Dialog.noShip, false);
        }
    }

}
