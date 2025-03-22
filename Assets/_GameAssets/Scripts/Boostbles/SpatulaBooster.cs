using UnityEngine;

public class SpatulaBooster : MonoBehaviour, IBoostbles
{
    
    [Header("Referance")]
    [SerializeField] private Animator _spatulaAnimator;

    [Header("Settings")]
    [SerializeField] private float _JumpForce;

    private bool _isActivated;

    public void Boost(PlayerController playerController)
    {
        if (_isActivated)
        {
            return;
        }
        PlayBoostAnimation();
        Rigidbody playerRigidBody = playerController.GetPlayerRigidbody();

        playerRigidBody.linearVelocity =new Vector3(playerRigidBody.linearVelocity.x, 0f, playerRigidBody.linearVelocity.z);
        playerRigidBody.AddForce(transform.forward * _JumpForce, ForceMode.Impulse);
        _isActivated = true;
        Invoke(nameof(resetActions), 0.2f);

    }

    private void PlayBoostAnimation()
    {
        _spatulaAnimator.SetTrigger(Consts.OtherAnimations.IS_SPATULA_JUMPING);
        
    }

    void resetActions()
    {
        _isActivated = false;
    }

}
