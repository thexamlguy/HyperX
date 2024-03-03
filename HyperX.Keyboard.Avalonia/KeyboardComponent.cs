namespace HyperX.Keyboard.Avalonia;

public class KeyboardComponent :
    IComponent
{
    public IComponentBuilder Create() =>
        DictionaryStringObjectJsonConverter.Create()
            .ConfigureServices(services =>
            {
                services.AddViewModelTemplate<KeyboardViewModel,
                    KeyboardView>();

                services.AddViewModelTemplate<CharacterLayoutViewModel,
                    CharacterLayoutView>();

                services.AddViewModelTemplate<FunctionLayoutViewModel,
                    FunctionLayoutView>();

                services.AddViewModelTemplate<LowerCharacterLayoutViewModel,
                    LowerCharacterLayoutView>("LowerCharacterLayout");

                services.AddViewModelTemplate<UpperCharacterLayoutViewModel,
                    UpperCharacterLayoutView>("UpperCharacterLayout");

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

                services.AddViewModelTemplate<EnterButtonViewModel,
                    EnterButtonView>();
            });
}