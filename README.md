# ant-design-charts-blazor
A Blazor chart library, based on G2Plot


English | [简体中文](README-zh_CN.md)


## 💿 Current Version

- Release: [![AntDesign.Charts](https://img.shields.io/nuget/v/AntDesign.Charts.svg?color=red&style=flat-square)](https://www.nuget.org/packages/AntDesign.Charts/)
- Development: [![AntDesign.Charts](https://img.shields.io/nuget/vpre/AntDesign.Charts.svg?color=red&style=flat-square)](https://www.nuget.org/packages/AntDesign.Charts/)

## 📦 Installation Guide

- Go to the project folder of the application and install the Nuget package reference

  ```bash
  $ dotnet add package AntDesign.Charts
  ```
  
  - Link the static files in `wwwroot/index.html` (WebAssembly) or `Pages/_Host.razor` (Server)

  ```html
  <script src="https://unpkg.com/@antv/g2plot@latest/dist/g2plot.js"></script>
  <script src="_content/AntDesign.Charts/ant-design-charts-blazor.js"></script>
  ```
  
  - Add namespace in `_Imports.razor`

  ```csharp
  @using AntDesign.Charts
  ```
  
- Finally, it can be referenced in the `.razor' component!

  ```razor
  <Line Data="data" Config="config" />

  @code{
      object[] data = new object[] {
          new  { year= "1991", value= 3 },
          new  { year= "1992", value= 4 },
          new  { year= "1993", value= 3.5 },
          new  { year= "1994", value= 5 },
          new  { year= "1995", value= 4.9 },
          new  { year= "1996", value= 6 },
          new  { year= "1997", value= 7 },
          new  { year= "1998", value= 9 },
          new  { year= "1999", value= 13 },
  };

      LineConfig config = new LineConfig()
      {
          title = new Title()
          {
              visible = true,
              text = "曲线折线图",
          },
          description = new Description()
          {
              visible = true,
              text = "用平滑的曲线代替折线。",
          },
          padding = "auto",
          forceFit = true,
          xField = "year",
          yField = "value",
          smooth = true,
      };
  }
  ```
  
  ## 🔗 Links

- [Official Blazor Documentation](https://blazor.net)
