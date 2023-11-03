using Grpc.Core;
using GrpcServer;
using Microsoft.EntityFrameworkCore.Storage;
using Google.Protobuf.WellKnownTypes;
using GrpcServer.Models;
namespace GrpcServer.Services
{
    public class CourseApiService : CoursesService.CoursesServiceBase
    {

        public override Task<ListReply> ListCourses(Empty request,
            //IServerStreamWriter<Response> writer,
            ServerCallContext context)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var listReply = new ListReply();
                var CourseList = db.Courses.Select(
                    item => new CourseReply { Id = item.Id, Title = item.Title, Duration=item.Duration, Description=item.Description }).ToList();
                listReply.Courses.AddRange(CourseList);
                return Task.FromResult(listReply);
            }
        }
        public override Task<CourseReply> GetCourse(GetCourseRequest request, ServerCallContext context)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var Course = db.Courses.SingleOrDefault(u => u.Id == request.Id);

                if (Course == null)
                    throw new RpcException(new Status(StatusCode.NotFound, "Course not found"));
                CourseReply CourseReply =
                    new CourseReply() { Id = Course.Id, Title = Course.Title,
                        Duration = Course.Duration, Description= Course.Description };
                return Task.FromResult(CourseReply);
            }
        }
        public override Task<CourseReply> CreateCourse(CreateCourseRequest request, ServerCallContext context)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var Course = new Course() { Title = request.Title, Duration = request.Duration, Description = request.Description };
                db.Courses.Add(Course);
                db.SaveChanges();
                var reply = new CourseReply() { Id = Course.Id, Title = Course.Title, Duration = Course.Duration, Description=Course.Description};
                return Task.FromResult(reply);
            }
        }
        public override Task<CourseReply> UpdateCourse(UpdateCourseRequest request, ServerCallContext context)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var Course = db.Courses.SingleOrDefault(p => p.Id == request.Id);

                if (Course == null)
                    throw new RpcException(new Status(StatusCode.NotFound, "Course not found"));

                Course.Title = request.Title;
                Course.Duration = request.Duration;
                Course.Description = request.Description;
                db.SaveChanges();

                var reply = new CourseReply() { Id = Course.Id, Title = Course.Title, Duration = Course.Duration};
                return Task.FromResult(reply);
            }
        }
        public override Task<CourseReply> DeleteCourse(DeleteCourseRequest request, ServerCallContext context)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var Course = db.Courses.SingleOrDefault(p => p.Id == request.Id);

                if (Course == null)
                    throw new RpcException(new Status(StatusCode.NotFound, "Course not found"));
                db.Courses.Remove(Course);
                db.SaveChanges();
                var reply = new CourseReply() { Id = Course.Id, Title = Course.Title, Duration = Course.Duration, Description=Course.Description};
                return Task.FromResult(reply);
            }
        }
    }
}

