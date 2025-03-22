using UnityEngine;

public class RottenWheatcCollectible : MonoBehaviour, ICollectible
{
    [SerializeField] private WheatDesingSO _wheatDesingSO;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _movmentDecreaseSpeed;
    [SerializeField] private float _resetBoostDuration;    
    


public void Collect()

{

    _playerController.SetPlayerSpeed(_wheatDesingSO.IncreaseDecreasseMultiplier, _wheatDesingSO.ResetBoostDuration);
    Destroy(gameObject);

}
}
