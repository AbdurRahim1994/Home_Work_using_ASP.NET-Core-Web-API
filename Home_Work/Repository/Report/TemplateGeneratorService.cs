using Home_Work.DTO.Item;
using Home_Work.DTO.Purchase;
using Home_Work.IRepository.Report;
using System.Text;

namespace Home_Work.Repository.Report
{
    public class TemplateGeneratorService : ITemplateGeneratorService
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public TemplateGeneratorService(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> ItemListPdf(List<ItemDTO> obj)
        {
            try
            {
                string itemCss = webHostEnvironment.ContentRootPath + "/wwwroot/item_list.css/" + "item_list.css";
                var sb = new StringBuilder();
                sb.AppendFormat(@"
                        <html>
                            <head>
                            <link rel='stylesheet' href='{0}'/>
                            </head>
                            <body>
                                <div class='header'><h1>Item List Report</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>ID</th>
                                        <th>Name</th>
                                        <th>Quantity</th>
                                        <th>Active Status</th>
                                    </tr>", itemCss);
                foreach (var item in obj)
                {
                    sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", item.IntItemId, item.StrItemName, item.NumStockQuantity, item.IsActive);
                }
                sb.Append(@"
                                </table>
                            </body>
                        </html>");
                return sb.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<string> ItemWiseDailyPurchaseReportPdf(List<ItemWiseDailyPurchaseReportDTO> obj)
        {
            string itemCss = webHostEnvironment.ContentRootPath + "/wwwroot/item_list.css/" + "item_list.css";
            var sb=new StringBuilder();
            sb.AppendFormat(@"
                        <html>
                            <head>
                            <link rel='stylesheet' href='{0}'/>
                            </head>
                            <body>
                                <div class='header'><h1>Item Wise Daily Purchase Report</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>ID</th>
                                        <th>Name</th>
                                        <th>Date</th>
                                        <th>Unit Price</th>
                                        <th>Quantity</th>
                                    </tr>", itemCss);
            foreach (var item in obj)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                  </tr>", item.ItemId, item.ItemName, item.PurchaseDate, item.UnitPrice, item.Quantity);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }
    }
}
