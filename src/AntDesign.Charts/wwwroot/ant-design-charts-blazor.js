// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.createChart = (type, domRef, data, options, others) => {
  const plot = new G2Plot[type](domRef, {
    data,
    ...options,
    ...others
  });

  plot.render();
}