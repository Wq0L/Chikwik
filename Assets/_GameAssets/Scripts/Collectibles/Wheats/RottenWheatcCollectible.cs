using UnityEngine;

public class RottenWheatcCollectible : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _movmentDecreaseSpeed;
    [SerializeField] private float _resetBoostDuration;    
    


public void Collect()

{

    _playerController.SetPlayerSpeed(_movmentDecreaseSpeed, _resetBoostDuration);
    Destroy(gameObject);

}
}
