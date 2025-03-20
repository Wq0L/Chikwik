using UnityEngine;

public class StateController : MonoBehaviour
{
    private PlayerState _currentplayerstate = PlayerState.Idle;



    private void Start()
    {
        ChangeState(PlayerState.Idle);
    }

    public void ChangeState (PlayerState newPlayerState)
    {

        if (_currentplayerstate == newPlayerState) { return;}

        _currentplayerstate = newPlayerState;
    }



    public PlayerState GetCurrentState()
    {
        return _currentplayerstate;
    }


}
