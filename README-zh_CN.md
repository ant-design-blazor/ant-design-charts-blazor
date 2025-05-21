# ant-design-charts-blazor

基于 G2Plot 的 Blazor 图表库

[English](./README.md) | 简体中文

## 💿 当前版本

- 正式发布: [![AntDesign.Charts](https://img.shields.io/nuget/v/AntDesign.Charts.svg?color=red&style=flat-square)](https://www.nuget.org/packages/AntDesign.Charts/)
- 开发构建: [![AntDesign.Charts](https://img.shields.io/nuget/vpre/AntDesign.Charts.svg?color=red&style=flat-square)](https://www.nuget.org/packages/AntDesign.Charts/)

## 📦 安装

- 进入应用的项目文件夹，安装 Nuget 包引用

  ```bash
  $ dotnet add package AntDesign.Charts
  ```

- 在 `_Imports.razor` 中加入命名空间

  ```csharp
  @using AntDesign.Charts
  ```

- 最后就可以在`.razor`组件中引用啦！

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

## 🔧 在配置中使用 JavaScript 函数

在配置图表时，你可以为 `formatter` 等属性或以 `Func` 结尾的属性定义 JavaScript 函数。这些函数会被正确地从字符串表示转换为实际的 JavaScript 函数。

### 支持的函数语法

支持以下 JavaScript 函数语法：

1. **标准函数声明**：

   ```csharp
   config.Tooltip.Formatter = "function(datum) { return { name: datum.year, value: '¥' + datum.value.toFixed(2) }; }";
   ```

2. **箭头函数**：

   ```csharp
   config.Tooltip.Formatter = "(datum) => { return { name: datum.year, value: '¥' + datum.value.toFixed(2) }; }";
   ```

3. **简洁箭头函数**（隐式返回）：

   ```csharp
   config.Tooltip.Formatter = "datum => '¥' + datum.value.toFixed(2)";
   ```

4. **简单表达式**：
   ```csharp
   config.Meta.Value.Formatter = "'¥' + datum * 100";
   ```

### 在数组属性中使用函数

JavaScript 函数也可以在数组内的对象中定义：

```csharp
config.Annotations = new[]
{
    new
    {
        type = "text",
        position = new[] { "min", "median" },
        content = "中间点",
        formatter = "function(item) { return item.value.toFixed(2); }"
    }
};
```

## 🎯 事件处理

图表支持多种事件，你可以在 Blazor 代码中处理这些事件。你可以使用 `On<T>` 和 `Once<T>` 方法来订阅图表事件。

### 基本事件用法

```csharp
<Line @ref="chartRef" Data="data" Config="config" />

@code {
    IChartComponent chartRef;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            // 直接使用 JsonElement
            chartRef.On("plot:click", (JsonElement data) =>
            {
                Console.WriteLine($"原始点击数据：{data}");
            });

            // 使用强类型模型
            chartRef.On<PlotEvent>("plot:click", (data) =>
            {
                Console.WriteLine($"点击坐标：x: {data.X}, y: {data.Y}");
            });
        }
    }

    class PlotEvent
    {
        public double X { get; set; }
        public double Y { get; set; }
        public object Data { get; set; }
    }
}
```

### 可用事件

常用的图表事件包括：

- `plot:click` - 点击图表时触发
- `plot:dblclick` - 双击图表时触发
- `plot:mousemove` - 鼠标在图表上移动时触发
- `plot:mouseenter` - 鼠标进入图表区域时触发
- `plot:mouseleave` - 鼠标离开图表区域时触发
- `element:click` - 点击图表元素时触发（如折线、柱状等）
- `legend-item:click` - 点击图例项时触发

### 一次性事件处理

使用 `Once<T>` 订阅只需处理一次的事件：

```csharp
await chartRef.Once<PlotEvent>("plot:click", (data) =>
{
    // 此处理程序只会被调用一次
    Console.WriteLine($"首次点击坐标：x: {data.X}, y: {data.Y}");
});
```

### 事件数据

事件数据默认以 `System.Text.Json.JsonElement` 类型传递，你可以直接处理它或使用泛型方法将其反序列化为特定类型。实际的事件数据结构取决于事件类型和图表类型。

典型的事件数据结构如下：

```csharp
public class ChartEventData
{
    public MappingData MappingData { get; set; }
    public ChartData Data { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public string Color { get; set; }
    public bool IsInCircle { get; set; }
    public string Shape { get; set; }
    public Style DefaultStyle { get; set; }
    public Point[] Points { get; set; }
    public Point[] NextPoints { get; set; }
}

public class MappingData
{
    public ChartData Origin { get; set; }
    public Point[] Points { get; set; }
    public Point[] NextPoints { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public string Color { get; set; }
}

public class ChartData
{
    public string Type { get; set; }
    public int Sales { get; set; }
}

public class Point
{
    public double X { get; set; }
    public double Y { get; set; }
}

public class Style
{
    public string Fill { get; set; }
    public double FillOpacity { get; set; }
}
```

事件数据处理示例：

```csharp
chartRef.On<ChartEventData>("element:click", (data) =>
{
    Console.WriteLine($"点击的元素：类型={data.Data.Type}, 销量={data.Data.Sales}");
    Console.WriteLine($"位置：X={data.X}, Y={data.Y}");
    Console.WriteLine($"样式：颜色={data.Color}, 形状={data.Shape}");
});
```

### 取消事件订阅

你可以使用 `Off` 方法取消事件订阅。有两种使用方式：

1. 取消特定的事件处理程序：
```csharp
@code {
    IChartComponent chartRef;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            // 使用方法订阅事件
            chartRef.On("plot:click", HandleChartClick);

            // 之后，取消这个特定的处理程序
            chartRef.Off("plot:click", HandleChartClick);
        }
    }

    private void HandleChartClick(JsonElement data)
    {
        Console.WriteLine($"点击事件：{data}");
    }
}
```

2. 取消特定事件或所有事件的所有处理程序：
```csharp
// 取消特定事件的所有处理程序
await chartRef.Off("plot:click");

// 取消所有事件的处理程序
await chartRef.Off();
```

在不再需要事件处理程序或组件即将销毁时取消订阅是一个好习惯：

```csharp
@implements IDisposable

@code {
    IChartComponent chartRef;
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            // 订阅多个事件
            chartRef.On("plot:click", HandleChartClick);
            chartRef.On("element:click", HandleElementClick);
        }
    }

    private void HandleChartClick(JsonElement data)
    {
        Console.WriteLine($"图表点击：{data}");
    }

    private void HandleElementClick(JsonElement data)
    {
        Console.WriteLine($"元素点击：{data}");
    }
    
    public async void Dispose()
    {
        // 在组件销毁时取消所有事件订阅
        if (chartRef != null)
        {
            await chartRef.Off();
        }
    }
}
```

## 🔗 链接

- [Blazor 官方文档](https://blazor.net)

## 🤝 如何贡献

[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](https://github.com/ant-design-blazor/ant-design-charts-blazor/pulls)

如果你希望参与贡献，欢迎 [Pull Request](https://github.com/ant-design-blazor/ant-design-charts-blazor/pulls)，或给我们 [报告 Bug](https://github.com/ant-design-blazor/ant-design-charts-blazor/issues/new) 。

## 💕 支持本项目

本项目以 MIT 协议开源，为了能得到够更好的且可持续的发展，我们期望获得更多的支持者，我们将把所得款项用于社区活动和推广。你可以通过如下任何一种方式支持我们:

- [OpenCollective](https://opencollective.com/ant-design-blazor)
- [微信](https://yangshunjie.com/images/qrcode/wepay.jpg)
- [支付宝](https://yangshunjie.com/images/qrcode/alipay.jpg)

我们会把详细的捐赠记录登记在 [捐赠者名单](https://github.com/ant-design-blazor/ant-design-blazor/issues/62)。

## ❓ 社区互助

如果您在使用的过程中碰到问题，可以通过以下途径寻求帮助，同时我们也鼓励资深用户通过下面的途径给新人提供帮助。

- [![Slack 群](https://img.shields.io/badge/Slack-AntBlazor-blue.svg?style=flat-square&logo=slack)](https://join.slack.com/t/AntBlazor/shared_invite/zt-etfaf1ww-AEHRU41B5YYKij7SlHqajA) (中文/英文)
- [![钉钉群](https://img.shields.io/badge/钉钉-AntBlazor-blue.svg?style=flat-square&logo=data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBzdGFuZGFsb25lPSJubyI/Pg0KPHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIGNsYXNzPSJpY29uIiB2aWV3Qm94PSIwIDAgMTAyNCAxMDI0IiBmaWxsPSIjZmZmZmZmIj4NCiAgPHBhdGggZD0iTTU3My43IDI1Mi41QzQyMi41IDE5Ny40IDIwMS4zIDk2LjcgMjAxLjMgOTYuN2MtMTUuNy00LjEtMTcuOSAxMS4xLTE3LjkgMTEuMS01IDYxLjEgMzMuNiAxNjAuNSA1My42IDE4Mi44IDE5LjkgMjIuMyAzMTkuMSAxMTMuNyAzMTkuMSAxMTMuN1MzMjYgMzU3LjkgMjcwLjUgMzQxLjljLTU1LjYtMTYtMzcuOSAxNy44LTM3LjkgMTcuOCAxMS40IDYxLjcgNjQuOSAxMzEuOCAxMDcuMiAxMzguNCA0Mi4yIDYuNiAyMjAuMSA0IDIyMC4xIDRzLTM1LjUgNC4xLTkzLjIgMTEuOWMtNDIuNyA1LjgtOTcgMTIuNS0xMTEuMSAxNy44LTMzLjEgMTIuNSAyNCA2Mi42IDI0IDYyLjYgODQuNyA3Ni44IDEyOS43IDUwLjUgMTI5LjcgNTAuNSAzMy4zLTEwLjcgNjEuNC0xOC41IDg1LjItMjQuMkw1NjUgNzQzLjFoODQuNkw2MDMgOTI4bDIwNS4zLTI3MS45SDcwMC44bDIyLjMtMzguN2MuMy41LjQuOC40LjhTNzk5LjggNDk2LjEgODI5IDQzMy44bC42LTFoLS4xYzUtMTAuOCA4LjYtMTkuNyAxMC0yNS44IDE3LTcxLjMtMTE0LjUtOTkuNC0yNjUuOC0xNTQuNXoiLz4NCjwvc3ZnPg0K)](https://h5.dingtalk.com/circle/healthCheckin.html?corpId=dingccf128388c3ea40eda055e4784d35b88&2f46=c9b80ba5&origin=11) (中文)

<details>
  <summary>点击扫描钉钉二维码</summary>
  <img src="./docs/assets/dingtalk.jpg" width="300">
</details>
