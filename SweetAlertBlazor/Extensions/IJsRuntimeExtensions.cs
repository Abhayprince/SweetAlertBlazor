using Constants = SweetAlertBlazor.SwalConstants;
using Microsoft.JSInterop;
using static SweetAlertBlazor.SweetAlert;

namespace SweetAlertBlazor
{
    public static class IJsRuntimeExtensions
    {
        /// <summary>
        /// Display SweetAlert modal popup with the provided options/configurations
        /// </summary>
        /// <param name="jSRuntime"></param>
        /// <param name="model">SweetAlert modal popup configurations/options</param>
        /// <returns></returns>
        public static async ValueTask ShowSwalAsync(this IJSRuntime jSRuntime, SwalModel model)
        {
            var clickedBtnValue = await jSRuntime.InvokeAsync<string>(Constants.Swal, model.ToJsModel());
            if (clickedBtnValue is not null)
            {
                await model.OnAfterButtonClickAsync(clickedBtnValue);
            }
        }

        #region ---------- Alerts [with Single "Ok" Button]-----------------------

        /// <summary>
        /// Displays SweetAlert modal popup with single button with <paramref name="buttonText"/>
        /// </summary>
        /// <param name="jSRuntime"></param>
        /// <param name="text">Modal text</param>
        /// <param name="title">Modal title</param>
        /// <param name="buttonText">Text of the shown button</param>
        /// <returns></returns>
        public static async ValueTask ShowSwalAlertAsync(this IJSRuntime jSRuntime, string text, string title = null!, string buttonText = Constants.ButtonTexts.Ok) =>
            await ShowSwalAlertAsync(jSRuntime, text, title, okClickHandler: null!, buttonText);

        /// <summary>
        /// Displays SweetAlert modal popup with single button with <paramref name="buttonText"/>
        /// </summary>
        /// <param name="jSRuntime"></param>
        /// <param name="text">Modal text</param>
        /// <param name="okClickHandler">Action delegate to be executed on the click of the button</param>
        /// <param name="buttonText">Text of the shown button</param>
        /// <returns></returns>
        public static async ValueTask ShowSwalAlertAsync(this IJSRuntime jSRuntime, string text, Action okClickHandler, string buttonText = Constants.ButtonTexts.Ok) =>
            await ShowSwalAlertAsync(jSRuntime, text, title: null!, okClickHandler, buttonText);

        /// <summary>
        /// Displays SweetAlert modal popup with single button with <paramref name="buttonText"/>
        /// </summary>
        /// <param name="jSRuntime"></param>
        /// <param name="text">Modal text</param>
        /// <param name="title">Modal title</param>
        /// <param name="okClickHandler">Action delegate to be executed on the click of the button</param>
        /// <param name="buttonText">Text of the shown button</param>
        /// <returns></returns>
        public static async ValueTask ShowSwalAlertAsync(this IJSRuntime jSRuntime, string text, string title, Action okClickHandler, string buttonText = Constants.ButtonTexts.Ok)
        {
            var model = SwalModel.Alert(text, okClickHandler, title, buttonText);
            await ShowSwalAsync(jSRuntime, model);
        }

        /// <summary>
        /// Displays SweetAlert modal popup with single button with <paramref name="buttonText"/>
        /// </summary>
        /// <param name="jSRuntime"></param>
        /// <param name="text">Modal text</param>
        /// <param name="okClickHandlerAsync">Delegate to be executed asynchronously on the click of the button</param>
        /// <param name="buttonText">Text of the shown button</param>
        /// <returns></returns>
        public static async ValueTask ShowSwalAlertAsync(this IJSRuntime jSRuntime, string text, Func<Task> okClickHandlerAsync, string buttonText = Constants.ButtonTexts.Ok) =>
            await ShowSwalAlertAsync(jSRuntime, text, title: null!, okClickHandlerAsync, buttonText);

        /// <summary>
        /// Displays SweetAlert modal popup with single button with <paramref name="buttonText"/>
        /// </summary>
        /// <param name="jSRuntime"></param>
        /// <param name="text">Modal text</param>
        /// <param name="title">Modal title</param>
        /// <param name="okClickHandlerAsync">Delegate to be executed asynchronously on the click of the button</param>
        /// <param name="buttonText">Text of the shown button</param>
        /// <returns></returns>
        public static async ValueTask ShowSwalAlertAsync(this IJSRuntime jSRuntime, string text, string title, Func<Task> okClickHandlerAsync, string buttonText = Constants.ButtonTexts.Ok)
        {
            var model = SwalModel.Alert(text, okClickHandlerAsync, title, buttonText);
            await ShowSwalAsync(jSRuntime, model);
        }

        #endregion

        #region ---------- Confirm modals [with two Ok/Cancel buttons]-----------------------

        /// <summary>
        /// Displays SweetAlert confirmation modal popup with two (negative and positive) buttons [Ok/Cancel or Yes/No]
        /// </summary>
        /// <param name="jSRuntime"></param>
        /// <param name="text">Modal text</param>
        /// <param name="title">Modal title</param>
        /// <param name="buttonsType">Type of the buttons [Available types are Ok/Cancel and Yes/No]</param>
        /// <param name="okClickHandler">Action delegate to be executed on the click of the positive button (Ok/Yes)</param>
        /// <param name="cancelClickHandler">Action delegate to be executed on the click of the negative button (Cancel/No)</param>
        /// <param name="icon">Icon of the popup</param>
        /// <returns></returns>
        public static async ValueTask ShowSwalConfirmAsync(this IJSRuntime jSRuntime, 
            string text, string title, ConfirmButtonsType buttonsType, 
            Action okClickHandler, Action cancelClickHandler, Icon icon)
        {
            var model = SwalModel.Confirm(text, buttonsType, title, okClickHandler, cancelClickHandler, icon);
            await ShowSwalAsync(jSRuntime, model);
        }

        /// <summary>
        /// Displays SweetAlert confirmation modal popup with two (negative and positive) buttons [Ok/Cancel or Yes/No]
        /// </summary>
        /// <param name="jSRuntime"></param>
        /// <param name="text">Modal text</param>
        /// <param name="title">Modal title</param>
        /// <param name="buttonsType">Type of the buttons [Available types are Ok/Cancel and Yes/No]</param>
        /// <param name="okClickHandlerAsync">Delegate to be executed asynchronously on the click of the positive button (Ok/Yes)</param>
        /// <param name="cancelClickHandlerAsync">Delegate to be executed asynchronously on the click of the negative button (Cancel/No)</param>
        /// <param name="icon">Icon of the popup</param>
        /// <returns></returns>
        public static async ValueTask ShowSwalConfirmAsync(this IJSRuntime jSRuntime, 
            string text, string title, ConfirmButtonsType buttonsType, 
            Func<Task> okClickHandlerAsync, Func<Task> cancelClickHandlerAsync, Icon icon)
        {
            var model = SwalModel.Confirm(text, buttonsType, title, okClickHandlerAsync, cancelClickHandlerAsync, icon);
            await ShowSwalAsync(jSRuntime, model);
        }

        /// <summary>
        /// Displays SweetAlert confirmation modal popup with two (negative and positive) buttons [Ok/Cancel or Yes/No]
        /// </summary>
        /// <param name="jSRuntime"></param>
        /// <param name="text">Modal text</param>
        /// <param name="buttonsType">Type of the buttons [Available types are Ok/Cancel and Yes/No]</param>
        /// <param name="okClickHandler">Action delegate to be executed on the click of the positive button (Ok/Yes)</param>
        /// <param name="cancelClickHandler">Action delegate to be executed on the click of the negative button (Cancel/No)</param>
        /// <param name="icon">Icon of the popup</param>
        /// <returns></returns>
        public static async ValueTask ShowSwalConfirmAsync(this IJSRuntime jSRuntime,
            string text, ConfirmButtonsType buttonsType,
            Action okClickHandler, Action cancelClickHandler = null!, Icon icon = Icon.Info) =>
             await ShowSwalConfirmAsync(jSRuntime, text, title: null!, buttonsType, okClickHandler, cancelClickHandler, icon);

        /// <summary>
        /// Displays SweetAlert confirmation modal popup with two (negative and positive) buttons [Ok/Cancel or Yes/No]
        /// </summary>
        /// <param name="jSRuntime"></param>
        /// <param name="text">Modal text</param>
        /// <param name="buttonsType">Type of the buttons [Available types are Ok/Cancel and Yes/No]</param>
        /// <param name="okClickHandlerAsync">Delegate to be executed asynchronously on the click of the positive button (Ok/Yes)</param>
        /// <param name="cancelClickHandlerAsync">Delegate to be executed asynchronously on the click of the negative button (Cancel/No)</param>
        /// <param name="icon">Icon of the popup</param>
        /// <returns></returns>
        public static async ValueTask ShowSwalConfirmAsync(this IJSRuntime jSRuntime,
            string text, ConfirmButtonsType buttonsType,
            Func<Task> okClickHandlerAsync, Func<Task> cancelClickHandlerAsync = null!, Icon icon = Icon.Info) =>
             await ShowSwalConfirmAsync(jSRuntime, text, title: null!, buttonsType, okClickHandlerAsync, cancelClickHandlerAsync, icon);

        /// <summary>
        /// Displays SweetAlert confirmation modal popup with two (negative and positive) buttons [Ok/Cancel or Yes/No]
        /// </summary>
        /// <param name="jSRuntime"></param>
        /// <param name="text">Modal text</param>
        /// <param name="okClickHandler">Action delegate to be executed on the click of the positive button (Ok/Yes)</param>
        /// <param name="cancelClickHandler">Action delegate to be executed on the click of the negative button (Cancel/No)</param>
        /// <param name="buttonsType">Type of the buttons [Defaults to Ok/Cancel]</param>
        /// <param name="icon">Icon of the popup</param>
        /// <returns></returns>
        public static async ValueTask ShowSwalConfirmAsync(this IJSRuntime jSRuntime,
            string text, Action okClickHandler, Action cancelClickHandler = null!,
            ConfirmButtonsType buttonsType = ConfirmButtonsType.OkCancel, Icon icon = Icon.Info) =>
             await ShowSwalConfirmAsync(jSRuntime, text, title: null!, buttonsType, okClickHandler, cancelClickHandler, icon);

        /// <summary>
        /// Displays SweetAlert confirmation modal popup with two (negative and positive) buttons [Ok/Cancel or Yes/No]
        /// </summary>
        /// <param name="jSRuntime"></param>
        /// <param name="text">Modal text</param>
        /// <param name="okClickHandlerAsync">Delegate to be executed asynchronously on the click of the positive button (Ok/Yes)</param>
        /// <param name="cancelClickHandlerAsync">Delegate to be executed asynchronously on the click of the negative button (Cancel/No)</param>
        /// <param name="buttonsType">Type of the buttons [Defaults to Ok/Cancel]</param>
        /// <param name="icon">Icon of the popup</param>
        /// <returns></returns>
        public static async ValueTask ShowSwalConfirmAsync(this IJSRuntime jSRuntime,
            string text, Func<Task> okClickHandlerAsync, Func<Task> cancelClickHandlerAsync = null!,
            ConfirmButtonsType buttonsType = ConfirmButtonsType.OkCancel, Icon icon = Icon.Info) =>
             await ShowSwalConfirmAsync(jSRuntime, text, title: null!, buttonsType, okClickHandlerAsync, cancelClickHandlerAsync, icon);

        #endregion
    }

}
