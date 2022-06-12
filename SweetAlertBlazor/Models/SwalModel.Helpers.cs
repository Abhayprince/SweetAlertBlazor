using Constants = SweetAlertBlazor.SwalConstants;
using static SweetAlertBlazor.SweetAlert;

namespace SweetAlertBlazor
{
    /// Static Helper Methods
    public partial class SwalModel
    {
        #region ----------- Simple Alerts (Alert, Warning, Error alert) without click handlers -----------
        /// <summary>
        /// Alert model with single "Ok" button with icon <see cref="Icon.Info"/>
        /// </summary>
        /// <param name="text">Modal text</param>
        /// <param name="title">Modal title</param>
        /// <returns></returns>
        public static SwalModel Alert(string text, string title = null!) => Alert(text, title, Constants.ButtonTexts.Ok, Icon.Info);

        /// <summary>
        /// Error Alert model with single "Ok" button with icon <see cref="Icon.Error"/>
        /// </summary>
        /// <param name="text">Modal text</param>
        /// <param name="title">Modal title</param>
        /// <returns></returns>
        public static SwalModel Error(string text, string title = null!) => Alert(text, title, Constants.ButtonTexts.Ok, Icon.Error);

        /// <summary>
        /// Warning Alert model with single "Ok" button with icon <see cref="Icon.Warning"/>
        /// </summary>
        /// <param name="text">Modal text</param>
        /// <param name="title">Modal title</param>
        /// <returns></returns>
        public static SwalModel Warning(string text, string title = null!) => Alert(text, title, Constants.ButtonTexts.Ok, Icon.Warning);

        /// <summary>
        /// Alert model with single <paramref name="buttonText"/> button
        /// </summary>
        /// <param name="text">Modal text</param>
        /// <param name="title">Modal title</param>
        /// <param name="buttonText">text of shown button  (default value: Ok)</param>
        /// <param name="icon">Icon of the modal (Default is <see cref="Icon.Info"/>)</param>
        /// <returns></returns>
        public static SwalModel Alert(string text, string title, string buttonText, Icon icon = Icon.Info) => new()
        {
            Text = text,
            Title = title,
            Icon = icon,
            Buttons = new List<Button> { new Button(buttonText) }
        };

        #endregion

        #region ------------ Alert with Action click handler ----------------------

        /// <summary>
        /// Alert model with single "Ok" button
        /// </summary>
        /// <param name="text">Modal text</param>
        /// <param name="onClickHandler">Action delegate to be executed on the click of the "Ok" button</param>
        /// <param name="title">Modal title</param>
        /// <returns></returns>
        public static SwalModel Alert(string text, Action onClickHandler, string title = null!) => 
            Alert(text, onClickHandler, title, Constants.ButtonTexts.Ok, Icon.Info);

        /// <summary>
        /// Error Alert model with single "Ok" button
        /// </summary>
        /// <param name="text">Modal text</param>
        /// <param name="onClickHandler">Action delegate to be executed on the click of the "Ok" button</param>
        /// <param name="title">Modal title</param>
        /// <returns></returns>
        public static SwalModel Error(string text, Action onClickHandler, string title = null!) =>
            Alert(text, onClickHandler, title, Constants.ButtonTexts.Ok, Icon.Error);

        /// <summary>
        /// Warning Alert model with single "Ok" button
        /// </summary>
        /// <param name="text">Modal text</param>
        /// <param name="onClickHandler">Action delegate to be executed on the click of the "Ok" button</param>
        /// <param name="title">Modal title</param>
        /// <returns></returns>
        public static SwalModel Warning(string text, Action onClickHandler, string title = null!) =>
            Alert(text, onClickHandler, title, Constants.ButtonTexts.Ok, Icon.Warning);

        /// <summary>
        /// Alert model with single <paramref name="buttonText"/> button
        /// </summary>
        /// <param name="text">Modal text</param>
        /// <param name="onClickHandler">Action delegate to be executed on the click of the <paramref name="buttonText"/> button</param>
        /// <param name="title">Modal title</param>
        /// <param name="buttonText">text of shown button (default value: Ok)</param>
        /// <param name="icon">Icon of the modal (Default is <see cref="Icon.Info"/>)</param>
        /// <returns></returns>
        public static SwalModel Alert(string text, Action onClickHandler, string title, string buttonText, Icon icon = Icon.Info) => new()
        {
            Text = text,
            Title = title,
            Icon = icon,
            Buttons = new List<Button> { new Button(buttonText, onClickHandler) }
        };

        #endregion

        #region ------------- Alerts with async Func<Task> click handlers -------------------

        /// <summary>
        /// Alert model with single "Ok" button
        /// </summary>
        /// <param name="text">Modal text</param>
        /// <param name="onClickHandlerAsync">Action delegate to be executed on the click of the "Ok" button</param>
        /// <param name="title">Modal title</param>
        /// <returns></returns>
        public static SwalModel Alert(string text, Func<Task> onClickHandlerAsync, string title = null!) =>
            Alert(text, onClickHandlerAsync, title, Constants.ButtonTexts.Ok, Icon.Info);

        /// <summary>
        /// Error Alert model with single "Ok" button
        /// </summary>
        /// <param name="text">Modal text</param>
        /// <param name="onClickHandlerAsync">Delegate to be executed asynchronously on the click of the "Ok" button</param>
        /// <param name="title">Modal title</param>
        /// <returns></returns>
        public static SwalModel Error(string text, Func<Task> onClickHandlerAsync, string title = null!) =>
            Alert(text, onClickHandlerAsync, title, Constants.ButtonTexts.Ok, Icon.Error);

        /// <summary>
        /// Warning Alert model with single "Ok" button
        /// </summary>
        /// <param name="text">Modal text</param>
        /// <param name="onClickHandlerAsync">Delegate to be executed asynchronously on the click of the "Ok" button</param>
        /// <param name="title">Modal title</param>
        /// <returns></returns>
        public static SwalModel Warning(string text, Func<Task> onClickHandlerAsync, string title = null!) =>
            Alert(text, onClickHandlerAsync, title, Constants.ButtonTexts.Ok, Icon.Warning);

        /// <summary>
        /// Alert model with single <paramref name="buttonText"/> button
        /// </summary>
        /// <param name="text">Modal text</param>
        /// <param name="onClickHandlerAsync">Delegate to be executed asynchronously on the click of the <paramref name="buttonText"/> button</param>
        /// <param name="title">Modal title</param>
        /// <param name="buttonText">text of shown button (default value: Ok)</param>
        /// <param name="icon">Icon of the modal (Default is <see cref="Icon.Info"/>)</param>
        /// <returns></returns>
        public static SwalModel Alert(string text, Func<Task> onClickHandlerAsync, string title, string buttonText, Icon icon = Icon.Info) => new()
        {
            Text = text,
            Title = title,
            Icon = icon,
            Buttons = new List<Button> { new Button(buttonText, onClickHandlerAsync) }
        };

        #endregion

        #region ---------- Confirm modals with Action click handlers ---------------
        /// <summary>
        /// Confirm model with two (negative and positive) buttons [Default buttons are Ok and Cancel] with icon <see cref="Icon.Info"/>
        /// </summary>
        /// <param name="text">Modal text</param>
        /// <param name="okClickHandler">Action delegate to be executed on the click of Positive button (Ok/Yes)</param>
        /// <param name="confirmButtonsType">Buttons type (Availabel types are: Ok/Cancel and Yes/No)</param>
        /// <returns></returns>
        public static SwalModel Confirm(string text, Action okClickHandler, ConfirmButtonsType confirmButtonsType = ConfirmButtonsType.OkCancel) =>
           Confirm(text, confirmButtonsType, title: null!, okClickHandler, cancelClickHandler: null!);

        /// <summary>
        /// Confirm Error model with two (negative and positive) buttons [Default buttons are Ok and Cancel] with icon <see cref="Icon.Error"/>
        /// </summary>
        /// <param name="text">Modal text</param>
        /// <param name="okClickHandler">Action delegate to be executed on the click of Positive button (Ok/Yes)</param>
        /// <param name="confirmButtonsType">Buttons type (Availabel types are: Ok/Cancel and Yes/No)</param>
        /// <returns></returns>
        public static SwalModel ConfirmError(string text, Action okClickHandler, ConfirmButtonsType confirmButtonsType = ConfirmButtonsType.OkCancel) =>
           Confirm(text, confirmButtonsType, title: null!, okClickHandler, cancelClickHandler: null!, Icon.Error);

        /// <summary>
        /// Confirm Warning model with two (negative and positive) buttons [Default buttons are Ok and Cancel] with icon <see cref="Icon.Warning"/>
        /// </summary>
        /// <param name="text">Modal text</param>
        /// <param name="okClickHandler">Action delegate to be executed on the click of Positive button (Ok/Yes)</param>
        /// <param name="confirmButtonsType">Buttons type (Availabel types are: Ok/Cancel and Yes/No)</param>
        /// <returns></returns>
        public static SwalModel ConfirmWarning(string text, Action okClickHandler, ConfirmButtonsType confirmButtonsType = ConfirmButtonsType.OkCancel) =>
           Confirm(text, confirmButtonsType, title: null!, okClickHandler, cancelClickHandler: null!, Icon.Warning);

        public static SwalModel Confirm(string text, string title, Action okClickHandler, Action cancelClickHandler, Icon icon = Icon.Info) =>
            Confirm(text, ConfirmButtonsType.OkCancel, title, okClickHandler, cancelClickHandler, icon);

        /// <summary>
        /// Confirm model with two (negative and positive) buttons [Default buttons are Ok and Cancel]
        /// </summary>
        /// <param name="text">Modal text</param>
        /// <param name="confirmButtonsType">Buttons type (Availabel types are: Ok/Cancel and Yes/No)</param>
        /// <param name="title">Modal title</param>
        /// <param name="okClickHandler">Action delegate to be executed on the click of Positive button (Ok/Yes)</param>
        /// <param name="cancelClickHandler">Action delegate to be executed on the click of Negative button (Cancel/No)</param>
        /// <param name="icon">Icon of the modal (Default is <see cref="Icon.Info"/>)</param>
        /// <returns></returns>
        public static SwalModel Confirm(string text, ConfirmButtonsType confirmButtonsType, string title, Action okClickHandler, Action cancelClickHandler, Icon icon = Icon.Info)
        {
            var model = new SwalModel()
            {
                Text = text,
                Title = title,
                Icon = icon
            };

            if(confirmButtonsType == ConfirmButtonsType.OkCancel)
            {
                model.AddButtons(new List<Button>
                            {
                                okClickHandler is null ? Button.Ok() : Button.Ok(okClickHandler),
                                cancelClickHandler is null ? Button.Cancel() : Button.Cancel(cancelClickHandler)
                            });
            }
            else if(confirmButtonsType == ConfirmButtonsType.YesNo)
            {
                model.AddButtons(new List<Button>
                            {
                                okClickHandler is null ? Button.Yes() : Button.Yes(okClickHandler),
                                cancelClickHandler is null ? Button.No() : Button.No(cancelClickHandler)
                            });
            }

            return model;
        }
        #endregion

        #region ---------- Confirm modals with Func<Task> click handlers ---------------

        public static SwalModel Confirm(string text, string title, Func<Task> okClickHandlerAsync, Func<Task> cancelClickHandlerAsync, Icon icon = Icon.Info) =>
            Confirm(text, ConfirmButtonsType.OkCancel, title, okClickHandlerAsync, cancelClickHandlerAsync, icon);

        /// <summary>
        /// Confirm model with two (negative and positive) buttons [Default buttons are Ok and Cancel]
        /// </summary>
        /// <param name="text">Modal text</param>
        /// <param name="confirmButtonsType">Buttons type (Availabel types are: Ok/Cancel and Yes/No)</param>
        /// <param name="title">Modal title</param>
        /// <param name="okClickHandler">Action delegate to be executed on the click of Positive button (Ok/Yes)</param>
        /// <param name="cancelClickHandler">Action delegate to be executed on the click of Negative button (Cancel/No)</param>
        /// <param name="icon">Icon of the modal (Default is <see cref="Icon.Info"/>)</param>
        /// <returns></returns>
        public static SwalModel Confirm(string text, ConfirmButtonsType confirmButtonsType, string title, 
                Func<Task> okClickHandlerAsync, Func<Task> cancelClickHandlerAsync, Icon icon = Icon.Info)
        {
            var model = new SwalModel()
            {
                Text = text,
                Title = title,
                Icon = icon
            };

            if (confirmButtonsType == ConfirmButtonsType.OkCancel)
            {
                model.AddButtons(new List<Button>
                            {
                                okClickHandlerAsync is null ? Button.Ok() : Button.Ok(okClickHandlerAsync),
                                cancelClickHandlerAsync is null ? Button.Cancel() : Button.Cancel(cancelClickHandlerAsync)
                            });
            }
            else if (confirmButtonsType == ConfirmButtonsType.YesNo)
            {
                model.AddButtons(new List<Button>
                            {
                                okClickHandlerAsync is null ? Button.Yes() : Button.Yes(okClickHandlerAsync),
                                cancelClickHandlerAsync is null ? Button.No() : Button.No(cancelClickHandlerAsync)
                            });
            }

            return model;
        }
        #endregion

    }
}
