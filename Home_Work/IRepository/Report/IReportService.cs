using System.Data;

namespace Home_Work.IRepository.Report
{
    public interface IReportService
    {
        public Task<DataTable> GetItemList(bool isActive);
    }
}
