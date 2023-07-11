using ConsoleApp1.Models;
using ConsoleApp1.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Metadata;

class Program
{
    static async Task Main(string[] args)
    {
     
        await guardarEstudianteAsync();

    }

    public static async Task guardarEstudianteAsync()
    {

        Console.WriteLine("Guardar Estudiantes desde la clase Repository");
        
        EstudianteRepository estudianteRepository= new EstudianteRepository();
        Student std = new Student();
        std.Name = "Lola";
        std.LastName = "Perez";
        await estudianteRepository.guardarEstudiante(std);
    }

    public static async void guardarCursoAsync()
    {
        Console.WriteLine("Guardar Curso");
       CursoRepository cursoRepository = new CursoRepository();
        Course course = new Course();

        course.CourseName = "Tercero";
        
        await cursoRepository.guardarCurso(course);
    }

    public static async void guardarEstudianteCursoAsync()
    {
        Console.WriteLine("Guardar EstudianteCurso");
        
        StudentCourseRepository studentCourseRepository = new StudentCourseRepository();
        StudentCourse stdCourse = new StudentCourse();

        stdCourse.CourseId = 3;//course.CourseId;
        stdCourse.StudentId = 3; //std.StudentId;

        await studentCourseRepository.guardarStudentCourse(stdCourse);
    }
    public static async void guardarEstudianteYdireccionAsync()
    {
        Console.WriteLine("Metodo agregar estudiante y direccion");

        StudentAddressRepository studentAddressRepository = new StudentAddressRepository();
        EstudianteRepository estudianteRepository = new EstudianteRepository();
        Student std = new Student();
        StudentAddress stdAddress = new StudentAddress();
        
        std.Name = "Ciri";

        await estudianteRepository.guardarEstudiante(std);

        stdAddress.Address1 = "direccion 1";
        stdAddress.Address2 = "direccion 2";
        stdAddress.StudentID = std.StudentId;
        stdAddress.City = "gye";
        stdAddress.State = "ecu";
        stdAddress.Student= std;
       
        await studentAddressRepository.guardarStudentAddress(stdAddress);

    }

    

    public static async void consultarDireccionesAsync()
    {
        Console.WriteLine("Consultar direcciones");
        //Console.WriteLine("Metodo consultar estudiante por Id");
        StudentAddressRepository studentAddressRepository = new StudentAddressRepository();
        List<StudentAddress> listaDirecciones;
        listaDirecciones = await studentAddressRepository.buscarStudentAddresses();
        
        foreach (var item in listaDirecciones)
        {
            Console.WriteLine("Codigo:"+ item.Student.StudentId +
                " Nombre: " + item.Student.Name + 
                " Direccion:" + item.Address1);
        }
        

    }

    public static async void consultarDireccionAsync()
    {
        Console.WriteLine("Consultar direccion por Id");
        //Console.WriteLine("Metodo consultar estudiante por Id");
        StudentAddressRepository studentAddressRepository = new StudentAddressRepository();
        StudentAddress address = new StudentAddress();
        address = await studentAddressRepository.buscarStudentAddress(16);

        
        Console.WriteLine("Codigo: " + address.Student.StudentId +
                " Nombre: " + address.Student.Name +
                " Direccion: " + address.Address1);


    }

    
    public static void consultarAlumnosyCursos()
    {
        Console.WriteLine("Consultar un Alumnos y sus cursos con Include");

        SchoolContext context = new SchoolContext();
        List< StudentCourse> std;
        std = context.StudentCourses
            .Where(x => x.StudentId == 3)
            .Include(x => x.Course)
            .Include(x => x.Student)
            .ToList();


        Console.WriteLine("Cursos del estudiante " + std[0].StudentId + " " + std[0].Student.Name);

        foreach (var item in std)
        {
            Console.WriteLine("Curso: " + item.CourseId + " " + item.Course.CourseName);
        }


    }

    
    public static void consultarEstudiantes()
    {
        Console.WriteLine("Metodo consultar estudiantes");
        SchoolContext context = new SchoolContext();
        List<Student> listEstudiantes= context.Students.ToList() ;

        foreach (var item in listEstudiantes)
        {
            Console.WriteLine("Codigo: " + item.StudentId + " Nombre: " + item.Name);
        }
        
    }

    public static async void consultarEstudianteAsync()
    {
        Console.WriteLine("Metodo consultar estudiante por Id");
        EstudianteRepository estudianteRepository = new EstudianteRepository();
        Student std = new Student();
        std = await estudianteRepository.buscarEstudiante(11);

       Console.WriteLine("Codigo: " + std.StudentId + " Nombre: " + std.Name);
      
    }

    public static async void modificarEstudianteAsync()
    {
        Console.WriteLine("Metodo modificar estudiante");
        EstudianteRepository estudianteRepository = new EstudianteRepository();
        Student std = new Student();
        std = await estudianteRepository.buscarEstudiante(1);

        std.Name = "Anahi";
        
        await estudianteRepository.modificarEstudiante(std);

        Console.WriteLine("Codigo: " + std.StudentId + " Nombre: " + std.Name);

    }

    public static async void eliminarEstudianteAsync()
    {
        Console.WriteLine("Metodo eliminar estudiante");
        EstudianteRepository estudianteRepository = new EstudianteRepository();
        Student std = new Student();
        std = await estudianteRepository.buscarEstudiante(1);
        
        await estudianteRepository.eliminarEstudiante(std);

        Console.WriteLine("Codigo: " + std.StudentId + " Nombre: " + std.Name);

    }
    
}