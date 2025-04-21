using UnityEngine;

public class CatAnimationController : MonoBehaviour
{
    [Header("Referance")]
    [SerializeField] private Animator _catAnimator;
  
     private CatStateController _catStateController;


    void Awake()
    {
        _catStateController = GetComponent<CatStateController>();
    }


    void Update()
    {
        SetCatAnimation();
    }

    private void SetCatAnimation()
    {
        var currentCatState = _catStateController.GetCurrentState();

        switch (currentCatState)
        {
            case CatState.Idle:
                _catAnimator.SetBool(Consts.CatAnimations.IS_IDLING, true);
                _catAnimator.SetBool(Consts.CatAnimations.IS_WALKING, false);
                _catAnimator.SetBool(Consts.CatAnimations.IS_RUNNING, false);
                break;
            case CatState.Walking:
               _catAnimator.SetBool(Consts.CatAnimations.IS_IDLING, false);
                _catAnimator.SetBool(Consts.CatAnimations.IS_WALKING, true);
                _catAnimator.SetBool(Consts.CatAnimations.IS_RUNNING, false);
                break;
            case CatState.Run:
                _catAnimator.SetBool(Consts.CatAnimations.IS_RUNNING, true);
                break;
            case CatState.Attacking:
                _catAnimator.SetBool(Consts.CatAnimations.IS_ATTACKING, true);
                break;

         }
    }
}