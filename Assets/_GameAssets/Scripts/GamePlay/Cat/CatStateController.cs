using UnityEngine;

public class CatStateController : MonoBehaviour
{
    [SerializeField] private CatState _currentCatState = CatState.Walking;


    void Start()
    {
        ChangeState(CatState.Walking); // Set initial state
    }

    public void ChangeState(CatState newState)
    {
       if(_currentCatState == newState) {return;} // Prevent unnecessary state changes

        _currentCatState = newState;

    }

    public CatState GetCurrentState()
    {
        return _currentCatState;
    }
}
