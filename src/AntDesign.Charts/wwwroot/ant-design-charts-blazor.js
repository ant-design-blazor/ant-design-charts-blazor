// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.createChart = (domRef, data) => {
  console.log(data)
  const plot = new G2Plot.Line(domRef, {
    data,
    xField: 'year',
    yField: 'value',
  });

  plot.render();
}