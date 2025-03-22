using UnityEngine;

[CreateAssetMenu(fileName = "WheatDesingSO", menuName = "ScriptableObjects/WheatDesingSO")]



public class WheatDesingSO : ScriptableObject
{
   [SerializeField] private float _increaseDecreaseMultiplier;
   [SerializeField] private float _resetBoostDuration;
   public float IncreaseDecreasseMultiplier => _increaseDecreaseMultiplier;
   public float ResetBoostDuration => _resetBoostDuration;
}
