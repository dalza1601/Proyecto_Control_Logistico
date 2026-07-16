// Solo UX: mostrar el nombre del archivo elegido y feedback de drag&drop.
const input = document.getElementById('archivoExcelInput');
const dropZone = document.querySelector('.drop-zone');
const nombreArchivo = document.getElementById('nombreArchivoSeleccionado');

input.addEventListener('change', () => {
    nombreArchivo.textContent = input.files.length ? `Seleccionado: ${input.files[0].name}` : '';
});

['dragenter', 'dragover'].forEach(evt =>
    dropZone.addEventListener(evt, e => { e.preventDefault(); dropZone.classList.add('dragover'); })
);
['dragleave', 'drop'].forEach(evt =>
    dropZone.addEventListener(evt, e => { e.preventDefault(); dropZone.classList.remove('dragover'); })
);
dropZone.addEventListener('drop', e => {
    if (e.dataTransfer.files.length) {
        input.files = e.dataTransfer.files;
        nombreArchivo.textContent = `Seleccionado: ${e.dataTransfer.files[0].name}`;
    }
});