using JetBrains.Annotations;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{

    [SerializeField] private PlayerController _playerController;


    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }


    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.TryGetComponent<ICollectible>(out var collectible))
        {
            collectible.Collect();
        }

        // if(other.CompareTag(Consts.WheatTypes.GOLD_WHEAT))
        // {
        //     other.gameObject?.GetComponent<GoldWheatcCollectible>().Collect();
        // }
        // if(other.CompareTag(Consts.WheatTypes.HOLY_WHEAT))
        // {
        //     other.gameObject?.GetComponent<HolyWheatcCollectible>().Collect();
        // }
        // if(other.CompareTag(Consts.WheatTypes.ROTTEN_WHEAT))
        // {
        //     other.gameObject?.GetComponent<RottenWheatcCollectible>().Collect();
        // }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.TryGetComponent<IBoostbles>(out var boostbles))
        {
            boostbles.Boost(_playerController);
        }
    }



}
