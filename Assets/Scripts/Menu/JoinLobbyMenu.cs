using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinLobbyMenu : MonoBehaviour
{
    [SerializeField] GameObject onlinePage;
    [SerializeField] InputField addressInput;

    private void Start()
    {
        CheckersNetworkManager.ClientOnConnected += HandleClientConnected;
    }

    private void OnDestroy()
    {
        CheckersNetworkManager.ClientOnConnected -= HandleClientConnected;
    }

    void HandleClientConnected() { 
        onlinePage.SetActive(false);
        gameObject.SetActive(false);    
    }

    public void Join()
    {
        NetworkManager.singleton.networkAddress = addressInput.text;
        NetworkManager.singleton.StartClient();
    }
}
