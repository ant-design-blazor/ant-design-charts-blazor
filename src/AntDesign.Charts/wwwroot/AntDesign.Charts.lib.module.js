var beforeStartCalled = false;
var afterStartedCalled = false;

export function beforeWebStart() {
    loadScriptAndStyle();
}

export function beforeStart(options, extensions) {
   loadScriptAndStyle();
}

function loadScriptAndStyle() {
    if (beforeStartCalled) {
        return;
    }

    beforeStartCalled = true;

    const interopJS = "_content/AntDesign.Charts/ant-design-charts-blazor.js";
    const cdnJS = "https://unpkg.com/@antv/g2plot@2.4.31/dist/g2plot.min.js";
    const localJS = "_content/AntDesign.Charts/g2plot.min.js";
    const cdnFlag = document.querySelector('[use-ant-design-charts-cdn]');

    if (!document.querySelector(`[src="${interopJS}"]`)) {
        var chartJS = cdnFlag ? cdnJS : localJS;
        var chartScript = document.createElement('script');
        chartScript.setAttribute('src', chartJS);

        document.body.insertBefore(chartScript, document.body.querySelector("script"));

        var interopScript = document.createElement('script');
        interopScript.setAttribute('src', interopJS);
        chartScript.after(interopScript);
    }
}