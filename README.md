# Secure Image Uploads in Blazor Rich Text Editor Using JWT Authentication

Simple sample showing image insertion and secure uploads for the Syncfusion Rich Text Editor.

## What this shows

- Open a File Manager dialog from the editor toolbar, browse server files, and insert an image URL into the editor.
- Add form data (for example, a JWT or auth token) to uploads so the server can validate and authorize the request.

## Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022+ or VS Code
- Syncfusion Blazor packages (a license may be required)

## Quick setup
## Setup & Running Steps

Installation

```bash
git clone https://github.com/SyncfusionExamples/blazor-rich-text-editor-image-upload-jwt-auth.git
cd blazor-rich-text-editor-image-upload-jwt-auth
```

Restore NuGet packages

```bash
dotnet restore
```

Run the application

```bash
dotnet run
```

## Usage

1. Run the sample and open it in your browser.
2. Click the File Manager button in the editor toolbar to pick an image.
3. When uploading, the client adds auth fields (e.g. `authToken`) to the request; the server should validate those before saving.

## Troubleshooting

- If uploads fail, confirm the server accepts the posted form fields and that tokens are valid.
- If images do not display, verify the returned image URLs are reachable from the browser.

## Support

This sample is provided for demonstration purposes. For issues, open an issue in the repository.

## See also

- [Online examples](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=fluent2)
- [Documentation](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started-webapp)
