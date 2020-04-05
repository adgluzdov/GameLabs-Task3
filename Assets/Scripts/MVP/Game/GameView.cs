using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IGameView {
    void ShowLobby();
    void CloseLobby();
    void AddOnFightListener(OnFightListener listener);
    void ShowBattle();
    void CloseBattle();
    IShipView CreateShipA();
    IShipView CreateShipB();
    void ShowWinShipA();
    void ShowWinShipB();
    void ShowError(string message);
}

public interface OnFightListener {
    void OnFight(string[] weaponsA, string[] modulesA, string[] weaponsB, string[] modulesB);
}

public class GameView : MonoBehaviour, IGameView
{
    public GameObject Lobby;
    public GameObject Battle;
    public GameObject Win;
    public GameObject Error;
    public Text WinText;
    public InputField WeaponsA;
    public InputField ModulesA;
    public InputField WeaponsB;
    public InputField ModulesB;
    public Button Fight;
    public ShipView ShipView1Prefab;
    public ShipView ShipView2Prefab;
    public Text errorMessage;

    void Start() {
        Lobby.SetActive(false);
        Battle.SetActive(false);
        Win.SetActive(false);
        Error.SetActive(false);
        new GamePresenter(this);
    }

    void IGameView.AddOnFightListener(OnFightListener listener)
    {
        Fight.onClick.AddListener(() => {
            listener.OnFight(
                WeaponsA.text.Split(','), 
                ModulesA.text.Split(','), 
                WeaponsB.text.Split(','), 
                ModulesB.text.Split(','));
        });
    }

    void IGameView.CloseBattle()
    {
        Battle.SetActive(false);
    }

    void IGameView.CloseLobby()
    {
        Lobby.SetActive(false);
    }

    void IGameView.ShowBattle()
    {
        Battle.SetActive(true);
    }

    void IGameView.ShowLobby()
    {
        Lobby.SetActive(true);
    }

    IShipView IGameView.CreateShipA()
    {
        return Instantiate(ShipView1Prefab, Battle.transform);
    }

    IShipView IGameView.CreateShipB()
    {
        return Instantiate(ShipView2Prefab, Battle.transform);
    }

    void IGameView.ShowWinShipA()
    {
        Win.gameObject.SetActive(true);
        WinText.text = "Победил корабль 1";
    }

    void IGameView.ShowWinShipB()
    {
        Win.gameObject.SetActive(true);
        WinText.text = "Победил корабль 2";
    }

    void IGameView.ShowError(string message)
    {
        Error.SetActive(true);
        errorMessage.text = message;
    }
}
