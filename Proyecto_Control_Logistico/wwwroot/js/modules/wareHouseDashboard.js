const labels = @Html.Raw(Json.Serialize(labels));
const serieEntradas = @Html.Raw(Json.Serialize(serieEntradas));
const serieSalidas = @Html.Raw(Json.Serialize(serieSalidas));

const inkMuted = '#8CA0AA';
const gridLine = 'rgba(232,237,239,0.06)';

// Grafico principal: entradas vs salidas
new Chart(document.getElementById('movChart'), {
    type: 'line',
    data: {
        labels: labels,
        datasets: [
            {
                label: 'Entradas',
                data: serieEntradas,
                borderColor: '#4FD1AE',
                backgroundColor: 'rgba(79,209,174,0.12)',
                fill: true, tension: 0.35, pointRadius: 0, borderWidth: 2.5
            },
            {
                label: 'Salidas',
                data: serieSalidas,
                borderColor: '#F2665E',
                backgroundColor: 'rgba(242,102,94,0.10)',
                fill: true, tension: 0.35, pointRadius: 0, borderWidth: 2.5
            }
        ]
    },
    options: {
        maintainAspectRatio: false,
        plugins: { legend: { display: false } },
        scales: {
            x: { ticks: { color: inkMuted, font: { size: 11 } }, grid: { display: false } },
            y: { ticks: { color: inkMuted, font: { size: 11 } }, grid: { color: gridLine } }
        }
    }
});

// Sparkline del hero (saldo)
new Chart(document.getElementById('sparkline'), {
    type: 'line',
    data: {
        labels: labels,
        datasets: [{
            data: serieEntradas.map((v, i) => v - serieSalidas[i]),
            borderColor: '#F2B84B',
            backgroundColor: 'rgba(242,184,75,0.12)',
            fill: true, tension: 0.4, pointRadius: 0, borderWidth: 2
        }]
    },
    options: {
        maintainAspectRatio: false,
        plugins: { legend: { display: false }, tooltip: { enabled: false } },
        scales: { x: { display: false }, y: { display: false } }
    }
});