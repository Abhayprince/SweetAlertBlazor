using static SweetAlertBlazor.SweetAlert;

namespace SweetAlertBlazor
{
    /// <summary>
    /// Internal Methods
    /// </summary>
    public partial class SwalModel
    {
        public const string DefaultModalClass = "swal-blazor-modal";
        public const string DefaultButtonClass = "swal-blazor-btn";

        /// <summary>
        /// SweetAlert javascript icon names mapping
        /// </summary>
        private static readonly IReadOnlyDictionary<Icon, string> _sweetAlertIcons = new Dictionary<Icon, string>
        {
            [Icon.Warning] = "warning",
            [Icon.Error] = "error",
            [Icon.Success] = "success",
            [Icon.Info] = "info",
        };

        internal Task OnAfterButtonClickAsync(string btnKey)
        {
            if (_clickActions.TryGetValue(btnKey, out var action) && action is not null)
                action.Invoke();
            else if (_clickAsyncActions.TryGetValue(btnKey, out var actionAsync) && actionAsync is not null)
                return actionAsync.Invoke();

            return Task.CompletedTask;
        }

        internal Options ToJsModel()
        {
            Options options = new()
            {
                title = Title,
                text = Text,
                icon = _sweetAlertIcons.TryGetValue(Icon, out var icon) ? icon : _sweetAlertIcons[Icon.Info],
                closeOnClickOutside = CloseOnClickOutside,
                timer = HideAfterMiliseconds,
                closeOnEsc = CloseOnEsc,
                className = $"{DefaultModalClass} {ClassName}".TrimEnd(),
                dangerMode = IsDangerMode
            };

            if (!ShowButtons)
                options.buttons = false;
            else
            {
                if (Buttons.Any())
                {
                    options.buttons = Buttons.ToDictionary(btn => btn.InternalValue, btn => new
                    {
                        text = btn.Text,
                        value = btn.InternalValue,
                        visible = btn.Visible,
                        className = $"{DefaultButtonClass} {btn.ClassName}".TrimEnd(),
                        closeModal = btn.CloseModalOnClick,
                    });
                }
            }

            return options;
        }
    }
}

