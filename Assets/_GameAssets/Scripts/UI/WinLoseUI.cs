using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WinLoseUI : MonoBehaviour
{
  [Header("References")]
    [SerializeField] private GameObject _blackBackGroundObject;
    [SerializeField] private GameObject _winPopup;
    [SerializeField] private GameObject _losePopup;

    [Header("Settings")]
    [SerializeField] private float _animationDuration = 0.3f;


    private Image _blackBackGroundImage;
    private RectTransform _winPopupRectTransform;
    private RectTransform _losePopupRectTransform;



    void Awake()
    {
        _blackBackGroundImage = _blackBackGroundObject.GetComponent<Image>();
        _winPopupRectTransform = _winPopup.GetComponent<RectTransform>();
        _losePopupRectTransform = _losePopup.GetComponent<RectTransform>();
    }


    public void OnGameWin()
    { 
        _blackBackGroundObject.SetActive(true);
        _winPopup.SetActive(true);

        _blackBackGroundImage.DOFade(0.8f, _animationDuration).SetEase(Ease.Linear);
        _winPopupRectTransform.DOScale(1.5f, _animationDuration).SetEase(Ease.OutBack);

    }

    public void OnGameLose()
    {
        _blackBackGroundObject.SetActive(true);
        _losePopup.SetActive(true);

        _blackBackGroundImage.DOFade(0.8f, _animationDuration).SetEase(Ease.Linear);
        _losePopupRectTransform.DOScale(1.5f, _animationDuration).SetEase(Ease.OutBack);
    }


}
