using Infrastructure;
using Infrastructure.AssetManagement;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private PointerListener _start;
    [SerializeField] private PointerListener _language;
    [SerializeField] private PointerListener _soundSettings;
    [SerializeField] private PointerListener _about;
    [SerializeField] private PointerListener _exit;
    [SerializeField] private PointerListener _shop;
    [SerializeField] private Canvas _aboutPanel;
    [SerializeField] private Canvas _soundSettingsPanel;
    [SerializeField] private Canvas _languagePanel;
    [SerializeField] private ShopDialog _shopDialog;
    [SerializeField] private TMP_Text _coinAmount;


    private ISceneLoader _sceneLoader;
    private ISaveLoadService _saveLoadService;
    private IWalletService _wallet;

    [Inject]
    public void Construct(IWalletService wallet, ISceneLoader sceneLoader,
        ISaveLoadService saveLoadService)
    {
        _sceneLoader = sceneLoader;
        _saveLoadService = saveLoadService;
        _wallet = wallet;
    }

    private void OnEnable()
    {
        Debug.Log("Main menu Enable");
        _start.Click += OnStartButton;
        _language.Click += OnLanguageButton;
        _soundSettings.Click += OnSoundSettingsButton;
        _about.Click += OnAboutButton;
        _exit.Click += OnExitButton;
        _shop.Click += OnShopButton;

        UpdateCoinsAmount();
    }

    private void UpdateCoinsAmount()
    {
        _coinAmount.text = _wallet.GetAmount(CurrencyType.Coins).ToString();
    }

    private void OnDisable()
    {
        _start.Click -= OnStartButton;
        _language.Click -= OnLanguageButton;
        _soundSettings.Click -= OnSoundSettingsButton;
        _about.Click -= OnAboutButton;
        _exit.Click -= OnExitButton;
        _shop.Click -= OnShopButton;
    }

    private void OnShopButton(PointerEventData obj)
    {
        HideMenu();
        _shopDialog.gameObject.SetActive(true);
    }

    private void OnLanguageButton(PointerEventData obj)
    {
        HideMenu();
        _languagePanel.gameObject.SetActive(true);
    }

    private void OnStartButton(PointerEventData data)
    {
        _sceneLoader.LoadScene(AssetPaths.GameSceneName);
    }

    private void OnExitButton(PointerEventData data)
    {
        _saveLoadService.SaveProgress();
        HideMenu();
        Application.Quit();
    }

    private void OnAboutButton(PointerEventData data)
    {
        HideMenu();
        _aboutPanel.gameObject.SetActive(true);
    }

    private void OnSoundSettingsButton(PointerEventData data)
    {
        HideMenu();
        _soundSettingsPanel.gameObject.SetActive(true);
    }

    private void HideMenu()
    {
        gameObject.SetActive(false);
    }
}