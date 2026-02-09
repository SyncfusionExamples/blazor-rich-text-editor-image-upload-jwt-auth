
# Secure Image Uploads in Blazor Rich Text Editor Using JWT Authentication

This repository contains a working sample that demonstrates **how to secure image uploads in the Syncfusion Blazor Rich Text Editor** by attaching and validating **JWT authentication tokens** during file uploads.

🔐 The server validates the token before saving any image, protecting your upload endpoint from unauthorized access and malicious requests.

## Prerequisites

- Visual Studio 2022  
- .NET 8.0+  
- Syncfusion Blazor Components

## How to run this application

### Clone the repository

```bash
git clone https://github.com/SyncfusionExamples/blazor-rich-text-editor-image-upload-jwt-auth.git
```
### Navigate into the project

```bash
cd blazor-rich-text-editor-image-upload-with-jwt-auth/BlazorApp
```

### Restore NuGet packages

```bash
dotnet restore
```

### Run the sample

```bash
dotnet run
```