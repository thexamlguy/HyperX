namespace HyperX.Keyboard.Avalonia;

public class KeyboardComponent :
    IComponent
{
    public IComponentBuilder Create() =>
        ComponentBuilder.Create()
            .AddServices(services =>
            {
                services.AddTemplate<KeyboardViewModel,
                    KeyboardView>();

                services.AddTemplate<CharacterLayoutViewModel,
                    CharacterLayoutView>();

                services.AddTemplate<FunctionLayoutViewModel,
                    FunctionLayoutView>();

                services.AddTemplate<LowerCharacterLayoutViewModel,
                    LowerCharacterLayoutView>("LowerCharacterLayout");

                services.AddTemplate<UpperCharacterLayoutViewModel,
                    UpperCharacterLayoutView>("UpperCharacterLayout");

                services.AddTemplate<NumericalLayoutViewModel,
                    NumericalLayoutView>();

                services.AddTemplate<CharacterButtonViewModel,
                    CharacterButtonView>();

                services.AddTemplate<ShiftButtonViewModel,
                    ShiftButtonView>();

                services.AddTemplate<DeleteButtonViewModel,
                    DeleteButtonView>();

                services.AddTemplate<SpaceButtonViewModel,
                    SpaceButtonView>();

                services.AddTemplate<PreviousButtonViewModel,
                    PreviousButtonView>();

                services.AddTemplate<NextButtonViewModel,
                    NextButtonView>();

                services.AddTemplate<EnterButtonViewModel,
                    EnterButtonView>();
            });
}