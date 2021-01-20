using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player Player;

    public Text livesText;
    public Text killsText;
    
    void Start()
    {
        Player.OnLivesChange.AddListener(() =>
        { livesText.text = "Lives: " + Player.Lives.ToString(); });

        Player.OnKillsChange.AddListener(() =>
        { killsText.text = "Kills: " + Player.Kills.ToString(); });
        instance = this;    
    }


    public static void GameOver()
    {

    }
}
