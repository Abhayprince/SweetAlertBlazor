namespace SweetAlertBlazor
{
    public static partial class SweetAlert
    {
        /// <summary>
        /// Sweet Alert Javascript Options Model
        /// </summary>
        internal class Options
        {
            public string title { get; set; } = "";

            public string text { get; set; } = "";

            public string icon { get; set; } = default!;

            public bool closeOnClickOutside { get; set; } = true;

            public bool closeOnEsc { get; set; } = true;

            public bool dangerMode { get; set; } = false;

            public int? timer { get; set; }

            public string? className { get; set; }
            public object? buttons { get; set; } = default!;
        }
    }
}