using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private Text inputFieldText;

    [SerializeField] private TextMeshProUGUI playerName;

    public List<Character> characterList = new List<Character>();

    public int initialAlive;
    public int currentAlive;

    public int coin;

    public bool isGaming;

    public NavMeshData[] navMeshDatas;
    private int currentNavMeshIndex = 0;

    public static LevelManager instance;
    private void Awake()
    {
        instance = this;
        characterList.Add(player);
    }

    void Start()
    {
        currentAlive = initialAlive;
        isGaming = false;
        coin = 200;
        DisnableALlCharacters();
        UIManager.instance.UpdateCoin();
    }

    private void Update()
    {
        if (currentAlive == 1 && player.isDead == false && isGaming == true)
        {
            UIManager.instance.ShowWinPanel();
            player.Dance();
            isGaming = false;
        }
    }

    public void RemakeLevel()
    {
        bool isWin = !player.isDead;
        NavMesh.RemoveAllNavMeshData();
        if (isWin)
        {
            currentNavMeshIndex++;
            NavMesh.AddNavMeshData(navMeshDatas[currentNavMeshIndex]);
        }
        else
        {
            NavMesh.AddNavMeshData(navMeshDatas[currentNavMeshIndex]);
        }
        DeleteCharacters();
        RespawnCharacters();
        UIManager.instance.ShowJoystick();
        UIManager.instance.ShowAliveText();
        currentAlive = initialAlive;
        isGaming = true;
        PlayGame();
    }

    public void DeleteCharacters()
    {
        if (!player.isDead)
        {
            characterList.Remove(player);
        }
        while (characterList.Count > 0)
        {
            for (int j = 0; j < characterList[Constant.FIRST_INDEX].pooledWeaponList.Count; j++)
            {
                if (characterList[Constant.FIRST_INDEX].pooledWeaponList[j].gameObject.activeSelf)
                {
                    characterList[Constant.FIRST_INDEX].pooledWeaponList[j].gameObject.SetActive(false);
                }
            }
            BotManager.instance.Despawn(characterList[Constant.FIRST_INDEX] as Bot);
        }
        characterList.Clear();
    }

    public void RespawnCharacters()
    {
        characterList.Add(player);
        player.OnInit();
        for (int i = 0; i < BotManager.instance.botList.Count; i++)
        {
            characterList.Add(BotManager.instance.botList[i]);
            BotManager.instance.Spawn();
        }
    }

    public void DeleteThisElementInEnemyLists(Character character)
    {
        for (int i = 0; i < characterList.Count; i++)
        {
            if (characterList[i].enemyList.Contains(character))
            {
                characterList[i].enemyList.Remove(character);
            }
        }
    }

    public void PlayGame()
    {
        UIManager.instance.ShowJoystick();  
        UIManager.instance.ShowIndicators();
        UIManager.instance.ShowCanvasName();
        UIManager.instance.ShowAliveText();
        EnableALlCharacters();
        playerName.text = inputFieldText.text;
        currentAlive = initialAlive;
        isGaming = true;
    }

    public void EnableALlCharacters()
    {
        for(int i = 0; i < BotManager.instance.botList.Count; i++)
        {
            BotManager.instance.botList[i].ChangeState(new PatrolState());
        }
        isGaming = true;
    }

    public void DisnableALlCharacters()
    {
        for (int i = 0; i < BotManager.instance.botList.Count; i++)
        {
            BotManager.instance.botList[i].ChangeState(new IdleState());
        }
        isGaming = false;
    }
}