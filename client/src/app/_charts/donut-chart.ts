export const donutChartOption: any = {
    chart: {
        type: 'pie',
        options3d: {
            enabled: true,
            alpha: 45
        }
    },
    title: {
        text: 'Utility wise Transactions'
    },
    subtitle: {
        text: 'Amount in Millions'
    },
    plotOptions: {
        pie: {
            innerSize: 100,
            depth: 45
        }
    },
    series: [{
        name: 'Delivered amount',
        data: [
            ['Aeps', 18],
            ['BBPS', 12],
            ['Domestic Money Transfer', 25],
            ['Airtickets', 13],
            ['IRCTC', 8],
            ['Cash-Drop', 14],
            ['Prepaid Recharge', 4]
        ]
    }]
}