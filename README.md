# Visual Studio offline installation user interface

A C#/WPF .NET 6 GUI for downloading a Visual Studio (2019/2022) offline installation layout.

This application provides the ability to download, update, and install Visual Studio. 
Please note, the download and update options download all workloads.
This tool also provides the ability to clean obsolete packages from the layout.

Possible download options:
- Optional components
- Recommend components
- Use the latest installer

## Build
1. Clone this repository.
2. Publish the project.

## Setup
1. Create the following directory: `C:\VS`.
2. Download the applicable bootstrapper for [VS2019](https://docs.microsoft.com/en-us/visualstudio/install/create-an-offline-installation-of-visual-studio?view=vs-2019) or [VS2022](https://docs.microsoft.com/en-us/visualstudio/install/create-an-offline-installation-of-visual-studio?view=vs-2022).
3. Copy the bootstrapper into `C:\VS`.

If required, you can customise the path to the boostrapper in the appsettings.json file.

## Use
1. Load: "...\VisualStudioDownloader\bin\Release\net6.0-windows\publish\Visual Studio Downloader.exe"
  - Select Download to download a new layout.
  - Select Update to update an existing layout.
  - Select Install to trigger the offline layout installation with the `--noWeb` switch applied.