using UnityEngine;

public class LoadLevelState : IPayloadedState<string>
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _curtain;
    private readonly IGameFactory _gameFactory;
    private readonly IRollDiceService _rollDiceService;

    public LoadLevelState(
        GameStateMachine gameStateMachine, 
        SceneLoader sceneLoader, 
        LoadingCurtain curtain, 
        IGameFactory gameFactory,
        IRollDiceService rollDiceService) 
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
        _curtain = curtain;
        _gameFactory = gameFactory;
        _rollDiceService = rollDiceService;
    }

    public void Enter(string sceneName)
    {
        Debug.Log("LoadLevelState");
        _curtain.Show();
        _sceneLoader.Load(sceneName, OnLoaded);
    }

    public void Exit() => 
        _curtain.Hide();

    private void OnLoaded()
    {
        InitHUD();
        InitGameWorld();
        
        InitVolumeControl();

        _gameStateMachine.Enter<GameLoopState>();
    }

    private void InitHUD()
    {
        _gameFactory.CreateLevelHud();
    }

    private void InitGameWorld() => 
        SetRollDifficulty();
    private void SetRollDifficulty() => 
        _rollDiceService.SetRandomRollDifficulty();

    private void InitVolumeControl()
    {
        VolumeControl vc = Object.FindObjectOfType<VolumeControl>();
        if (vc != null) return;

        _gameFactory.CreateVolumeControl();
    }
}