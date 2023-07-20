using Zenject;

public class MainSceneInstaller : MonoInstaller
{
    private PlayerInput _playerInput;

    public override void InstallBindings()
    {
        BindPlayerInput();
    }

    private void BindPlayerInput()
    {
        _playerInput = new PlayerInput();
        Container.BindInstance(_playerInput);
    }
}