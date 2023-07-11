/*=========================================================================================
    File Name: dashboard-analytics.js
    Description: Analytics Dashboard
    ----------------------------------------------------------------------------------------
    Item Name: Convex - Bootstrap 4 HTML Admin Dashboard Template
    Version: 1.0
    Author: PIXINVENT
    Author URL: http://www.themeforest.net/user/pixinvent
==========================================================================================*/

// chartist chart
// ------------------------------
(function(window, document, $) {
    'use strict';
    $(window).on("load", function () {

        // Widget Area Chart 1 Starts
        var lineAreaWidget = new Chartist.Line('#widget-line-area', {
            labels: [1, 2, 3, 4, 5, 6],
            series: [
                [3, 20, 17, 35, 32, 45]
            ]
        }, {
                axisX: {
                    showGrid: false,
                    showLabel: false,
                    offset: 0,
                },
                axisY: {
                    showGrid: false,
                    low: 0,
                    showLabel: false,
                    offset: 0,
                },
                lineSmooth: Chartist.Interpolation.simple({
                    divisor: 2
                }),
                fullWidth: true,
                showArea: true,
                onlyInteger: true,
            });
        lineAreaWidget.on('created', function (data) {
            var defs = data.svg.elem('defs');
            defs.elem('linearGradient', {
                id: 'Wlinear',
                x1: 1,
                y1: 0,
                x2: 0,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(250,81,61, 0.8)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(250,55,79, 0.8)'
            });
        });
        lineAreaWidget.on('draw', function (data) {
            var circleRadius = 7;
            if (data.type === 'point') {
                var circle = new Chartist.Svg('circle', {
                    cx: data.x,
                    cy: data.y,
                    r: circleRadius,
                    class: data.value.y === 3 || data.value.y === 45 ? 'ct-point-circle-transperent' : 'ct-point-circle'
                });
                data.element.replace(circle);
            }
        });
        // Widget Area Chart 1 Ends

        // Widget Area Chart 2 Starts
        var lineAreaWidget2 = new Chartist.Line('#widget-line-area2', {
            labels: [1, 2, 3, 4, 5, 6],
            series: [
                [3, 20, 17, 35, 32, 45]
            ]
        }, {
                axisX: {
                    showGrid: false,
                    showLabel: false,
                    offset: 0,
                },
                axisY: {
                    showGrid: false,
                    low: 0,
                    showLabel: false,
                    offset: 0,
                },
                lineSmooth: Chartist.Interpolation.simple({
                    divisor: 2
                }),
                fullWidth: true,
                showArea: true,
                onlyInteger: true,
            });
        lineAreaWidget2.on('created', function (data) {
            var defs = data.svg.elem('defs');
            defs.elem('linearGradient', {
                id: 'Wlinear2',
                x1: 1,
                y1: 0,
                x2: 0,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(255, 0, 204, 0.5)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(51, 51, 153, 1)'
            });
        });
        lineAreaWidget2.on('draw', function (data) {
            var circleRadius = 7;
            if (data.type === 'point') {
                var circle = new Chartist.Svg('circle', {
                    cx: data.x,
                    cy: data.y,
                    r: circleRadius,
                    class: data.value.y === 3 || data.value.y === 45 ? 'ct-point-circle-transperent' : 'ct-point-circle'
                });
                data.element.replace(circle);
            }
        });
        // Widget Area Chart 2 Ends

        // Widget Area Chart 3 Starts
        var lineAreaWidget3 = new Chartist.Line('#widget-line-area3', {
            labels: [1, 2, 3, 4, 5, 6],
            series: [
                [3, 20, 17, 35, 32, 45]
            ]
        }, {
                axisX: {
                    showGrid: false,
                    showLabel: false,
                    offset: 0,
                },
                axisY: {
                    showGrid: false,
                    low: 0,
                    showLabel: false,
                    offset: 0,
                },
                lineSmooth: Chartist.Interpolation.simple({
                    divisor: 2
                }),
                fullWidth: true,
                showArea: true,
                onlyInteger: true,
            });
        lineAreaWidget3.on('created', function (data) {
            var defs = data.svg.elem('defs');
            defs.elem('linearGradient', {
                id: 'Wlinear3',
                x1: 1,
                y1: 0,
                x2: 0,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(56, 184, 242, 1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(132, 60, 247, 1)'
            });
        });
        lineAreaWidget3.on('draw', function (data) {
            var circleRadius = 7;
            if (data.type === 'point') {
                var circle = new Chartist.Svg('circle', {
                    cx: data.x,
                    cy: data.y,
                    r: circleRadius,
                    class: data.value.y === 3 || data.value.y === 45 ? 'ct-point-circle-transperent' : 'ct-point-circle'
                });
                data.element.replace(circle);
            }
        });
        // Widget Area Chart 3 Ends

        //--------

        // Line Chart Starts (Sales Analysis)
        var lineArea = new Chartist.Line('#line-area6', {
            labels: [1, 2, 3, 4, 5, 6, 7],
            series: [
                [10, 6, 15, 13, 20, 17, 19]
            ]
        }, {
                axisX: {
                    showGrid: false,
                },
                axisY: {
                    low: 0,
                    scaleMinSpace: 50,
                },
                low: 0,
                fullWidth: true,
                showArea: true,
                onlyInteger: true,
            },
            [
                ['screen and (max-width: 640px) and (min-width: 381px)', {
                    axisX: {
                        labelInterpolationFnc: function (value, index) {
                            return index % 2 === 0 ? value : null;
                        }
                    }
                }],
                ['screen and (max-width: 380px)', {
                    axisX: {
                        labelInterpolationFnc: function (value, index) {
                            return index % 3 === 0 ? value : null;
                        }
                    }
                }]
            ]);
        lineArea.on('created', function (data) {
            var defs = data.svg.elem('defs');
            defs.elem('linearGradient', {
                id: 'linear6',
                x1: 0,
                y1: 1,
                x2: 0,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(45,121,255,1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(249,81,255, 1)'
            });

            defs.elem('linearGradient', {
                id: 'gradient6',
                x1: 0,
                y1: 0,
                x2: 1,
                y2: 0
            }).elem('stop', {
                offset: 0.2,
                'stop-color': 'rgba(200,220,255, 1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(247,250,255, 1)'
            });
        });
        lineArea.on('draw', function (data) {
            var circleRadius = 10;
            if (data.type === 'point') {
                var circle = new Chartist.Svg('circle', {
                    cx: data.x,
                    cy: data.y,
                    r: circleRadius,
                    class: data.value.y === 15 ? 'ct-point-circle' : 'ct-point-circle-transperent'
                });
                data.element.replace(circle);
            }
        });
        // Line Chart 2 Ends
        
        // Line Chart 2 Starts (Statistics)
        var lineChart2 = new Chartist.Line('#line-chart2', {
            labels: ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"],
            series: [
                [160, 150, 140, 120, 75, 35, 45, 65, 100, 145, 160, 180],
                [100, 95, 90, 100, 110, 120, 130, 140, 130, 95, 75, 80]
            ]
        }, {
                axisX: {
                    showGrid: false,
                },
                axisY: {
                    low: 0,
                    scaleMinSpace: 50,
                },
                fullWidth: true,
            },
            [
                ['screen and (max-width: 640px) and (min-width: 381px)', {
                    axisX: {
                        labelInterpolationFnc: function (value, index) {
                            return index % 2 === 0 ? value : null;
                        }
                    }
                }],
                ['screen and (max-width: 380px)', {
                    axisX: {
                        labelInterpolationFnc: function (value, index) {
                            return index % 3 === 0 ? value : null;
                        }
                    }
                }]
            ]);
        lineChart2.on('created', function (data) {
            var defs = data.svg.elem('defs');
            defs.elem('linearGradient', {
                id: 'lineGradient1',
                x1: 0,
                y1: 1,
                x2: 0,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(252,157,48, 1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(250,91,76, 1)'
            });
            defs.elem('linearGradient', {
                id: 'lineGradient2',
                x1: 0,
                y1: 1,
                x2: 0,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(45,121,255,1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(249,81,255, 1)'
            });
        });
        lineChart2.on('draw', function (data) {
            var circleRadius = 8;
            if (data.type === 'point') {
                var circle = new Chartist.Svg('circle', {
                    cx: data.x,
                    cy: data.y,
                    r: circleRadius,
                    class: 'ct-circle'
                });
                data.element.replace(circle);
            }
            else if (data.type === 'label') {
                // adjust label position for rotation
                const dX = data.width / 2 + (30 - data.width)
                data.element.attr({ x: data.element.attr('x') - dX })
            }
        });
        // Line Chart 2 Ends

        
        // Line with Area Chart  Starts (User Conversion)
        var lineArea3 = new Chartist.Line('#line-area-chart', {
            labels: [1, 2, 3, 4, 5, 6, 7, 8],
            series: [
                [0, 5, 15, 8, 15, 9, 30, 0],
                [0, 3, 5, 2, 8, 1, 5, 0]
            ]
        }, {
                low: 0,
                showArea: true,
                fullWidth: true,
                onlyInteger: true,
                axisY: {
                    low: 0,
                    scaleMinSpace: 50,
                },
                axisX: {
                    showGrid: false
                }
            });

        lineArea3.on('created', function (data) {
            var defs = data.svg.elem('defs');
            defs.elem('linearGradient', {
                id: 'laGradient',
                x1: 0,
                y1: 1,
                x2: 1,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(0, 201, 255, 1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(146, 254, 157, 1)'
            });

            defs.elem('linearGradient', {
                id: 'laGradient1',
                x1: 0,
                y1: 1,
                x2: 1,
                y2: 0
            }).elem('stop', {
                offset: 0,
                'stop-color': 'rgba(132, 60, 247, 1)'
            }).parent().elem('stop', {
                offset: 1,
                'stop-color': 'rgba(56, 184, 242, 1)'
            });
        });
        lineArea3.on('draw', function (data) {
            var circleRadius = 6;
            if (data.type === 'point') {
                var circle = new Chartist.Svg('circle', {
                    cx: data.x,
                    cy: data.y,
                    r: circleRadius,
                    class: data.value.y === 0 ? 'ct-point-circle-transperent' :  'ct-point-circle'
                });
                data.element.replace(circle);
            }
        });
        // Line with Area Chart  Ends
    });
})(window, document, jQuery);