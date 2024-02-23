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

                services.AddViewModelTemplate<LowerAlphabeticalLayoutViewModel,
                    LowerAlphabeticalLayoutView>("LowerAlphabeticalLayout");

                services.AddViewModelTemplate<UpperAlphabeticalLayoutViewModel, 
                    UpperAlphabeticalLayoutView>("UpperAlphabeticalLayout");

                services.AddViewModelTemplate<NumericalLayoutViewModel,
                    NumericalLayoutView>();

                services.AddViewModelTemplate<CharacterButtonViewModel,
                    CharacterButtonView>();

                services.AddViewModelTemplate<ShiftButtonViewModel,
                    ShiftButtonView>();

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