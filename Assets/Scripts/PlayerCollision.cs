using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviourPun
{
    private AgoraManager agoraManager;
    private GameObject playerPrefab;
    private int SelfplayerID;
    private string channelName = "App";
    void Start()
    {
        agoraManager = GameObject.FindObjectOfType<AgoraManager>();
        playerPrefab = GameObject.FindWithTag("Player");
        SelfplayerID = playerPrefab.GetComponent<Player>().playerID;
    }

    void OnTriggerEnter2D(Collider2D otherActor)
    {
        
        Debug.Log("Trigger Enter Detected");
        if (otherActor.CompareTag("Player"))
        {
            /* int otherPlayerID = otherActor.GetComponent<Player>().playerID;

            string channelName = ChannelManager.GetPlayerChannel(otherPlayerID);

            if (channelName == null)
            {
                channelName = ChannelManager.GenerateRandomChannelNames();
                ChannelManager.AddPlayerToChannel(channelName, otherPlayerID);
            }

            if (!ChannelManager.IsPlayerInChannel(SelfplayerID))
            {
                ChannelManager.AddPlayerToChannel(channelName, SelfplayerID);
            }
            */

            agoraManager.Join(channelName);
            
        }
    }

    void OnTriggerExit2D(Collider2D otherActor)
    {
        Debug.Log("Trigger Exit Detected");
        if (otherActor.CompareTag("Player"))
        {
            // string channelName = ChannelManager.GetPlayerChannel(SelfplayerID);

            if (channelName != null)
            {
                // ChannelManager.RemovePlayerFromChannel(channelName, SelfplayerID);
                agoraManager.LeaveChannel();
            }

            
        }
    }


   
}
