using UnityEngine;

public class GameLoopState : IState
{
    private readonly GameStateMachine _gameStateMachine;

    public GameLoopState(GameStateMachine gameStateMachine) => 
        _gameStateMachine = gameStateMachine;

    public void Enter()
    {
        SubscribeUICallbacks();

        Debug.Log("GameLoopState");
    }

    public void Exit() => 
        UnsubscribeUICallbacks();

    private void RestartLevel() =>
        _gameStateMachine.Enter<LoadLevelState, string>(Constants.FIRST_LEVEL_NAME);

    private void SubscribeUICallbacks() =>
       ContinueButton.OnContinueButtonPress += RestartLevel;

    private void UnsubscribeUICallbacks() => 
        ContinueButton.OnContinueButtonPress -= RestartLevel;
}
