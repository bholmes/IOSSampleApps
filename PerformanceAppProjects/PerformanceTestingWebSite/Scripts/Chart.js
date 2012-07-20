


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

function drawWithData(argData, chartName) {
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

function emptyChart(chartName) {

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

google.load('visualization', '1', { packages: ['corechart'] });
//google.setOnLoadCallback(drawVisualization);

function pageLoad() {  
}