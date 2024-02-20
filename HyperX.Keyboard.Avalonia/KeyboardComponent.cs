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

                services.AddViewModelTemplate<KeyboardCharacterLayoutViewModel,
                    KeyboardCharacterLayoutView>();

                services.AddViewModelTemplate<KeyboardFunctionLayoutViewModel,
                    KeyboardFunctionLayoutView>();

                services.AddViewModelTemplate<LowerAlphabeticalKeyboardLayoutNavigationViewModel,
                    LowerAlphabeticalKeyboardLayoutNavigationView>();

                services.AddViewModelTemplate<LowerAlphabeticalKeyboardLayoutViewModel,
                    LowerAlphabeticalKeyboardLayoutView>("LowerAlphabeticalKeyboardLayout");

                services.AddViewModelTemplate<UpperAlphabeticalKeyboardLayoutNavigationViewModel, 
                    UpperAlphabeticalKeyboardLayoutNavigationView>();

                services.AddViewModelTemplate<UpperAlphabeticalKeyboardLayoutViewModel, 
                    UpperAlphabeticalKeyboardLayoutView>("UpperAlphabeticalKeyboardLayout");

                services.AddViewModelTemplate<NumericalKeyboardLayoutNavigationViewModel,
                    NumericalKeyboardLayoutNavigationView>();

                services.AddViewModelTemplate<NumericalKeyboardLayoutViewModel,
                    NumericalKeyboardLayoutView>("NumericalKeyboardLayout");

                services.AddViewModelTemplate<KeyboardCharacterButtonViewModel,
                    KeyboardCharacterButtonView>();

                services.AddViewModelTemplate<KeyboardDeleteButtonViewModel,
                    KeyboardDeleteButtonView>();

                services.AddViewModelTemplate<KeyboardSpaceButtonViewModel,
                    KeyboardSpaceButtonView>();

                services.AddViewModelTemplate<KeyboardPreviousButtonViewModel,
                    KeyboardPreviousButtonView>();

                services.AddViewModelTemplate<KeyboardNextButtonViewModel,
                    KeyboardNextButtonView>();
            });
}