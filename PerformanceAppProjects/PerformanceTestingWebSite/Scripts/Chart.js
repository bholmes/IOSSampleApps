


function ShowMessage(myMessage) {
    alert(myMessage);
}

function drawGLWithData(argData, chartName) {
    var chartdata = google.visualization.arrayToDataTable(argData);

    // Create and draw the visualization.
    new google.visualization.LineChart(document.getElementById(chartName)).
            draw(chartdata, { curveType: "function", interpolateNulls: true,
                title: "OpenGL Results",
                backgroundColor: '#F7F6F3',
                hAxis: {title: "Number of Triagles"},
                vAxis: {title: "Frames Per Second"}
        });
}

function emptyGLChart(chartName) {

    var chartdata = google.visualization.arrayToDataTable([
        ['x', 'y'],
        [1, 1]
    ]);

    // Create and draw the visualization.
    new google.visualization.LineChart(document.getElementById(chartName)).
            draw(chartdata, { curveType: "function",
                backgroundColor: '#F7F6F3',
                legend : {position: 'none'} });
}

function drawFLOPChartWithData (argData, chartName)
{
	var data = google.visualization.arrayToDataTable(argData);

        var options = {
          title: 'FLOP Test',
          vAxis: {title: 'Device',  titleTextStyle: {color: 'black'}}
        };

        var chart = new google.visualization.BarChart(document.getElementById(chartName));
        chart.draw(data, options);
}

function emptyFLOPChart (chartName)
{

}

function drawChart() {
        
        drawFLOPChartWithData ([
          ['Device', 'C#', 'PInvoke', 'Obj C','MT BLAS', 'Obj C BLAS'],
          ['Device 1',  1000,      400, 1040, 420,590],
          ['Device 2',  1170,      460, 1040, 420,590],
          ['Device 3',  660,       1120, 1040, 420,590],
          ['Device 4',  1030,      540, 1040, null,590]
        ], 'FLOPResultsChart');
}

google.load('visualization', '1.1', { packages: ['corechart'] });

function pageLoad() {  
}