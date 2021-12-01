using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerInput : MonoBehaviourPunCallbacks, IPunObservable
{
    public bool IsPlayerOne;
    public int score;
    public int hits;

    public PlayerInput[] players;

    private void Start()
    {
        players = FindObjectsOfType<PlayerInput>();


        if (players.Length == 1)
        {
            IsPlayerOne = true;
        }
        else
        {
            IsPlayerOne = false;
        }
        
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
                Debug.Log("button pressed");
            }
        }
        
    }
}
