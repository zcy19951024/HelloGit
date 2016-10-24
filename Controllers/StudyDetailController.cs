using Bedrock_WeCath_WeiXin.Context;
using Bedrock_WeCath_WeiXin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bedrock_WeCath_WeiXin.Controllers
{
    public class StudyDetailController : ApiController
    {
        HomeContext context = new HomeContext();

        // GET: api/StudyDetail
        public StudyDetails Get(string Jobnumber, string CourseCode)
        {
            var studyDetail = context.StudyDetails.FirstOrDefault(x => x.CourseCode==CourseCode && x.Jobnumber ==Jobnumber);

            return studyDetail;
        }

        // GET: api/StudyDetail/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/StudyDetail
        public string Post([FromBody]List<StudyDetails>  StdDetails)
        {
            foreach (var item in StdDetails)
            {
                var study = context.StudyDetails.Any(x => x.Jobnumber == item.Jobnumber && x.CourseCode == item.CourseCode);
                StudyDetails StdDetail = new StudyDetails();
                if (study)
                {
                    return "已添加该课程！";
                }
                StdDetail.isStop = true;
                StdDetail.isDefer = true;
                StdDetail.Studystate = 1;
                StdDetail.Emp_Id = item.Emp_Id;
                StdDetail.Jobnumber = item.Jobnumber;
                StdDetail.CourseCode = item.CourseCode;
                context.StudyDetails.Add(StdDetail);
            }
            context.SaveChanges();

            return "添加成功！";


        }

        // PUT: api/StudyDetail/5
        [HttpPost]
        public string Put(int id, [FromBody]StudyDetails StudDetail)
        { 


            StudyDetails StudDetails = context.StudyDetails.FirstOrDefault(x => x.CourseCode == StudDetail.CourseCode && x.Jobnumber == StudDetail.Jobnumber);
            //根据id判断学习状态并做相应处理
            switch (id)
            {
                //开始学习
                case 1:
                    StudDetails.StartStudyTime = DateTime.Now;
                    StudDetails.Studystate = 2;
                    StudDetails.ExpectFinishDate = DateTime.Now.AddDays(context.StudyCourseIinfo.FirstOrDefault(x=>x.CourseCode==StudDetails.CourseCode).CourseFinishTime);
                    break;
                   //暂停
                case 2:
                    StudDetails.Studystate = 3;
                    StudDetails.isStop = false;
                    StudDetails.StopStartTime = DateTime.Now;
                   
                    StudDetails.StopReason = StudDetail.StopReason;
                    break;
                    //延后
                case 3:
                   
                    StudDetails.isDefer = false;
                    StudDetails.ExpectFinishDate = Convert.ToDateTime(StudDetails.ExpectFinishDate).AddDays(Convert.ToDouble(StudDetail.DeferTime));
                    StudDetails.DeferReason = StudDetail.DeferReason;
                    break;
                    //完成学习
                case 4:
                    StudDetails.Studystate = 4;
                    StudDetails.FinishStudyTime = DateTime.Now;
                    break;
                    //取消暂停
                case 5:
                    StudDetails.Studystate = 2;
                    StudDetails.StopEndTime = StudDetail.StopEndTime;
                    TimeSpan day = DateTime.Now - Convert.ToDateTime(StudDetails.StopStartTime);
                    StudDetails.ExpectFinishDate = Convert.ToDateTime(StudDetails.ExpectFinishDate).AddDays(day.Days);
                    break;
                    //取消延后
                //case 6:
                //    StudDetails.StudyDate = 1;
                //    break;
            }
                
          
            context.SaveChanges();

            return "OK!";
        }

        // DELETE: api/StudyDetail/5
        public void Delete(int id)
        {
        }
    }
}
