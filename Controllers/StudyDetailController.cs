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

            studyDetail.CourseCode = context.StudyCourseIinfo.FirstOrDefault(x => x.CourseCode == studyDetail.CourseCode).CourseTitle;

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
            var dt = DateTime.Now;

            StudyDetails StudDetails = context.StudyDetails.FirstOrDefault(x => x.CourseCode == StudDetail.CourseCode && x.Jobnumber == StudDetail.Jobnumber);
            //根据id判断学习状态并做相应处理
            switch (id)
            {

                //开始学习
                #region
                case 1:
                    StudDetails.StartStudyTime = dt;
                    StudDetails.Studystate = 2;
                    //StudDetails.ExpectFinishDate = dt.AddDays(context.StudyCourseIinfo.FirstOrDefault(x=>x.CourseCode==StudDetails.CourseCode).CourseFinishTime);
                    double days = context.StudyCourseIinfo.FirstOrDefault(x => x.CourseCode == StudDetails.CourseCode).CourseFinishTime;
                    StudDetails.ExpectFinishDate = dt;
                    //循环用来排除总天数中的双休日    
                    for (var i = 0; i < days; i++)
                    {
                        var tempdt = dt.Date.AddDays(i+1);
                        if (tempdt.DayOfWeek == DayOfWeek.Saturday || tempdt.DayOfWeek == DayOfWeek.Sunday)
                        {
                            days++;
                        }
                        StudDetails.ExpectFinishDate = tempdt;
                       
                    }
                  
                    break;
                #endregion

                //暂停
                #region
                case 2:
                    StudDetails.Studystate = 3;
                    StudDetails.isStop = false;
                    StudDetails.StopStartTime = dt;
                    StudDetails.StopReason = StudDetail.StopReason;
                    break;
                #endregion
                //申请延后
                #region
                case 3:

                    StudDetails.isDefer = false;
                    StudDetails.DeferTime = StudDetail.DeferTime;
                    StudDetails.DeferReason = StudDetail.DeferReason;
                    break;
                #endregion
                //完成学习
                #region
                case 4:
                    StudDetails.Studystate = 4;
                    StudDetails.FinishStudyTime = dt;
                    break;
                #endregion
                //取消暂停
                #region
                case 5:
                    StudDetails.Studystate = 2;
                    StudDetails.StopEndTime = dt;
                    var fromTime = Convert.ToDateTime(StudDetails.StopStartTime);
                    TimeSpan ts = dt.Subtract(fromTime);
                    //获取两个日期间的总天数    
                    long countday = ts.Days;
                    //工作日  
                    long weekday = 0;
                    //循环用来扣除总天数中的双休日    
                    for (var i = 0; i < countday; i++)
                    {
                        var tempdt = fromTime.Date.AddDays(i + 1);
                        if (tempdt.DayOfWeek != DayOfWeek.Saturday && tempdt.DayOfWeek != DayOfWeek.Sunday)
                        {
                            weekday++;
                        }
                    }
                    //通过暂停的天数重新计算预期完成时间
                    var startdate = Convert.ToDateTime(StudDetails.ExpectFinishDate);
                    for (int i = 0; i < weekday; i++)
                    {
                        var tempdt = startdate.Date.AddDays(i + 1);
                        if (tempdt.DayOfWeek == DayOfWeek.Saturday || tempdt.DayOfWeek == DayOfWeek.Sunday)
                        {
                            weekday++;

                        }
                        StudDetails.ExpectFinishDate = tempdt;

                    }
                    break;
                    #endregion
                    //确认延后
                    case 6:
                    var day = StudDetails.DeferTime;
                    var startime = Convert.ToDateTime(StudDetails.ExpectFinishDate);
                    for (int i = 0; i < day; i++)
                    {
                        var tempdt = startime.Date.AddDays(i + 1);
                        if (tempdt.DayOfWeek == DayOfWeek.Saturday || tempdt.DayOfWeek == DayOfWeek.Sunday)
                        {
                            day++;

                        }
                        StudDetails.ExpectFinishDate = tempdt;

                    }
                    break;
                //取消延后
                 //case 7:
                 //   StudDetails.DeferTime =  null;
                 //   StudDetails.DeferReason = null;
                 //   break;
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
