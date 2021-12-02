using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignPlayer : MonoBehaviour
{
    [SerializeField] public Text playerOneText;
    [SerializeField] public Text playerTwoText;
    private PlayerInput playerOne;
    private PlayerInput playerTwo;
    private PlayerInput[] players;
    public bool updateScoreEnabled = false;


    void Start()
    {
        

    }
    public void AssignPlayers()
    {

        players = FindObjectsOfType<PlayerInput>();

        foreach(PlayerInput player in players)
        {
            if (player.IsPlayerOne)
            {
                playerOne = player;
            }
            else
            {
                playerTwo = player;
            }
        }
        
    }
    public void UpdateScore()
    {
        playerOneText.text = playerOne.score.ToString();
        if(playerTwo != null)
        {
            playerTwoText.text = playerTwo.score.ToString();
        }
        
    }


    
}
