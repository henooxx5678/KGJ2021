using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

public class Citizen : MonoBehaviour {

    public static List<Citizen> list = new List<Citizen>();

    public float noSameAsYesterdayPossibility;
    public float noSourPossibility;
    public float noPekoTeaPossibility;
    public float noSushiPossibility;

    public bool isMango = false;

    [Header("REFS")]
    public DialogBox dialogBox;
    public AudioSource visitedSound;

    Decision _decision;
    Item     _gotYesterday = Item.None;

    void Awake () {
        list.Add(this);
    }

    void Destroy () {
        list.Remove(this);
    }

    public void InitDecision () {
        _decision = new Decision(noSameAsYesterdayPossibility, noSourPossibility, noPekoTeaPossibility, noSushiPossibility);
    }

    public void ReturnNormal () {
        dialogBox.SetToAllFine();
    }

    public void Visited (Item item) {

        // play sound
        if (visitedSound != null) {
            visitedSound.Stop();
            visitedSound.Play();
        }



    }

    void Decide (Item item) {

        if (isMango) {
            if (item == Item.Mango) {

                dialogBox.ShowDialog(Dialog.youRude);
                OnReject(item);
                return;
            }
        }

        if (_decision.noSameAsYesterday) {
            if (item == _gotYesterday) {

                dialogBox.ShowDialog(Dialog.sameAsYesterday);
                OnReject(item);
                return;
            }
        }

        if (_decision.noSour) {
            if (item == Item.Pineapple || item == Item.Mango) {

                dialogBox.ShowDialog(Dialog.noSour);
                OnReject(item);
                return;
            }
        }

        if (_decision.noPekoTea) {
            if (item == Item.PekoTea) {

                dialogBox.ShowDialog(Dialog.noPekoTea);
                OnReject(item);
                return;
            }
        }

        if (_decision.noSushi) {
            if (item == Item.Sushi) {

                dialogBox.ShowDialog(Dialog.noSushi);
                OnReject(item);
                return;
            }
        }

        OnAccept(item);
    }

    void OnAccept (Item item) {

        switch (item) {
            case Item.Pineapple:
                GameSceneManager.current.OnPineappleSent();
                break;
            case Item.Mango:
                GameSceneManager.current.OnMangoSent();
                break;
            case Item.PekoTea:
                dialogBox.ShowDialog(Dialog.pekoTea);
                break;
            case Item.Sushi:
                break;
        }
    }

    void OnReject (Item item) {

    }


    public struct Decision {
        public bool noSameAsYesterday;
        public bool noSour;
        public bool noPekoTea;
        public bool noSushi;

        public Decision (float noSameAsYesterdayPossibility, float noSourPossibility, float noPekoTeaPossibility, float noSushiPossibility) {
            noSameAsYesterday = Random.value <= noSameAsYesterdayPossibility;
            noSour            = Random.value <= noSourPossibility;
            noPekoTea         = Random.value <= noPekoTeaPossibility;
            noSushi           = Random.value <= noSushiPossibility;
        }
    }

}
