using UnityEngine;

public class HolyWheatcCollectible : MonoBehaviour,ICollectible
{
     [SerializeField] private WheatDesingSO _wheatDesingSO;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _forceIncrease;
    [SerializeField] private float _resetBoostDuration;    
    


public void Collect()

{

    _playerController.SetJumpForce(_wheatDesingSO.IncreaseDecreasseMultiplier, _wheatDesingSO.ResetBoostDuration);
    Destroy(gameObject);

}

}
