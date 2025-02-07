# Blazor Hybrid Render Modes
![image](https://github.com/user-attachments/assets/03650d87-7eb6-493f-9b07-29d222c1a84d)


## Purpose

This demo application serves several purposes:

- To demonstrate how to mix and use different render modes in Blazor, including InteractiveServer, InteractiveWebAssembly, and InteractiveAuto.
- To showcase proper UI component design.
- To illustrate the use of a UI library (Blazor Bootstrap).

## Installation

### Clone the repository:

```bash
git clone https://github.com/mpierce1988/BlazorHybridRenderModes.git
cd BlazorHybridRenderModes
```

### Install the required .NET SDK:

Ensure you have the .NET SDK installed. You can download it from here.

### Build the application:

```bash
dotnet build
```

### Run the application:

```bash
dotnet run
```
### Open your browser:

Navigate to http://localhost:5021 to view the application.

## Usage

The application demonstrates various render modes in Blazor:
- InteractiveServer: Server-side rendering with interactivity.
- InteractiveWebAssembly: Client-side rendering using WebAssembly.
- InteractiveAuto: Automatically selects the appropriate render mode.

In order to change the RenderMode, change the "@rendermode" declaration on the /weather page:

_Interactive Server_
```CSHARP
@page "/weather"
@using WebAppRenderModes.Client.Shared.Weather
@rendermode @(new InteractiveServerRenderMode(false))
```

_Interactive WebAssembly_
```CSHARP
@page "/weather"
@using WebAppRenderModes.Client.Shared.Weather
@rendermode @(new InteractiveWebAssemblyRenderMode(false))
```

_Interactive Auto_
```CSHARP
@page "/weather"
@using WebAppRenderModes.Client.Shared.Weather
@rendermode @(new InteractiveAutoRenderMode(false))
```

It also showcases proper UI component design practices.

The application uses the Blazor Bootstrap UI library to enhance the user interface.

## Screenshots
_Location Search_
![image](https://github.com/user-attachments/assets/025ca218-c628-421b-959c-ed224096a2a7)

_Weather Forecast_
![image](https://github.com/user-attachments/assets/97a7ff6c-72bd-470f-8ae6-2b7063faa8c5)

_Weather Search Control_

![image](https://github.com/user-attachments/assets/38a693f3-ee39-473f-85fa-f48785989d5e)
