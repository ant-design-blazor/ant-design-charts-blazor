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

  - Add namespace in `_Imports.razor`

  ```csharp
  @using AntDesign.Charts
  ```

- Finally, it can be referenced in the `.razor' component!

  ```razor
  <Line Data="data" Config="config" />

  @code {
      object[] data = new object[] {
          new  { year = "1991", value = 3 },
          new  { year = "1992", value = 4 },
          new  { year = "1993", value = 3.5 },
          new  { year = "1994", value = 5 },
          new  { year = "1995", value = 4.9 },
          new  { year = "1996", value = 6 },
          new  { year = "1997", value = 7 },
          new  { year = "1998", value = 9 },
          new  { year = "1999", value = 13 },
      };

      LineConfig config = new LineConfig()
          {
              Padding = "auto",
              XField = "year",
              YField = "value",
              Smooth = true,
          };
  }
  ```

## 🔧 Using JavaScript Functions in Configuration

When configuring charts, you can define JavaScript functions for properties like `formatter` or properties ending with `Func`. These functions will be properly converted from string representations to actual JavaScript functions.

### Supported Function Syntax

The following JavaScript function syntaxes are supported:

1. **Standard function declarations**:

   ```csharp
   config.Tooltip.Formatter = "function(datum) { return { name: datum.year, value: '$' + datum.value.toFixed(2) }; }";
   ```

2. **Arrow functions**:

   ```csharp
   config.Tooltip.Formatter = "(datum) => { return { name: datum.year, value: '$' + datum.value.toFixed(2) }; }";
   ```

3. **Concise arrow functions** (implicit return):

   ```csharp
   config.Tooltip.Formatter = "datum => '$' + datum.value.toFixed(2)";
   ```

4. **Simple expressions**:
   ```csharp
   config.Meta.Value.Formatter = "'$' + datum * 100";
   ```

### Using Functions with Array Properties

JavaScript functions can also be defined within objects inside arrays:

```csharp
config.Annotations = new[]
{
    new
    {
        type = "text",
        position = new[] { "min", "median" },
        content = "Middle point",
        formatter = "function(item) { return item.value.toFixed(2); }"
    }
};
```

## 🔗 Links

- [Official Blazor Documentation](https://blazor.net)

## 🤝 Contributing

[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](https://github.com/ant-design-blazor/ant-design-charts-blazor/pulls)

If you would like to contribute, feel free to create a [Pull Request](https://github.com/ant-design-blazor/ant-design-charts-blazor/pulls), or give us [Bug Report](https://github.com/ant-design-blazor/ant-design-charts-blazor/issues/new).

## 💕 Donation

This project is an MIT-licensed open source project. In order to achieve better and sustainable development of the project, we expect to gain more backers. We will use the proceeds for community operations and promotion. You can support us in any of the following ways:

- [OpenCollective](https://opencollective.com/ant-design-blazor)
- [Wechat](https://yangshunjie.com/images/qrcode/wepay.jpg)
- [Alipay](https://yangshunjie.com/images/qrcode/alipay.jpg)

We will put the detailed donation records on the [backer list](https://github.com/ant-design-blazor/ant-design-blazor/issues/62).

## ❓ Community Support

If you encounter any problems in the process, feel free to ask for help via following channels. We also encourage experienced users to help newcomers.

- [![Slack Group](https://img.shields.io/badge/Slack-AntBlazor-blue.svg?style=flat-square&logo=slack)](https://join.slack.com/t/AntBlazor/shared_invite/zt-etfaf1ww-AEHRU41B5YYKij7SlHqajA) (Chinese & English)
- [![Ding Talk Group](https://img.shields.io/badge/DingTalk-AntBlazor-blue.svg?style=flat-square&logo=data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBzdGFuZGFsb25lPSJubyI/Pg0KPHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIGNsYXNzPSJpY29uIiB2aWV3Qm94PSIwIDAgMTAyNCAxMDI0IiBmaWxsPSIjZmZmZmZmIj4NCiAgPHBhdGggZD0iTTU3My43IDI1Mi41QzQyMi41IDE5Ny40IDIwMS4zIDk2LjcgMjAxLjMgOTYuN2MtMTUuNy00LjEtMTcuOSAxMS4xLTE3LjkgMTEuMS01IDYxLjEgMzMuNiAxNjAuNSA1My42IDE4Mi44IDE5LjkgMjIuMyAzMTkuMSAxMTMuNyAzMTkuMSAxMTMuN1MzMjYgMzU3LjkgMjcwLjUgMzQxLjljLTU1LjYtMTYtMzcuOSAxNy44LTM3LjkgMTcuOCAxMS40IDYxLjcgNjQuOSAxMzEuOCAxMDcuMiAxMzguNCA0Mi4yIDYuNiAyMjAuMSA0IDIyMC4xIDRzLTM1LjUgNC4xLTkzLjIgMTEuOWMtNDIuNyA1LjgtOTcgMTIuNS0xMTEuMSAxNy44LTMzLjEgMTIuNSAyNCA2Mi42IDI0IDYyLjYgODQuNyA3Ni44IDEyOS43IDUwLjUgMTI5LjcgNTAuNSAzMy4zLTEwLjcgNjEuNC0xOC41IDg1LjItMjQuMkw1NjUgNzQzLjFoODQuNkw2MDMgOTI4bDIwNS4zLTI3MS45SDcwMC44bDIyLjMtMzguN2MuMy41LjQuOC40LjhTNzk5LjggNDk2LjEgODI5IDQzMy44bC42LTFoLS4xYzUtMTAuOCA4LjYtMTkuNyAxMC0yNS44IDE3LTcxLjMtMTE0LjUtOTkuNC0yNjUuOC0xNTQuNXoiLz4NCjwvc3ZnPg0K)](https://h5.dingtalk.com/circle/healthCheckin.html?corpId=dingccf128388c3ea40eda055e4784d35b88&2f46=c9b80ba5&origin=11) (Chinese)

<details>
  <summary>Scan QR Code with DingTalk</summary>
  <img src="./docs/assets/dingtalk.jpg" width="300">
</details>
