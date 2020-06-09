using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region SingleTon
    public static LevelManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    [SerializeField] GameObject portal;
    [SerializeField] float delayLoadLevel;

    private int coinsNumbers;

    public void AddCoinCount()
    {
        coinsNumbers++;
    }

    public void RemoveCoinCount()
    {
        coinsNumbers--;
        
        if (coinsNumbers <= 0)
        {
            portal.SetActive(true);
        }
    }
}
