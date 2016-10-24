using Bedrock_WeCath_WeiXin.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bedrock_WeCath_WeiXin.Models
{
    public class EmployeeInfoRepository:Interface1
    {
        HomeContext db = new HomeContext();
        private List<EmployeeInfo> emps = new List<EmployeeInfo>(); 
        //public static 
        private int _Id = 1;
        //EmployeeInfo empss = new EmployeeInfo();
        /*public EmployeeInfoRepository()
        {
            EmployeeInfo empsS = new EmployeeInfo();
            Add(new EmployeeInfo { ApplyStartTime= empsS.ApplyStartTime, ApplyEndTime= empsS.ApplyEndTime, ProbationStartTime
            = empsS.ProbationStartTime, ProbationEndTime= empsS.ProbationEndTime
            });  
        }*/
        public EmployeeInfoRepository()
        {
            Add(new EmployeeInfo { Id= _Id,ApplyStartTime=DateTime.Now,ApplyEndTime=DateTime.Now, ProbationStartTime=DateTime.Now, ProbationEndTime=DateTime.Now});
        }
       public IEnumerable<EmployeeInfo> GetAll()
        {
            return emps;
        }
        public EmployeeInfo Get(int id)
        {
            return emps.Find(p => p.Id == id);
        }
        public EmployeeInfo Add(EmployeeInfo item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _Id++;
            //db.EmployeeInfo.Add(item);
            //db.SaveChanges();
            return item;           
        }
        public void Remove(int id)
        {
            emps.RemoveAll(p => p.Id == id);
        }
       public bool Update(EmployeeInfo item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = emps.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            emps.RemoveAt(index);
            emps.Add(item);
            return true;
        }
    }
}