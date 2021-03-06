using Constants = SweetAlertBlazor.SwalConstants;
using static SweetAlertBlazor.SweetAlert;

namespace SweetAlertBlazor
{
    /// Internal Methods
    public partial class SwalModel
    {
        /// <summary>
        /// SweetAlert javascript icon names mapping
        /// </summary>
        private static readonly IReadOnlyDictionary<Icon, string> _sweetAlertIcons = new Dictionary<Icon, string>
        {
            [Icon.Warning] = Constants.IconNames.Warning,
            [Icon.Error] = Constants.IconNames.Error,
            [Icon.Success] = Constants.IconNames.Success,
            [Icon.Info] = Constants.IconNames.Info,
        };

        /// <summary>
        /// Executes after the button is clicked
        /// </summary>
        /// <param name="btnKey"></param>
        /// <returns></returns>
        internal Task OnAfterButtonClickAsync(string btnKey)
        {
            if (_clickActions.TryGetValue(btnKey, out var action) && action is not null)
                action.Invoke();
            else if (_clickAsyncActions.TryGetValue(btnKey, out var actionAsync) && actionAsync is not null)
                return actionAsync.Invoke();

            return Task.CompletedTask;
        }

        /// <summary>
        /// Converts the SwalModel to equivalent javascript options model to be used by swal js method
        /// </summary>
        /// <returns></returns>
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
                className = $"{Constants.Css.DefaultModalClass} {ClassName}".TrimEnd(),
                //dangerMode = IsDangerMode
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
                        className = $"{Constants.Css.DefaultButtonClass} {btn.ClassName}".TrimEnd(),
                        closeModal = btn.CloseModalOnClick,
                    });
                }
            }

            return options;
        }
    }
}

