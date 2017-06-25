using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILibrary.UI.Window;
using GUILibrary.UI.View.Decorators;
using GUILibrary.UI.View;
using GUILibrary.Util.Structures;
using GUILibrary.UI.Label;

namespace GUILibrary.Application.Controller
{
    class ScreenFactory : AbstractScreenFactory
    {
        public const string MAIN_SCREEN = "main_screen";
        public const string INPUT_SCREEN = "input_screen";
        public const string LABEL_SCREEN = "label_screen";

        public override GUIWindow CreateMainScreen(ScreenNavigator screenNavigator)
        {
            var buttonToInputScreen = new Button(
                                            new Panel(
                                                new Label(
                                                    new PlainView(new Point2D<int>(32, (32 + 4) * 1), new Vector2<int>(128, 32)),
                                                    "Input screen",
                                                    (TextAlign)((int)TextAlign.CENTER + (int)TextAlign.MIDDLE)
                                                )
                                            ), (v => screenNavigator.GotoScreen(INPUT_SCREEN))
                                        );
            var buttonToLabelScreen = new Button(
                                            new Panel(
                                                new Label(
                                                    new PlainView(new Point2D<int>(32, (32 + 4) * 2), new Vector2<int>(128, 32)),
                                                    "Label screen",
                                                    (TextAlign)((int)TextAlign.CENTER + (int)TextAlign.MIDDLE)
                                                )
                                            ), (v => screenNavigator.GotoScreen(LABEL_SCREEN))
                                        );
            var buttonExit = new Button(
                                    new Panel(
                                        new Label(
                                            new PlainView(new Point2D<int>(32, (32 + 4) * 3), new Vector2<int>(128, 32)),
                                            "Exit",
                                            (TextAlign)((int)TextAlign.CENTER + (int)TextAlign.MIDDLE)
                                        )
                                    ), (v => screenNavigator.Exit())
                                );

            return new GUIWindow("main",
                buttonToInputScreen,
                buttonToLabelScreen,
                buttonExit
            );
        }

        public override GUIWindow CreateInputScreen(ScreenNavigator screenNavigator)
        {
            var labelTextInput = new Label(
                                    new PlainView(new Point2D<int>(32, (32 + 4) * 1), new Vector2<int>(128, 32)),
                                    "Input label:",
                                    TextAlign.LEFT
                                );
            var textInputInner = new TextInput(
                                    new PlainView(new Point2D<int>(32, (32 + 4) * 2), new Vector2<int>(128, 32)),
                                    "Placeholder",
                                    15
                                );
            var textInput = new Panel(
                                textInputInner
                            );

            var labelTextInputContent = new Label(
                                            new PlainView(new Point2D<int>(32, (32 + 4) * 3), new Vector2<int>(128, 32)),
                                            textInputInner.Content,
                                            TextAlign.LEFT
                                        );
            var buttonBack = new Button(
                                new Panel(
                                    new Label(
                                        new PlainView(new Point2D<int>(32, (32 + 4) * 4), new Vector2<int>(128, 32)),
                                        "Back",
                                        (TextAlign)((int)TextAlign.CENTER + (int)TextAlign.MIDDLE)
                                    )
                                ), (v => screenNavigator.GotoScreen(MAIN_SCREEN))
                            );
            var buttonSubmit = new Button(
                                    new Panel(
                                        new Label(
                                            new PlainView(new Point2D<int>(128 + 32 + 8, (32 + 4) * 4), new Vector2<int>(128, 32)),
                                            "Submit",
                                            (TextAlign)((int)TextAlign.CENTER + (int)TextAlign.MIDDLE)
                                        )
                                    ), (v => labelTextInputContent.Text = "You submitted: " + textInputInner.Content)
                                );

            return new GUIWindow("input",
                labelTextInput,
                textInput,
                labelTextInputContent,
                buttonBack,
                buttonSubmit
            );
        }

        public override GUIWindow CreateLabelScreen(ScreenNavigator screenNavigator)
        {
            var label1 = new Label(
                                    new PlainView(new Point2D<int>(32, (32 + 4) * 1), new Vector2<int>(128, 32)),
                                    "So",
                                    TextAlign.LEFT
                                );
            var label2 = new Label(
                                    new PlainView(new Point2D<int>(32, (32 + 4) * 2), new Vector2<int>(128, 32)),
                                    "Many",
                                    TextAlign.LEFT
                                );
            var label3 = new Label(
                                    new PlainView(new Point2D<int>(32, (32 + 4) * 3), new Vector2<int>(128, 32)),
                                    "Labels",
                                    TextAlign.LEFT
                                );

            var buttonBack = new Button(
                                new Panel(
                                    new Label(
                                        new PlainView(new Point2D<int>(32, (32 + 4) * 4), new Vector2<int>(128, 32)),
                                        "Back",
                                        (TextAlign)((int)TextAlign.CENTER + (int)TextAlign.MIDDLE)
                                    )
                                ), (v => screenNavigator.GotoScreen(MAIN_SCREEN))
                            );

            return new GUIWindow("label",
                label1,
                label2,
                label3,
                buttonBack
            );
        }

        public override GUIWindow CreateScreenFromId(string id, ScreenNavigator screenNavigator)
        {
            switch (id)
            {
                case MAIN_SCREEN:
                    return CreateMainScreen(screenNavigator);
                case INPUT_SCREEN:
                    return CreateInputScreen(screenNavigator);
                case LABEL_SCREEN:
                    return CreateLabelScreen(screenNavigator);
            }
            throw new Exception(string.Format("No screen with the id '{0}' found.", id));
        }
    }
}
