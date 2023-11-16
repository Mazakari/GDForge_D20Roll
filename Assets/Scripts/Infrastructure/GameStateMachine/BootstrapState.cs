﻿using UnityEngine;

public class BootstrapState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly AllServices _services;

    public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
        _services = services;

        RegisterServices();
    }

    public void Enter()
    {
        SetFpsTarget();

        Debug.Log("BootstrapState");
        _sceneLoader.Load(Constants.INITIAL_SCENE_NAME, onLoaded: EnterLoadLevel);
    }

    private void EnterLoadLevel() =>
        _gameStateMachine.Enter<LoadLevelState, string>(Constants.FIRST_LEVEL_NAME);

    public void Exit() {}

    private void RegisterServices()
    {
        _services.RegisterSingle<IAssets>(new AssetProvider());
        _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>()));
        _services.RegisterSingle<IRollDiceService>(new RollDiceService(_services.Single<IGameFactory>()));
    }

    // System Settings
    private void SetFpsTarget() =>
        Application.targetFrameRate = 120;
}
