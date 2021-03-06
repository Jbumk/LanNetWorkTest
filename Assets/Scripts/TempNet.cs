using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror{
    public class TempNet : MonoBehaviour
    {
        NetworkManager manager;
        
        private void Awake()
        {
            manager = GetComponent<NetworkManager>();
        }

        private void Update()
        {
            if(NetworkClient.isConnected && !NetworkClient.ready) { 
}
        }

        public void ServerStart()
        {
            if (!NetworkClient.isConnected && !NetworkServer.active)
            {
                if (NetworkClient.active)
                {
                    return;
                }
                if (Application.platform != RuntimePlatform.WebGLPlayer)
                {
                    manager.StartHost();
                }
            }
        }

        public void ClientStart()
        {
            if (!NetworkClient.isConnected && !NetworkServer.active)
            {
                if (NetworkClient.active)
                {
                    return;
                }
                manager.StartClient();
            }
        }


        public void ConnectEnd()
        {
            if(NetworkServer.active && NetworkClient.isConnected)
            {
                if (manager.ChkPlayerCode() == 1)
                {
                    manager.StopHost();
                }
            }else if (NetworkClient.isConnected)
            {
                if (manager.ChkPlayerCode() == 2)
                {
                    manager.StopClient();
                }
            }
        }

    }
}
