using UnityEngine;

public class GoldWheatcCollectible : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _movmentIncreaseSpeed;
    [SerializeField] private float _resetBoostDuration;    
    


public void Collect()

{

    _playerController.SetPlayerSpeed(_movmentIncreaseSpeed, _resetBoostDuration);
    Destroy(gameObject);

}




}
