using static SweetAlertBlazor.SweetAlert;

namespace SweetAlertBlazor
{
    /// <summary>
    /// Static Helper Methods
    /// </summary>
    public partial class SwalModel
    {
        public static SwalModel Alert(string text, string title = null!) => Alert(text, title, "OK");
        public static SwalModel Alert(string text, string title = null!, string buttonText = "OK") => new()
        {
            Text = text,
            Title = title,
            Buttons = new List<Button> { new Button(buttonText) }
        };

        public static SwalModel Alert(string text, Action onClickHandler, string title = null!) => Alert(text, onClickHandler, title);
        
        public static SwalModel Alert(string text, Action onClickHandler, string title, string buttonText = "OK") => new()
        {
            Text = text,
            Title = title,
            Buttons = new List<Button> { new Button(buttonText, onClickHandler) }
        };


        public static SwalModel Confirm(string text, ConfirmButtonsType confirmButtonsType = ConfirmButtonsType.OkCancel, string title = null!, Action okClickHandler = null!, Action cancelClickHandler = null!)
        {
            var model = new SwalModel()
            {
                Text = text,
                Title = title
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
        public static SwalModel Confirm(string text, Action okClickHandler, ConfirmButtonsType confirmButtonsType = ConfirmButtonsType.OkCancel) => 
            Confirm(text, confirmButtonsType, title: null!, okClickHandler, cancelClickHandler: null!);
    }
}
