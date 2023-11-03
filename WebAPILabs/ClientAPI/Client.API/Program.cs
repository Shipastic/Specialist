using RESTClientAPI;

HttpClient httpClient = new HttpClient();
RESTClient restClient = new RESTClient("http://localhost:5225/", httpClient);

Console.WriteLine("Courses:");
var courses = await restClient.CourseAllAsync();
foreach (var course in courses)
    Console.WriteLine($"Course Title: {course.Title}");
Console.WriteLine("=======================================");

Console.WriteLine("Teachers:");
var teachers = await restClient.TeacherAllAsync();
foreach (var teacher in teachers)
    Console.WriteLine($"Teacher Name: {teacher.Name}");
Console.WriteLine("=======================================");

Console.WriteLine("Students:");
var students = await restClient.StudentAllAsync();
foreach(var student in students)
    Console.WriteLine($"Student Name: {student.Name}");
Console.WriteLine("=======================================");