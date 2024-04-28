using System;
using TMPro;
using UnityEngine;
using Zenject;


public class GameOverView : MonoBehaviour
{
    [SerializeField] private Canvas _win;
    [SerializeField] private Canvas _lose;
    [SerializeField] private TMP_Text _walletAmount;
    private IWalletService _wallet;

    [Inject]
    public void Construct(IWalletService wallet)
    {
        _wallet = wallet;
    }
    private void OnEnable()
    {
        _walletAmount.text = _wallet.GetAmount(CurrencyType.Coins).ToString();
    }

    public void OpenWindow(WindowsType window)
    {
        switch (window)
        {
            case WindowsType.Lose:
                _lose.gameObject.SetActive(true);
                break;
            case WindowsType.Win:
                _win.gameObject.SetActive(true);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(window), window, null);
        }
    }
}