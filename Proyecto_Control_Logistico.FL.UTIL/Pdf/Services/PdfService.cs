using Proyecto_Control_Logistico.Domain.Entities;
using Proyecto_Control_Logistico.FL.UTIL.Pdf.Interfaces;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Proyecto_Control_Logistico.FL.UTIL.Pdf.Services
{
    public class PdfService : IPdfService
    {
        public byte[] GenerateSaleReceipt(Sale sale)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(40);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(text => text.FontSize(10));

                    page.Header().Column(column =>
                    {
                        column.Item().Text("BOLETA DE VENTA")
                            .FontSize(20)
                            .Bold()
                            .AlignCenter();

                        column.Item().Text($"Nro. venta: {sale.NumberSale}")
                            .FontSize(11)
                            .AlignCenter();

                        column.Item().Text($"Fecha: {sale.DateSale:dd/MM/yyyy HH:mm}")
                            .FontSize(11)
                            .AlignCenter();
                    });

                    page.Content().PaddingVertical(20).Column(column =>
                    {
                        column.Spacing(12);

                        column.Item().Border(1).Padding(10).Column(clientColumn =>
                        {
                            clientColumn.Item().Text("Datos del cliente").Bold();
                            clientColumn.Item().Text($"Cliente: {sale.Client?.FullName ?? "Sin cliente"}");
                            clientColumn.Item().Text($"Correo: {sale.Client?.Email ?? "Sin correo"}");
                            clientColumn.Item().Text($"Estado de venta: {sale.Status}");
                        });

                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(3);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Element(HeaderCell).Text("Producto");
                                header.Cell().Element(HeaderCell).AlignRight().Text("Cantidad");
                                header.Cell().Element(HeaderCell).AlignRight().Text("Precio");
                                header.Cell().Element(HeaderCell).AlignRight().Text("Subtotal");
                            });

                            foreach (var detail in sale.SaleDetails)
                            {
                                table.Cell().Element(BodyCell).Text(detail.Product?.Name ?? "Producto");
                                table.Cell().Element(BodyCell).AlignRight().Text(detail.Quantity.ToString("0.##"));
                                table.Cell().Element(BodyCell).AlignRight().Text($"S/ {detail.UnitPrice:0.00}");
                                table.Cell().Element(BodyCell).AlignRight().Text($"S/ {detail.TotalPrice:0.00}");
                            }

                            static IContainer HeaderCell(IContainer container)
                            {
                                return container
                                    .Background(Colors.Grey.Lighten3)
                                    .Border(1)
                                    .Padding(5);
                            }

                            static IContainer BodyCell(IContainer container)
                            {
                                return container
                                    .BorderBottom(1)
                                    .BorderColor(Colors.Grey.Lighten2)
                                    .Padding(5);
                            }
                        });

                        column.Item().AlignRight().Text($"TOTAL: S/ {sale.TotalAmount:0.00}")
                            .FontSize(14)
                            .Bold();
                    });

                    page.Footer().AlignCenter().Text("Gracias por su compra.");
                });
            }).GeneratePdf();
        }
    }
}