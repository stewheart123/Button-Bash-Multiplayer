using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignPlayer : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;
    public int playerOneScore;
    public int playerTwoScore;
    [SerializeField] Text playerOneDisplay;
    [SerializeField] Text playerTwoDisplay;
    public PlayerInput[] players;
    
    void Start()
    {
        players = FindObjectsOfType<PlayerInput>();

        Debug.Log("players visible =" + players.Length);
        if(players.Length == 1)
        {
            foreach (PlayerInput player in players)
            {
                if (player.IsPlayerOne)
                {
                    playerOne = player.gameObject;                    
                }
                
            }
        }
        if(players.Length == 2)
        {
            foreach (PlayerInput player in players)
            {
                if (player.IsPlayerOne)
                {
                    playerOne = player.gameObject;                    
                }
                if (!player.IsPlayerOne)
                {
                    playerTwo = player.gameObject;                    
                }
            }

        }

    }

    void Update()
    {
        if(players.Length == 1)
        {
            playerOneDisplay.text = playerOne.GetComponent<PlayerInput>().score.ToString();
        }
        if(players.Length == 2)
        {
            playerOneDisplay.text = playerOne.GetComponent<PlayerInput>().score.ToString();
            playerTwoDisplay.text = playerTwo.GetComponent<PlayerInput>().score.ToString();
        }
        
    }
}
