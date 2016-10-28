using Bedrock_WeCath_WeiXin.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bedrock_WeCath_WeiXin.Models;

namespace Bedrock_WeCath_WeiXin.Controllers
{
    public class StudyCourseController : ApiController
    {
        HomeContext context = new HomeContext();

        // GET: api/StudyCourse
        public IEnumerable<StudyCourseIinfo> Get(string Jobnumber)
        {
            var StudyDetails = context.StudyDetails.Where(x => x.Jobnumber == Jobnumber).ToList();
            List<StudyCourseIinfo> CourseInfos = new List<StudyCourseIinfo>();
            foreach (var item in StudyDetails)
            {
                var CourseIinfo = context.StudyCourseIinfo.FirstOrDefault(x => x.CourseCode == item.CourseCode);

                CourseInfos.Add(CourseIinfo);
            }
            //筛选出Jobnumber未添加的课程
            var StudyCourses = context.StudyCourseIinfo.ToList().Except(CourseInfos);

            return StudyCourses;
        }

        // GET: api/StudyCourse/5
        public IEnumerable<object> Get(int id,string Jobnumber)
        {
            var StudyDetails = context.StudyDetails.Where(x => x.Jobnumber == Jobnumber).OrderBy(x=>x.Studystate).ToList();
            List<object> CourseInfos = new List<object>();
            foreach (var item in StudyDetails)
            {
                var query = from p in context.StudyCourseIinfo
                            where p.CourseCode == item.CourseCode
                            select new {
                                CourseTitle = p.CourseTitle,
                                CourseFinishTime = item.ExpectFinishDate.ToString().Substring(0, 10),
                                CourseCode = p.CourseCode,
                                CoursePM = p.CoursePM,
                                CoursePrincipal = p.CoursePrincipal,
                                State = context.StateType.FirstOrDefault(x => x.Id == item.Studystate).TypeName,
                                studyState = item.Studystate,
                                FinishTime = item.FinishStudyTime.ToString().Substring(0, 10),
                                StopTime = item.StopStartTime.ToString().Substring(0, 10),
                                startStudytime =item.StartStudyTime.ToString().Substring(0, 10)
                            };
                CourseInfos.Add(query);
            }

           
            return CourseInfos;
        }

        // POST: api/StudyCourse
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/StudyCourse/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/StudyCourse/5
        public void Delete(int id)
        {
        }
    }
}
