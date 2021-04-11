using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

using DoubleHeat;
using DoubleHeat.Utilities;

public class Citizen : Visitable {

    public static List<Citizen> list = new List<Citizen>();

    public float noSameAsYesterdayPossibility;
    public float noSourPossibility;
    public float noPekoTeaPossibility;
    public float noSushiPossibility;

    public bool isMango = false;

    [Header("REFS")]
    public DialogBox dialogBox;
    public AudioSource visitedSound;
    public AudioSource acceptSound;

    public bool HasEatenToday => (_gotToday != Item.None);

    Decision _decision;
    Item     _gotYesterday = Item.None;
    Item     _gotToday = Item.None;

    void Awake () {
        list.Add(this);
    }

    void Destroy () {
        list.Remove(this);
    }

    public void InitDecision () {
        _decision = new Decision(noSameAsYesterdayPossibility, noSourPossibility, noPekoTeaPossibility, noSushiPossibility, _gotYesterday);
    }

    public override void Visited (Item item) {
        if (HasEatenToday)
            return;


        bool eventTriggered = false;
        Decide(item, out eventTriggered);

        // play sound
        if (!eventTriggered && visitedSound != null) {
            visitedSound.Stop();
            visitedSound.Play();
        }

    }

    public override void OnExit () {
        dialogBox.IsReturnable = true;
    }

    public void OnNewDay () {
        InitDecision();
        dialogBox.SetToAllFine();

        _gotYesterday = _gotToday;
        _gotToday = Item.None;
    }

    void Decide (Item item, out bool eventTriggered) {

        eventTriggered = false;

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

        _gotToday = item;
        OnAccept(item, out eventTriggered);
    }

    void OnAccept (Item item, out bool eventTriggered) {

        eventTriggered = false;

        switch (item) {
            case Item.Pineapple:
                GameSceneManager.current.SentCount += 1;
                GameSceneManager.current.overlayEventManager.PlayEvent(0);
                eventTriggered = true;
                dialogBox.ShowDialog("", false);
                break;
            case Item.Mango:
                GameSceneManager.current.overlayEventManager.PlayEvent(1);
                eventTriggered = true;
                dialogBox.ShowDialog("", false);
                break;
            case Item.PekoTea:
                dialogBox.ShowDialog(Dialog.pekoTea, false);
                break;
            case Item.Sushi:
                dialogBox.ShowDialog("", false);
                eventTriggered = true;
                GameSceneManager.current.overlayEventManager.PlayEvent(2);
                break;
        }

        if (!eventTriggered) {
            if (acceptSound != null) {
                acceptSound.Stop();
                acceptSound.Play();

                eventTriggered = true;
            }
        }
    }

    void OnReject (Item item) {

    }


    public struct Decision {
        public bool noSameAsYesterday;
        public bool noSour;
        public bool noPekoTea;
        public bool noSushi;

        public Decision (float noSameAsYesterdayPossibility, float noSourPossibility, float noPekoTeaPossibility, float noSushiPossibility, Item gotYesterday) {
            noSameAsYesterday = Random.value <= noSameAsYesterdayPossibility;
            noSour            = Random.value <= noSourPossibility;
            noPekoTea         = Random.value <= noPekoTeaPossibility;
            noSushi           = Random.value <= noSushiPossibility;

            if (noSour && noPekoTea && noSushi) {
                noSour = false;
            }

            if (gotYesterday == Item.PekoTea && noSameAsYesterday && noSour && noSushi) {
                noSushi = false;
            }

            if (gotYesterday == Item.Sushi && noSameAsYesterday && noSour && noPekoTea) {
                noPekoTea = false;
            }
        }
    }

}
