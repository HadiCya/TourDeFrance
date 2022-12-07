using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
    private List<PlayerConfiguration> playerConfigs;

    [SerializeField]
    private int maxPlayers = 2;

    public static PlayerConfigurationManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) return;
        Instance = this;
        DontDestroyOnLoad(Instance);
        playerConfigs = new List<PlayerConfiguration>();
    }

    public void SetPlayerColor(int index, Material color)
    {
        playerConfigs[index].playerMaterial = color;
    }

    public void ReadyPlayer(int index)
    {
        playerConfigs[index].isReady = true;
        if( playerConfigs.Count == maxPlayers && playerConfigs.TrueForAll(p => p.isReady))
        {
            SceneManager.LoadScene("Bike Scene");
        }
    }
}
