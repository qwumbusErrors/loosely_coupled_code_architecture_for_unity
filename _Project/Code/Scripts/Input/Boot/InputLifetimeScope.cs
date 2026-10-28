using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

public class InputLifetimeScope : LifetimeScope
{
	protected override void Configure(IContainerBuilder builder)
    {
    	builder.RegisterInstance();
    	builder.Register<IPlayerInputService, PlayerInputService>(Lifetime.Singleton);

    	/*builder.Register<IMoveProvider>(c =>
            new PlayerMoveProvider(c.Resolve<IPlayerInputService>().Actions.Move),
            Lifetime.Singleton);

        builder.Register<IJumpProvider>(c =>
            new PlayerJumpProvider(c.Resolve<IPlayerInputService>().Actions.Jump),
            Lifetime.Singleton);

        builder.Register<ISprintProvider>(c =>
            new PlayerSprintProvider(c.Resolve<IPlayerInputService>().Actions.Sprint),
            Lifetime.Singleton);*/

        //builder.RegisterComponentInHierarchy<PlayerMotor>(); потребитель
    }

    private void Awake() => DontDestroyOnLoad(gameObject);
}
