# SweetAlertBlazor
A simple Blazor implementation of [SweetAlert](https://sweetalert.js.org "SweetAlert") (a popular javascript modal popups library) 

All the methods are defined as Extension Methods on IJSRuntime so no need to inject any additional service

### Usage
1. Install the `SweetAlertBlazor` package to your blazor application. [https://www.nuget.org/packages/BlazorStorage/]
2. Add the SweetAlert script reference to your *index.html (for Blazor WebAssembly)* or _*Host.cshtml (for Blazor Server)*
`<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>`
3.Inject the IJSRuntime to the component 
`@inject IJSRuntime Js`
4. Use the SwalMethods 

### Sample

##### Alert
This is a sample alert modal popup with all the available options
````csharp
@inject IJSRuntime Js

//Generate options/configuration model
var swalAlertModel = new SwalModel("Hi this is a simple sweet alert blazor text", "Alert Title")
						.WithIcon(SweetAlert.Icon.Info) // Other Icons are Success, Error and Warning
						.WithButtons(SweetAlert.Button.Ok()) // ButtonText can be configured by using overloads
						.WithCssClass("my-custom-css-class") // To be used if want additional css logic
						.SetClosingOptions(closeOnEscButton: false, closeOnOutsideClick: false);

// Show the alert
 await Js.ShowSwalAsync(swalAlertModel);
````
##### Confirm
```csharp
// Create positive button
var yesButton = SweetAlert.Button.Yes(() => DoSomething());

// Generate options/configuration model
var swalModel = new SwalModel("There are unsaved changes, Do you want to cancel the changes?", "Are you sure?")
                .WithIcon(SweetAlert.Icon.Warning)
                .WithButtons(yesButton, SweetAlert.Button.No())

// Show the confirm modal
await Js.ShowSwalAsync(swalModel);
```
