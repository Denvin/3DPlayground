using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] float fadeDuration = 1f;
    [SerializeField] CanvasGroup menu;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider effectSlider;

    public void ShowMenu()
    {
        menu.gameObject.SetActive(true);
        menu.alpha = 0;
        menu.DOFade(1, fadeDuration).SetUpdate(true);

        Time.timeScale = 0;

        musicSlider.value = AudioManager.Instance.GetMusicVolume() * musicSlider.maxValue;
        effectSlider.value = AudioManager.Instance.GetEffectVolume() * effectSlider.maxValue;
    }
    public void HideMenu()
    {
        menu.DOFade(0, fadeDuration).OnComplete(() =>
            {
                menu.gameObject.SetActive(false);
                Time.timeScale = 1;
            }).SetUpdate(true);
        
    }
    public void MusicVolumeChanged()
    {
        AudioManager.Instance.SetMusicVolume(musicSlider.value / musicSlider.maxValue);
    }
    public void EffectVolumeChanged()
    {
        AudioManager.Instance.SetEffectVolume(effectSlider.value / effectSlider.maxValue);
    }
}
