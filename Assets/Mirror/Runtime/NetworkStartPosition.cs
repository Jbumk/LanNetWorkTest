using UnityEngine;

namespace Mirror
{
    /// <summary>Start position for player spawning, automatically registers itself in the NetworkManager.</summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Network/NetworkStartPosition")]
    [HelpURL("https://mirror-networking.gitbook.io/docs/components/network-start-position")]

    
    public class NetworkStartPosition : MonoBehaviour
    {
        public GameObject StartPosition;
        public GameObject Player1;
        public GameObject Player2;
        public GameObject Gamemanager;
        public NetworkManager manager;

        public void Awake()
        {
            Player1 = GameObject.Find("Player1");
            Player2 = GameObject.Find("Player2");
            Gamemanager = GameObject.Find("GameManager");
            manager = Gamemanager.GetComponent<NetworkManager>();


            NetworkManager.RegisterStartPosition(StartPosition.transform);
           

            if (manager.ChkPlayerCode() == 1)
            {
                Player1.transform.SetParent(transform);
            }else if (manager.ChkPlayerCode() == 2)
            {
                Player2.transform.SetParent(transform);
            }
        }

        public void OnDestroy()
        {
            NetworkManager.UnRegisterStartPosition(StartPosition.transform);
        }
    }
}
