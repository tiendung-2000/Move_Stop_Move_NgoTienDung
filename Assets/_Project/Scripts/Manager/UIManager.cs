using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private Text aliveText;
    [SerializeField] private GameObject aliveTextObj;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private GameObject weaponShop;
    [SerializeField] private GameObject hatArea;
    [SerializeField] private GameObject pantsArea;
    [SerializeField] private GameObject shieldArea;
    [SerializeField] private GameObject fullsetArea;
    [SerializeField] private GameObject indicators;
    [SerializeField] private GameObject CanvasName;

    public static UIManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        HideJoystick();
        HideCanvasName();
        HideIndicators();
        HideAliveText();
    }

    private void Update()
    {
        aliveText.text = LevelManager.instance.currentAlive.ToString();
    }
    public void CloseAll()
    {
        HideJoystick();
        HideLosePanel();
        HideWinPanel();
        HideWeaponShop();
        HideIndicators();
        HideCanvasName();
        HideAliveText();
    }
    
    public void ShowJoystick()
    {
        CloseAll();
        joystick.gameObject.SetActive(true);
        joystick.enabled = true;
    }

    public void HideJoystick()
    {
        joystick.enabled = false;
        joystick.gameObject.SetActive(false);
    }
    public void ShowLosePanel()
    {
        CloseAll();
        losePanel.SetActive(true);
    }

    public void HideLosePanel()
    {
        losePanel.SetActive(false);
    }

    public void ShowWinPanel()
    {
        CloseAll();
        winPanel.SetActive(true);
    }

    public void HideWinPanel()
    {
        winPanel.SetActive(false);
    }

    public void UpdateCoin()
    {
        coinText.text = LevelManager.instance.coin.ToString();
    }

    public void ShowWeaponShop()
    {
        weaponShop.SetActive(true);
    }

    public void HideWeaponShop()
    {
        weaponShop.SetActive(false);
    }

    public void ShowIndicators()
    {
        indicators.SetActive(true);
    }

    public void HideIndicators()
    {
        indicators.SetActive(false);
    }

    public void ShowCanvasName()
    {
        CanvasName.SetActive(true);
    }

    public void HideCanvasName()
    {
        CanvasName.SetActive(false);
    }

    public void ShowAliveText()
    {
        aliveTextObj.SetActive(true);
    }

    public void HideAliveText()
    {
        aliveTextObj.SetActive(false);
    }

    public void HideAllChooseAreas()
    {
        hatArea.SetActive(false);
        pantsArea.SetActive(false);
        shieldArea.SetActive(false);
        fullsetArea.SetActive(false);
    }
}