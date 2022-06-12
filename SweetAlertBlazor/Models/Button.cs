using Constants = SweetAlertBlazor.SwalConstants;
namespace SweetAlertBlazor
{
    public static partial class SweetAlert
    {
        public class Button
        {
            /// <summary>
            /// Button text
            /// </summary>
            public string Text { get; set; } = default!;

            /// <summary>
            /// Button's visibility (whether it should be visible or not)
            /// </summary>
            public bool Visible { get; set; } = true;

            /// <summary>
            /// Adds a custom css class to the button. This is handy for changing the appearance
            /// </summary>
            public string? ClassName { get; set; }

            /// <summary>
            /// Whether the modal should be dissmissed on click of the button, or not
            /// </summary>
            public bool CloseModalOnClick { get; set; } = true;

            /// <summary>
            /// Action to be performed on the click of the button
            /// </summary>
            public Action? OnClick { get; set; }

            /// <summary>
            /// Action to be performed asynchronously on the click of the button
            /// </summary>
            public Func<Task>? OnClickAsync { get; set; }

            private readonly string _internalValue;
            public Button()
            {
                _internalValue = $"{Guid.NewGuid()}_{DateTime.Now:ddMMyyyyhhmmssfffftt}_{Random.Shared.Next()}";
            }
            internal string InternalValue => _internalValue;

            public Button(string text, bool visible) : this() => (Text, Visible) = (text, visible);
            public Button(string text) : this(text, visible: true) { }

            public Button(string text, bool visible, Action onClickHandler) : this(text, visible) => OnClick = onClickHandler;
            public Button(string text, bool visible, Func<Task> onClickAsyncHandler) : this(text, visible) => OnClickAsync = onClickAsyncHandler;

            public Button(string text, Action onClickHandler) : this(text, visible: true, onClickHandler) { }
            public Button(string text, Func<Task> onClickAsyncHandler) : this(text, visible: true, onClickAsyncHandler) { }

            #region ----------- Builder ----------

            public Button WithText(string text)
            {
                Text = text;
                return this;
            }            
            public Button WithCssClass(string cssClassName)
            {
                ClassName = cssClassName;
                return this;
            }
            public Button WithClickHandler(Action onClick)
            {
                if (OnClickAsync is not null)
                    throw new InvalidOperationException($"Only one click handler can be registered with the button. Found already registered async click handler");
                OnClick = onClick;
                return this;
            }
            public Button WithAsyncClickHandler(Func<Task> onClickAsync)
            {
                if (OnClick is not null)
                    throw new InvalidOperationException($"Only one click handler can be registered with the button. Found already registered click handler");
                OnClickAsync = onClickAsync;
                return this;
            }
            public Button SetVisibilty(bool isVisible = true)
            {
                Visible = isVisible;
                return this;
            }

            #endregion

            public static Button Ok() => new(Constants.ButtonTexts.Ok);
            public static Button Ok(Action onClickHandler) => new(Constants.ButtonTexts.Ok, onClickHandler);
            public static Button Ok(Func<Task> onClickAsyncHandler) => new(Constants.ButtonTexts.Ok, onClickAsyncHandler);

            public static Button Yes() => new(Constants.ButtonTexts.Yes);
            public static Button Yes(Action onClickHandler) => new(Constants.ButtonTexts.Yes, onClickHandler);
            public static Button Yes(Func<Task> onClickAsyncHandler) => new(Constants.ButtonTexts.Yes, onClickAsyncHandler);

            public static Button Cancel() => new(Constants.ButtonTexts.Cancel);
            public static Button Cancel(Action onClickHandler) => new(Constants.ButtonTexts.Cancel, onClickHandler);
            public static Button Cancel(Func<Task> onClickAsyncHandler) => new(Constants.ButtonTexts.Cancel, onClickAsyncHandler);

            public static Button No() => new(Constants.ButtonTexts.No);
            public static Button No(Action onClickHandler) => new(Constants.ButtonTexts.No, onClickHandler);
            public static Button No(Func<Task> onClickAsyncHandler) => new(Constants.ButtonTexts.No, onClickAsyncHandler);
        }
    }
}