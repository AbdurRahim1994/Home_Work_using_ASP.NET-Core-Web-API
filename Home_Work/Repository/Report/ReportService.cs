using Home_Work.IRepository.Report;
using Home_Work.Models.Data;
using Home_Work.Models.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Home_Work.Repository.Report
{
    public class ReportService
    {
        public DataTable GetItemList(bool isActive)
        {
            try
            {
                DataTable dt = new DataTable();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
