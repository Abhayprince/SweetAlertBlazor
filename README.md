# SweetAlertBlazor
A simple yet fully configurable Blazor implementation of [SweetAlert](https://sweetalert.js.org "SweetAlert") (a popular javascript modal popups library) 

All the methods are defined as Extension Methods on IJSRuntime so no need to inject any additional service

### Usage
1. Install the `SweetAlertBlazor` package to your blazor application. [https://www.nuget.org/packages/BlazorStorage/]

2. Add the SweetAlert script reference to your *`index.html` (for Blazor WebAssembly)* or *`_Host.cshtml` (for Blazor Server)*

`<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>`

3. Add `@using SweetAlertBlazor` to the `_imports.razor` file

4. Inject the IJSRuntime to the component `@inject IJSRuntime Js`

5. Happy coding

### Samples

#### Alert
This is a sample alert modal popup with all the available options
````csharp
@inject IJSRuntime Js

//Generate options/configuration model
var swalAlertModel = new SwalModel("Hi this is a simple sweet alert blazor text", "Alert Title")
			.WithIcon(SweetAlert.Icon.Info) // Other Icons are Success, Error and Warning
			.WithButtons(SweetAlert.Button.Ok()) // ButtonText can be configured by using overloads
			.WithCssClass("my-custom-css-class") // To be used if want additional css logic
			.SetClosingOptions(closeOnEscButton: true, closeOnOutsideClick: true);

// Show the alert
 await Js.ShowSwalAsync(swalAlertModel);
````
#### Confirm
```csharp
// Create positive button
var yesButton = SweetAlert.Button.Yes(() => DoSomething());

// Generate options/configuration model
var swalModel = new SwalModel("There are unsaved changes, Do you want to cancel the changes?", "Are you sure?")
                .WithIcon(SweetAlert.Icon.Warning)
                .WithButtons(yesButton, SweetAlert.Button.No())
		.SetClosingOptions(closeOnEscButton: true, closeOnOutsideClick: true);

// Show the confirm modal
await Js.ShowSwalAsync(swalModel);
```
#### Buttons
````csharp
// button with click handler
 var button1 = new SweetAlert.Button("Button text 1")
                .WithClickHandler(() =>
                   {
                        //DoSomethingOnThisButtonClick
                   });
//Shorthand version
//var button1 = new SweetAlert.Button("Button text 1", () => { /* //DoSomethingOnThisButtonClick */ });


// button with asynchronous click handler
var button2 = new SweetAlert.Button()
                 .WithText("Button text 2")
                 .WithAsyncClickHandler(async () =>
                  {
                      await Task.CompletedTask;
                  });
// Shorthand version
// var button2 = new SweetAlert.Button("Button text 2", async () => { await Task.CompletedTask; });

// All options of button
var customButton = new SweetAlert.Button("Custom button text") // Button text
                      .WithCssClass("css-class-name") // this css class will be applied to the button
                      .WithClickHandler(() => { })  // Or Async version .WithAsyncClickHandler(async () => { })
                      .SetVisibilty(isVisible: true); // Whether to show the button or not

// Predefined buttons
var okBtn = SweetAlert.Button.Ok(); // Button text "Ok" with no click handler
var okBtn1 = SweetAlert.Button.Ok(() => {  /* Do something synchronously */}); // Button text "Ok" with synchronous click handler
var okBtn2 = SweetAlert.Button.Ok(async () => {  await Task.CompletedTask; }); // Button text "Ok" with Asynchronous click handler

 var cancelBtn = SweetAlert.Button.Cancel(); // Button text "Cancel" with no click handler
var cancelBtn1 = SweetAlert.Button.Cancel(() => {  /* Do something synchronously */}); // Button text "Cancel" with synchronous click handler
var cancelBtn2 = SweetAlert.Button.Cancel(async () => {  await Task.CompletedTask; }); // Button text "Cancel" with Asynchronous click handler

var yesBtn = SweetAlert.Button.Yes(); // Button text "Yes" with no click handler
var yesBtn1 = SweetAlert.Button.Yes(() => {  /* Do something synchronously */}); // Button text "Yes" with synchronous click handler
var yesBtn2 = SweetAlert.Button.Yes(async () => {  await Task.CompletedTask; }); // Button text "Yes" with Asynchronous click handler

var noBtn = SweetAlert.Button.No(); // Button text "No" with no click handler
var noBtn1 = SweetAlert.Button.No(() => {  /* Do something synchronously */}); // Button text "No" with synchronous click handler
var noBtn2 = SweetAlert.Button.No(async () => {  await Task.CompletedTask; }); // Button text "No" with Asynchronous click handler
````
#### Adding multiple buttons
```csharp
var button1 = new SweetAlert.Button("Button text 1", () => { /* //DoSomethingOnThisButtonClick */ });
var button2 = new SweetAlert.Button("Button text 2", async () => { await Task.CompletedTask; });
var okBtn = SweetAlert.Button.Ok();
var cancelBtn1 = SweetAlert.Button.Cancel(() => {  /* Do something synchronously */});

var swalModel = new SwalModel("Text of the modal popup")
                   .WithButtons(button1, button2, okBtn, cancelBtn1);

await Js.ShowSwalAsync(swalModel);
```
Or
```csharp
var buttonsList = new List<SweetAlert.Button>();
buttonsList.Add(button1);
buttonsList.Add(button2);
buttonsList.Add(okBtn);
buttonsList.Add(cancelBtn1);

var swalModelWithButtonsList = new SwalModel("Text of the modal popup")
                        .WithButtons(buttonsList);

await Js.ShowSwalAsync(swalModelWithButtonsList);
```
#####  All available options of SwalModel
```csharp
var swalModel = 
	new SwalModel()
	.WithText("Text of the popup")
	.WithTitle("Alert Title")
	.WithIcon(SweetAlert.Icon.Error)
	.WithCssClass("custom-css-class")
	.WithButton(SweetAlert.Button.Ok()) // OR .WithButtons(SweetAlert.Button.Ok(), SweetAlert.Button.Cancel())
	.SetClosingOptions(closeOnEscButton: true, closeOnOutsideClick: false)
	.AutoHide(afterSeconds: 5);
```
