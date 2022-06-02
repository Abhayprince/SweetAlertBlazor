using Microsoft.JSInterop;

namespace SweetAlertBlazor.Extensions
{
    public static class IJsRuntimeExtensions
    {
        public const string Swal = "swal";

        private static IJSInProcessRuntime GetSyncJs(IJSRuntime jSRuntime) => (jSRuntime as IJSInProcessRuntime)!;

        public static async ValueTask ShowSwalAsync(this IJSRuntime jSRuntime, SwalModel model)
        {
            var clickedBtnValue = await jSRuntime.InvokeAsync<string>(Swal, model.ToJsModel());
            if (clickedBtnValue is not null)
            {
                await model.OnAfterButtonClickAsync(clickedBtnValue);
            }
        }

        public static void ShowSwal(this IJSRuntime jSRuntime, SwalModel model) => ShowSwal(GetSyncJs(jSRuntime), model);
        public static void ShowSwal(this IJSInProcessRuntime jsInProcessRuntime, SwalModel model)
        {
            var clickedBtnValue = jsInProcessRuntime.Invoke<string>(Swal, model.ToJsModel());
            if (clickedBtnValue is not null)
            {
                model.OnAfterButtonClickAsync(clickedBtnValue).GetAwaiter().GetResult();
            }
        }

        #region ---------- Alerts [with Single "Ok" Button]-----------------------

        public static async ValueTask ShowSwalAlertAsync(this IJSRuntime jSRuntime, string text, string title = null!, string buttonText = "Ok")
        {
            var model = SwalModel.Alert(text, title, buttonText);
            await ShowSwalAsync(jSRuntime, model);
        }

        public static void ShowSwalAlert(this IJSRuntime jSRuntime, string text, string title = null!, string buttonText = "Ok") => 
            ShowSwalAlert(GetSyncJs(jSRuntime), text, title, buttonText);
        public static void ShowSwalAlert(this IJSInProcessRuntime jsInProcessRuntime, string text, string title = null!, string buttonText = "Ok")
        {
            var model = SwalModel.Alert(text, title, buttonText);
            ShowSwal(jsInProcessRuntime, model);
        }


        public static async ValueTask ShowSwalAlertAsync(this IJSRuntime jSRuntime, string text, Action okClickHandler, string buttonText = "Ok")
        {
            var model = SwalModel.Alert(text, okClickHandler, title: null!, buttonText);
            await ShowSwalAsync(jSRuntime, model);
        }

        public static void ShowSwalAlert(this IJSRuntime jSRuntime, string text, Action okClickHandler, string buttonText = "Ok") => 
            ShowSwalAlert(GetSyncJs(jSRuntime), text, okClickHandler, buttonText);
        public static void ShowSwalAlert(this IJSInProcessRuntime jsInProcessRuntime, string text, Action okClickHandler, string buttonText = "Ok")
        {
            var model = SwalModel.Alert(text, okClickHandler, title: null!, buttonText);
            ShowSwal(jsInProcessRuntime, model);
        }


        public static async ValueTask ShowSwalAlertAsync(this IJSRuntime jSRuntime, string text, string title, Action okClickHandler, string buttonText = "Ok")
        {
            var model = SwalModel.Alert(text, okClickHandler, title, buttonText);
            await ShowSwalAsync(jSRuntime, model);
        }

        public static void ShowSwalAlert(this IJSRuntime jSRuntime, string text, string title, Action okClickHandler, string buttonText = "Ok") => 
            ShowSwalAlert(GetSyncJs(jSRuntime), text, title, okClickHandler, buttonText);
        public static void ShowSwalAlert(this IJSInProcessRuntime jsInProcessRuntime, string text, string title, Action okClickHandler, string buttonText = "Ok")
        {
            var model = SwalModel.Alert(text, okClickHandler, title, buttonText);
            ShowSwal(jsInProcessRuntime, model);
        }

        #endregion
    }

}
