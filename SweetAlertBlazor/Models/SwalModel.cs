using static SweetAlertBlazor.SweetAlert;

namespace SweetAlertBlazor
{
    /// <summary>
    /// Sweet Alert Options Configuration Model
    /// </summary>
    public partial class SwalModel
    {
        ///// <summary>
        ///// Type of the Modal popup. For Available Types see <see cref="SweetAlert.Type"/>
        ///// </summary>
        //public SweetAlert.Type Type { get; set; } = SweetAlert.Type.Alert;

        /// <summary>
        /// The title of the modal
        /// </summary>
        public string Title { get; set; } = "";

        /// <summary>
        /// The modal's text
        /// </summary>
        public string Text { get; set; } = "";

        /// <summary>
        /// An icon for the modal. Comes with 4 built-in icons that you can use <see cref="SweetAlert.Icon"/>
        /// </summary>
        public SweetAlert.Icon Icon { get; set; } = SweetAlert.Icon.Info;

        /// <summary>
        /// Whether to show buttons or not
        /// </summary>
        public bool ShowButtons { get; set; } = true;

        /// <summary>
        /// Decide whether the user should be able to dismiss the modal by clicking outside of it, or not
        /// </summary>
        public bool CloseOnClickOutside { get; set; } = true;

        /// <summary>
        /// Decide whether the user should be able to dismiss the modal by hitting the ESC key, or not
        /// </summary>
        public bool CloseOnEsc { get; set; } = true;

        ///// <summary>
        ///// If set to true, the confirm button turns red and the default focus is set on the cancel button instead. 
        ///// This is handy when showing warning modals where the confirm action is dangerous (e.g. deleting an item).
        ///// </summary>
        //public bool IsDangerMode { get; set; } = false;

        /// <summary>
        /// Closes the modal after a certain amount of time (specified in mili-seconds). Useful to combine with {ShowButtons = false}
        /// </summary>
        public int? HideAfterMiliseconds { get; set; }

        /// <summary>
        /// Adds a custom css class to the SweetAlert modal. This is handy for changing the appearance
        /// </summary>
        public string? ClassName { get; set; }

        /// <summary>
        /// Buttons to be displayed on the Modal
        /// </summary>
        private ICollection<Button> Buttons { get; set; } = Enumerable.Empty<Button>().ToList();

        private readonly IDictionary<string, Action?> _clickActions = new Dictionary<string, Action?>();
        private readonly IDictionary<string, Func<Task>?> _clickAsyncActions = new Dictionary<string, Func<Task>?>();

        public SwalModel() { }

        public SwalModel(ICollection<Button> buttons) : this()
        {
            Buttons = buttons;
            SetClickActions(Buttons);
        }
        public SwalModel(string text) : this(text, null!) { }
        public SwalModel(string text, string title) : this() => (Text, Title) = (text, title);

        /// <summary>
        /// Adds a button to the modal
        /// </summary>
        /// <param name="button">Button to be added</param>
        public void AddButton(Button button)
        {
            Buttons.Add(button);
            if (button.OnClick is not null)
                _clickActions.Add(button.InternalValue, button.OnClick);
            else if (button.OnClickAsync is not null)
                _clickAsyncActions.Add(button.InternalValue, button.OnClickAsync);
        }

        /// <summary>
        /// Adds multiple buttons to the modal
        /// </summary>
        /// <param name="buttons">Buttons to be added</param>
        public void AddButtons(IEnumerable<Button> buttons)
        {
            foreach (var button in buttons)
            {
                AddButton(button);
            }
        }

        #region ------------ Builder --------

        public SwalModel WithText(string text)
        {
            Text = text;
            return this;
        }
        public SwalModel WithTitle(string title)
        {
            Title = title;
            return this;
        }
        public SwalModel WithTextAndTitle(string text, string title)
        {
            Text = text;
            Title = title;
            return this;
        }
        public SwalModel WithIcon(Icon icon)
        {
            Icon = icon;
            return this;
        }
        public SwalModel WithCssClass(string cssClassName)
        {
            ClassName = cssClassName;
            return this;
        }
        public SwalModel AutoHide(int afterSeconds = 5)
        {
            HideAfterMiliseconds = afterSeconds * 1000;
            return this;
        }
        public SwalModel SetClosingOptions(bool closeOnEscButton = true, bool closeOnOutsideClick = true)
        {
            CloseOnClickOutside = closeOnOutsideClick;
            CloseOnEsc = closeOnEscButton;
            return this;
        }
        public SwalModel WithButton(Button button)
        {
            AddButton(button);
            return this;
        }
        public SwalModel WithButtons(IEnumerable<Button> buttons)
        {
            AddButtons(buttons);
            return this;
        }
        public SwalModel WithButtons(params Button[] buttons)
        {
            AddButtons(buttons);
            return this;
        }

        #endregion

        private void SetClickActions(IEnumerable<Button> buttons)
        {
            if (buttons?.Any() == true)
            {
                foreach (var btn in buttons.Where(b => b.OnClick is not null))
                {
                    _clickActions.Add(btn.InternalValue, btn.OnClick);
                }
                foreach (var btn in buttons.Where(b => b.OnClickAsync is not null))
                {
                    _clickAsyncActions.Add(btn.InternalValue, btn.OnClickAsync);
                }
            }
        }

    }

}