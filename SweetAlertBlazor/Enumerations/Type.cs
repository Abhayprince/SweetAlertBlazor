namespace SweetAlertBlazor
{
    public static partial class SweetAlert
    {
        public enum Type
        {
            /// <summary>
            /// Modal popup with a single "Ok" button. Button text and visibility can be configured via <see cref="SweetAlert.SwalModel"/>
            /// </summary>
            Alert,

            /// <summary>
            /// Modal popup for confirmation with two button ["Ok" and "Cancel"]. Button texts and visibility can be configured via <see cref="SweetAlert.SwalModel"/>
            /// </summary>
            Confirm,

            /// <summary>
            /// Modal popup with custom button(s) configuration. Button texts and visibility can be configured via <see cref="SweetAlert.SwalModel"/>
            /// </summary>
            Custom
        }
    }
}