using JetBrains.Annotations;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{

    [SerializeField] private PlayerController _playerController;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Consts.WheatTypes.GOLD_WHEAT))
        {
            other.gameObject?.GetComponent<GoldWheatcCollectible>().Collect();
        }
        if(other.CompareTag(Consts.WheatTypes.HOLY_WHEAT))
        {
            other.gameObject?.GetComponent<HolyWheatcCollectible>().Collect();
        }
        if(other.CompareTag(Consts.WheatTypes.ROTTEN_WHEAT))
        {
            other.gameObject?.GetComponent<RottenWheatcCollectible>().Collect();
        }
    }




}
