using UnityEngine;

[CreateAssetMenu(fileName = "WheatDesingSO", menuName = "ScriptableObjects/WheatDesingSO")]



public class WheatDesingSO : ScriptableObject
{
   [SerializeField] private float _increaseDecreaseMultiplier;
   [SerializeField] private float _resetBoostDuration;

   [SerializeField] private Sprite _activeSprite;
   [SerializeField] private Sprite _passiveSprite;
   [SerializeField] private Sprite _activeWheatSprite;
   [SerializeField] private Sprite _passiveWheatSprite;

   public float IncreaseDecreasseMultiplier => _increaseDecreaseMultiplier;
   public float ResetBoostDuration => _resetBoostDuration;

   public Sprite ActiveSprite => _activeSprite;
   public Sprite PassiveSprite => _passiveSprite;
   public Sprite ActiveWheatSprite => _activeWheatSprite;
   public Sprite PassiveWheatSprite => _passiveWheatSprite;
}
