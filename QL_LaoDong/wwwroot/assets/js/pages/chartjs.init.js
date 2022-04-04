! function (s) {
    "use strict";
    var r = function () { };
    r.prototype.respChart = function (r, o, a, e) {
        Chart.defaults.global.defaultFontColor = "#6c7897", Chart.defaults.scale.gridLines.color = "rgba(108, 120, 151, 0.1)";
        var t = r.get(0).getContext("2d"),
            n = s(r).parent();
        function i() {
            r.attr("width", s(n).width());
            switch (o) {
                case "Line":
                    new Chart(t, {
                        type: "line",
                        data: a,
                        options: e
                    });
                    break;
                case "Doughnut":
                    new Chart(t, {
                        type: "doughnut",
                        data: a,
                        options: e
                    });
                    break;
                case "Pie":
                    new Chart(t, {
                        type: "pie",
                        data: a,
                        options: e
                    });
                    break;
                case "Bar":
                    new Chart(t, {
                        type: "bar",
                        data: a,
                        options: e
                    });
                    break;
                case "Radar":
                    new Chart(t, {
                        type: "radar",
                        data: a,
                        options: e
                    });
                    break;
                case "PolarArea":
                    new Chart(t, {
                        data: a,
                        type: "polarArea",
                        options: e
                    })
            }
        }
        s(window).resize(i), i()
    }, r.prototype.init = function () {
        this.respChart(s("#doughnut"), "Doughnut", {
            labels: ["Đã duyệt", "Chờ duyệt", "Báo bận"],
            datasets: [{
                data: [$("#daduyet").data("value"), $("#choduyet").data("value"), $("#baoban").data("value")],
                backgroundColor: ["#3ac9d6", "#ebeff2", "#CC0000"],
                hoverBackgroundColor: ["#3ac9d6", "#ebeff2", "#CC0000"],
                hoverBorderColor: "#fff"
            }]
        });
        this.respChart(s("#pie"), "Pie", {
            labels: ["Hoàn thành", "Chưa hoàn thành", "Chưa xét"],
            datasets: [{
                data: [$("#hoanthanh").data("value"), $("#chuahoanthanh").data("value"), $("#chuaxet").data("value")],
                backgroundColor: ["#f9c851", "#3ac9d6", "#ebeff2"],
                hoverBackgroundColor: ["#f9c851", "#3ac9d6", "#ebeff2"],
                hoverBorderColor: "#fff"
            }]
        });
    }, s.ChartJs = new r, s.ChartJs.Constructor = r
}(window.jQuery),
    function (r) {
        "use strict";
        window.jQuery.ChartJs.init()
    }();