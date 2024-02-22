namespace HyperX.Keyboard.Avalonia;

[ViewModelTemplateRoot("Keyboard")]
public class KeyboardComponent : 
    IComponent
{
    public IComponentBuilder Create() =>
        ComponentBuilder.Create()
            .ConfigureServices(services =>
            {
                services.AddViewModelTemplate<KeyboardViewModel,
                    KeyboardView>("Keyboard");

                services.AddViewModelTemplate<CharacterLayoutViewModel,
                    CharacterLayoutView>();

                services.AddViewModelTemplate<FunctionLayoutViewModel,
                    FunctionLayoutView>();

                services.AddViewModelTemplate<LowerAlphabeticalLayoutNavigationViewModel,
                    LowerAlphabeticalLayoutNavigationView>();

                services.AddViewModelTemplate<LowerAlphabeticalLayoutViewModel,
                    LowerAlphabeticalLayoutView>("LowerAlphabeticalLayout");

                services.AddViewModelTemplate<UpperAlphabeticalLayoutNavigationViewModel, 
                    UpperAlphabeticalLayoutNavigationView>();

                services.AddViewModelTemplate<UpperAlphabeticalLayoutViewModel, 
                    UpperAlphabeticalLayoutView>("UpperAlphabeticalLayout");

                services.AddViewModelTemplate<NumericalLayoutNavigationViewModel,
                    NumericalLayoutNavigationView>();

                services.AddViewModelTemplate<NumericalLayoutViewModel,
                    NumericalLayoutView>("NumericalLayout");

                services.AddViewModelTemplate<CharacterButtonViewModel,
                    CharacterButtonView>();

                services.AddViewModelTemplate<DeleteButtonViewModel,
                    DeleteButtonView>();

                services.AddViewModelTemplate<SpaceButtonViewModel,
                    SpaceButtonView>();

                services.AddViewModelTemplate<PreviousButtonViewModel,
                    PreviousButtonView>();

                services.AddViewModelTemplate<NextButtonViewModel,
                    NextButtonView>();
            });
}