


function ShowMessage(myMessage) {
    alert(myMessage);
}

function drawVisualization(chartName) {
    // Create and populate the data table.
    drawWithData([
        ['x', 'Cats', 'Blanket 1', 'Blanket 2'],
        ['A', 1, 1, 0.5],
        ['B', 2, 0.5, 1],
        ['C', 4, 1, 0.5],
        ['D', 8, 0.5, 1],
    ], chartName);

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
 	//drawChart ();

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

function drawChart() {
        var data = google.visualization.arrayToDataTable([
          ['Device', 'C#', 'PInvoke', 'Obj C','MT BLAS', 'Obj C BLAS'],
          ['Device 1',  1000,      400, 1040, 420,590],
          ['Device 2',  1170,      460, 1040, 420,590],
          ['Device 3',  660,       1120, 1040, 420,590],
          ['Device 4',  1030,      540, 1040, 420,590],
          ['Device 5',  1000,      400, 1040, 420,590],
          ['Device 6',  1170,      460, 1040, 420,590],
          ['Device 7',  660,       1120, 1040, 420,590],
          ['Device 8',  1030,      540, 1040, 420,590]
        ]);

        var options = {
          title: 'FLOP Test',
          vAxis: {title: 'Device',  titleTextStyle: {color: 'black'}}
        };

        var chart = new google.visualization.BarChart(document.getElementById('FLOPResultsChart'));
        chart.draw(data, options);
      }

google.load('visualization', '1', { packages: ['corechart'] });
//google.setOnLoadCallback(drawVisualization);

function pageLoad() {  
}