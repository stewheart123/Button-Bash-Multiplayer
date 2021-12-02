using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviourPunCallbacks, IPunObservable
{
    public bool IsPlayerOne;
    public int score;
    public int hits;
    private AssignPlayer assignPlayer;
    //private Text scoreText;

    public PlayerInput[] players;

    private void Start()
    {
        players = FindObjectsOfType<PlayerInput>();
        assignPlayer = GameObject.Find("Native UI").GetComponent<AssignPlayer>();

        if (players.Length == 1)
        {
            IsPlayerOne = true;
            //scoreText = GameObject.Find("P1 Score Text").GetComponent<Text>();
        }
        else
        {
            IsPlayerOne = false;
            //scoreText = GameObject.Find("P2 Score Text").GetComponent<Text>();
            
            
        }
        assignPlayer.AssignPlayers();
        
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(IsPlayerOne);
            stream.SendNext(score);
        }
        else
        {
            this.IsPlayerOne = (bool)stream.ReceiveNext();
            this.score = (int)stream.ReceiveNext();
        }
        
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                score++;
                //assignPlayer.UpdateScore();
                //scoreText.text = score.ToString();
                
                Debug.Log("button pressed");
            }
        }
        
    }
}
