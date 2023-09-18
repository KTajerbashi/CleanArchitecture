/*=========================================================================================
    File Name: dashboard-ecommerce.js
    Description: Ecommerce Dashboard
    ----------------------------------------------------------------------------------------
    Item Name: Convex - Bootstrap 4 HTML Admin Dashboard Template
    Version: 1.0
    Author: PIXINVENT
    Author URL: http://www.themeforest.net/user/pixinvent
==========================================================================================*/

// chartist chart
// ------------------------------]
(function(window, document, $) {
    'use strict';
    $(window).on("load", function () {

        // Widget Area Chart 1 Starts
        var widgetlineChart = new Chartist.Line('#Widget-line-chart', {
            labels: [1,2,3,4,5,6],
            series: [
                [0,13,6,30,18,28]
            ]
        }, {
                low: 0,
                fullWidth: true,
                showArea: true,
                onlyInteger: true,
                targetLine: {
                    value: 30,
                    class: 'ct-target-line'
                },
                axisY: {
                    showGrid: false,
                    low: 0,
                    scaleMinSpace: 10,
                    showLabel: false,
                    offset: 0,
                },
                axisX: {
                    showGrid: false,
                    showLabel: false,
                    offset: 0,
                },
                lineSmooth: Chartist.Interpolation.simple({
                    divisor: 2
                }),
            });

        widgetlineChart.on('created', function (data) {
            var defs = data.svg.elem('defs');
            defs.elem('linearGradient', {
                id: 'wGradient',
                x1: 0,
                y1: 1,
                x2: 0,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(130,73,232, 1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(41,123,249, 1)'
            });
            const targetLineX = data.chartRect.x1 + (data.chartRect.width() - (data.chartRect.width() / data.bounds.step))

            data.svg.elem('line', {
                x1: targetLineX,
                x2: targetLineX,
                y1: data.chartRect.y1,
                y2: data.chartRect.y2
            }, data.options.targetLine.class);

        });
        widgetlineChart.on('draw', function (data) {
            var circleRadius = 10;
            if (data.type === 'point') {
                var circle = new Chartist.Svg('circle', {
                    cx: data.x,
                    cy: data.y,
                    r: circleRadius,
                    class: data.value.y === 30 ? 'ct-point-circle' : 'ct-point-circle-transperent'
                });
                data.element.replace(circle);
            }
        });
        // Widget Area Chart 1 Ends

        // Widget Area Chart 2 Starts
        var widgetlineChart = new Chartist.Line('#Widget-line-chart1', {
            labels: [1,2,3,4,5,6],
            series: [
                [0,13,6,30,18,28]
            ]
        }, {
                low: 0,
                fullWidth: true,
                showArea: true,
                onlyInteger: true,
                targetLine: {
                    value: 30,
                    class: 'ct-target-line'
                },
                axisY: {
                    showGrid: false,
                    low: 0,
                    scaleMinSpace: 10,
                    showLabel: false,
                    offset: 0,
                },
                axisX: {
                    showGrid: false,
                    showLabel: false,
                    offset: 0,
                },
                lineSmooth: Chartist.Interpolation.simple({
                    divisor: 2
                }),
            });

        widgetlineChart.on('created', function (data) {
            var defs = data.svg.elem('defs');
            defs.elem('linearGradient', {
                id: 'wGradient1',
                x1: 0,
                y1: 0,
                x2: 0,
                y2: 1
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(252,157,48, 1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(250,91,76, 1)'
            });
            var targetLineX = data.chartRect.x1 + (data.chartRect.width() - (data.chartRect.width() / data.bounds.step));

            data.svg.elem('line', {
                x1: targetLineX,
                x2: targetLineX,
                y1: data.chartRect.y1,
                y2: data.chartRect.y2
            }, data.options.targetLine.class);

        });
        widgetlineChart.on('draw', function (data) {
            var circleRadius = 10;
            if (data.type === 'point') {
                var circle = new Chartist.Svg('circle', {
                    cx: data.x,
                    cy: data.y,
                    r: circleRadius,
                    class: data.value.y === 30 ? 'ct-point-circle' : 'ct-point-circle-transperent'
                });
                data.element.replace(circle);
            }
        });
        // Widget Area Chart 2 Ends

        // Widget Area Chart 3 Starts
        var widgetlineChart = new Chartist.Line('#Widget-line-chart2', {
            labels: [1,2,3,4,5,6],
            series: [
                [0,13,6,30,18,28]
            ]
        }, {
                low: 0,
                fullWidth: true,
                showArea: true,
                onlyInteger: true,
                targetLine: {
                    value: 30,
                    class: 'ct-target-line'
                },
                axisY: {
                    showGrid: false,
                    low: 0,
                    scaleMinSpace: 10,
                    showLabel: false,
                    offset: 0,
                },
                axisX: {
                    showGrid: false,
                    showLabel: false,
                    offset: 0,
                },
                lineSmooth: Chartist.Interpolation.simple({
                    divisor: 2
                }),
            });

        widgetlineChart.on('created', function (data) {
            var defs = data.svg.elem('defs');
            defs.elem('linearGradient', {
                id: 'wGradient2',
                x1: 0,
                y1: 0,
                x2: 0,
                y2: 1
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(120, 204, 55, 1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(0, 75, 145, 1)'
            });
            const targetLineX = data.chartRect.x1 + (data.chartRect.width() - (data.chartRect.width() / data.bounds.step))

            data.svg.elem('line', {
                x1: targetLineX,
                x2: targetLineX,
                y1: data.chartRect.y1,
                y2: data.chartRect.y2
            }, data.options.targetLine.class);

        });
        widgetlineChart.on('draw', function (data) {
            var circleRadius = 10;
            if (data.type === 'point') {
                var circle = new Chartist.Svg('circle', {
                    cx: data.x,
                    cy: data.y,
                    r: circleRadius,
                    class: data.value.y === 30 ? 'ct-point-circle' : 'ct-point-circle-transperent'
                });
                data.element.replace(circle);
            }
        });
        // Widget Area Chart 3 Ends

        // Line with Area Chart Starts
        var lineArea = new Chartist.Line('#line-chart', {
            labels: ["1", "2", "3", "4", "5", "6", "7", "8"],
            series: [
                [0, 4500, 2600, 6100, 2600, 6500, 3200, 6800],
            ]
        }, {
                low: 0,
                fullWidth: true,
                onlyInteger: true,
                chartPadding: {
                    right: 20
                },
                axisY: {
                    low: 0,
                    scaleMinSpace: 60,
                    labelInterpolationFnc: function labelInterpolationFnc(value) {
                        return value / 1000 + 'K';
                    },
                },
                axisX: {
                    showGrid: false
                },
                lineSmooth: Chartist.Interpolation.simple({
                    divisor: 2
                }),
            });

        lineArea.on('created', function (data) {
            var defs = data.svg.elem('defs');
            defs.elem('linearGradient', {
                id: 'linear1',
                x1: 1,
                y1: 0,
                x2: 0,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(185,168,231, 1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(118,74,233, 1)'
            });
        });

        lineArea.on('draw', function (data) {
            var circleRadius = 10;
            if (data.type === 'point') {
                var circle = new Chartist.Svg('circle', {
                    cx: data.x,
                    cy: data.y,
                    r: circleRadius,
                    class: data.value.y === 0 || data.value.y === 6800 ? 'ct-circle-transperent' :  'ct-circle'
                });
                data.element.replace(circle);
            }
        });
        // Line with Area Chart Ends

        // Stack bar Chart Starts
        var Stackbarchart = new Chartist.Bar('#Stack-bar-chart', {
            labels: ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"],
            series: [
                [7, 4, 2, -2, -4, -7, -7, -4, -2, 2, 4, 7]
            ]
        }, {
                fullWidth: true,
                axisX: {
                    showGrid: false,
                },
                axisY: {
                    showGrid: true,
                    showLabel: false,
                    offset: 0
                },
                chartPadding: 30
            });

        Stackbarchart.on('created', function (data) {
            var defs = data.svg.elem('defs');
            defs.elem('linearGradient', {
                id: 'StackbarGradient',
                x1: 0,
                y1: 1,
                x2: 0,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(0, 201, 255,1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(17,228,183, 1)'
            });
        });

        Stackbarchart.on('draw', function (data) {
            if (data.type === 'bar') {
                data.element.attr({
                    style: 'stroke-width: 5px',
                    x1: data.x1 + 0.001
                });

                data.group.append(new Chartist.Svg('circle', {
                    cx: data.x2,
                    cy: data.y2,
                    r: 5
                }, 'ct-slice-bar'));

            }
            else if (data.type === 'label') {
                data.element.attr({
                    y: 270
                })
            }
        });
        // Stack bar Chart Ends

         // Bar Chart Starts
        var barChart = new Chartist.Bar('#bar-chart', {
            labels: ["ورزشی", "موزیک", "مسافرت", "اخبار", "وبلاگ"],
            series: [[35, 20, 30, 45, 55]]

        }, {
                axisX: {
                    showGrid: false,
                },
                axisY: {
                    showGrid: false,
                    showLabel: false,
                    offset: 0
                },
                low: 0,
                high: 60
            },
            [
                ['screen and (max-width: 640px)', {
                    seriesBarDistance: 5,
                    axisX: {
                        labelInterpolationFnc: function (value) {
                            return value[0];
                        }
                    }
                }]
            ]);

        barChart.on('created', function (data) {
            var defs = data.svg.elem('defs');
            defs.elem('linearGradient', {
                id: 'gradient4',
                x1: 0,
                y1: 1,
                x2: 0,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(238, 9, 121,1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(255, 106, 0, 1)'
            });
            defs.elem('linearGradient', {
                id: 'gradient5',
                x1: 0,
                y1: 1,
                x2: 0,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(0, 75, 145,1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(120, 204, 55, 1)'
            });

            defs.elem('linearGradient', {
                id: 'gradient6',
                x1: 0,
                y1: 1,
                x2: 0,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(132, 60, 247,1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(56, 184, 242, 1)'
            });
            defs.elem('linearGradient', {
                id: 'gradient7',
                x1: 0,
                y1: 1,
                x2: 0,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(155, 60, 183,1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(255, 57, 111, 1)'
            });
            defs.elem('linearGradient', {
                id: 'gradient8',
                x1: 0,
                y1: 1,
                x2: 0,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(0, 201, 255,1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(17,228,183, 1)'
            });
        });
        barChart.on('draw', function (data) {
            var barHorizontalCenter, barVerticalCenter, label, value;
            if (data.type === 'bar') {

                data.element.attr({
                    y1: 195,
                    x1: data.x1 + 0.001
                });

                data.group.append(new Chartist.Svg('circle', {
                    cx: data.x2,
                    cy: data.y2,
                    r: 12
                }, 'ct-slice-bar'));

            }
        });
        //Bar Chart Ends


        // Donut Chart Starts

        var Donutdata = {
            series: [
                {
                    "name": "done",
                    "className": "ct-done",
                    "value": 35
                },
                {
                    "name": "progress",
                    "className": "ct-progress",
                    "value": 14
                },
                {
                    "name": "outstanding",
                    "className": "ct-outstanding",
                    "value": 23
                }
            ]
        };

        var donut = new Chartist.Pie('#donut-dashboard-chart', {

            series: [
                {
                    "name": "done",
                    "className": "ct-done",
                    "value": 35
                },
                {
                    "name": "progress",
                    "className": "ct-progress",
                    "value": 14
                },
                {
                    "name": "outstanding",
                    "className": "ct-outstanding",
                    "value": 23
                }
            ]
        }, {
            donut: true,
            startAngle: 310,
            donutSolid: true,
            donutWidth: 30,
            labelInterpolationFnc: function (value) {
                var total = Donutdata.series.reduce(function (prev, series) {
                    return prev + series.value;
                }, 0);
                return total + '%';
            }
        });

        donut.on('created', function (data) {
            var defs = data.svg.elem('defs');
            defs.elem('linearGradient', {
                id: 'donutGradient1',
                x1: 0,
                y1: 1,
                x2: 0,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(155, 60, 183,1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(255, 57, 111, 1)'
            });
            defs.elem('linearGradient', {
                id: 'donutGradient2',
                x1: 0,
                y1: 1,
                x2: 0,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(0, 75, 145,0.8)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(120, 204, 55, 0.8)'
            });

            defs.elem('linearGradient', {
                id: 'donutGradient3',
                x1: 0,
                y1: 1,
                x2: 0,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(132, 60, 247,1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(56, 184, 242, 1)'
            });
        });

        donut.on('draw', function (data) {
            if (data.type === 'label') {
                if (data.index === 0) {
                    data.element.attr({
                        dx: data.element.root().width() / 2,
                        dy: data.element.root().height() / 2
                    });
                } else {
                    data.element.remove();
                }
            }
        });
        // Donut Chart Ends

    });
})(window, document, jQuery);