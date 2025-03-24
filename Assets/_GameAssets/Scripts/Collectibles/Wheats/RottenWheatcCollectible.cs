using UnityEngine;
using UnityEngine.UI;

public class RottenWheatcCollectible : MonoBehaviour, ICollectible
{
    [SerializeField] private WheatDesingSO _wheatDesingSO;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _movmentDecreaseSpeed;
    [SerializeField] private float _resetBoostDuration;    

    [SerializeField] private PlayerStateUI _playerStateUI;
    
    private RectTransform _playerBoosterTransform;
    private Image _playerBooserImage; 
    



    void Awake()
    {
        _playerBoosterTransform = _playerStateUI.GetBoosterSlowTransform;
        _playerBooserImage = _playerBoosterTransform.GetComponent<Image>();
    }

public void Collect()

{

    _playerController.SetPlayerSpeed(_wheatDesingSO.IncreaseDecreasseMultiplier, _wheatDesingSO.ResetBoostDuration);

    _playerStateUI.PlayBoostersUIAnimation(_playerBoosterTransform, _playerBooserImage, _playerStateUI.GetRottenBoosterWheatImage, _wheatDesingSO.ActiveSprite, 
    _wheatDesingSO.PassiveSprite, _wheatDesingSO.ActiveWheatSprite, _wheatDesingSO.PassiveWheatSprite, _wheatDesingSO.ResetBoostDuration);

    Destroy(gameObject);

}
}
