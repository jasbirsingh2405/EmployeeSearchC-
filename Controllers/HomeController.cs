using EmployeeTwo.Models;
using EmployeeTwo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;





using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace EmployeeTwo.Controllers
{
    public class HomeController : Controller
    {



        [HttpGet]
        public IActionResult Index()
        {
            EmpDepDesSki emp = new EmpDepDesSki();
            //var skii = new List<Skill>();
            //var Dept = new List<Department>();
            // var Desg = new List<Designation>();
            List<EmpModelyoo1> empModel = new List<EmpModelyoo1>();
            EmployeePerson employeePerson = new EmployeePerson();

            using (var context = new EmployeeContext())
            {
                var skii = context.skills.ToList();
                var Dept = context.departments.ToList();
                var Desg = context.designations.ToList();

                emp.EmpModelyoo1 = empModel;
                emp.Department = Dept;
                emp.Skill = skii;
                emp.Designation = Desg;
            }


            emp.EmployeePerson = employeePerson;

            return View(emp);
        }


/*
        [HttpPost]
         public IActionResult Search(EmpDepDesSki empDepDesSki, string Gender) 
         {
             EmpDepDesSki emp = new EmpDepDesSki();
             var skii = new List<Skill>();
             var Dept = new List<Department>();
             var Desg = new List<Designation>();
             EmployeePerson  employeePerson= new EmployeePerson();

             int depId = empDepDesSki.DepartmentId==0 ? 0 : empDepDesSki.DepartmentId;
             int desgId = empDepDesSki.DesignationId==0 ? 0 : empDepDesSki.DesignationId;
             string gen = Gender == null ? null : Gender;
             string firstName = empDepDesSki.EmployeePerson.FirstName == null ? null : empDepDesSki.EmployeePerson.FirstName;
             string lastName = empDepDesSki.EmployeePerson.LastName==null ? null : empDepDesSki.EmployeePerson.LastName;


             List<EmpModelyoo1> empMod=new List<EmpModelyoo1>();

             List<Object> em2 = new List<Object>();

            
             int i = 0;
             string quer=null;
             string queryy = "SELECT e.* FROM(SELECT DISTINCT e.*, (SELECT s.skillName + ',' AS[text()]FROM dbo.skills s join dbo.employeeSkills es on  es.SkillId = s.SkillId join dbo.employeePersons ep on ep.EmployeePersonId = es.EmployeePersonId WHERE ep.EmployeePersonId = e.EmployeePersonId FOR XML PATH(''), TYPE).value('text()[1]', 'nvarchar(max)') as skillConcat   FROM dbo.employeePersons e ";
 ;
            

             using (var context = new EmployeeContext())
             {
                
                 if(depId == 0 && desgId == 0 && gen == null &&  firstName == null && lastName == null)
                 {

                     skii = context.skills.ToList();
                     Dept = context.departments.ToList();
                     Desg = context.designations.ToList();


                     emp.Department = Dept;
                     emp.Skill = skii;
                     emp.Designation = Desg;

                     using (var command = context.Database.GetDbConnection().CreateCommand())
                     {
                         //command.CommandText = "select  e.EmployeePersonId,e.FirstName,e.LastName,e.DOB,e.DOJ,e.DepartmentId,e.DesignationId,concat ( sk.SkillName, ',') as skills  from  dbo.employeePersons e   join dbo.employeeSkills  s on e.EmployeePersonId=s.EmployeePersonId join skills sk on s.SkillId = sk.SkillId  where e.FirstName like 'man%' ";

                         command.CommandText = $"SELECT e.*FROM(SELECT DISTINCT e.*,(SELECT s.skillName + ',' AS[text()]FROM dbo.skills s join dbo.employeeSkills es on  es.SkillId = s.SkillId join dbo.employeePersons ep on ep.EmployeePersonId = es.EmployeePersonId WHERE ep.EmployeePersonId = e.EmployeePersonId FOR XML PATH(''), TYPE ).value('text()[1]', 'nvarchar(max)') as skillConcat   FROM dbo.employeePersons e ) as e";
                         context.Database.OpenConnection();
                         using (var result = command.ExecuteReader())
                         {



                             while (result.Read())
                             {
                                 object[] values = new object[result.FieldCount];
                                 result.GetValues(values);
                                 em2.Add(values);
                             }

                         }
                     }


                     foreach (object[] item in em2)
                     {
                         EmpModelyoo1 empModel = new EmpModelyoo1();
                         int count = 0;
                         foreach (object value in item)
                         {
                             switch (count)
                             {
                                 case 0:
                                     {
                                         empModel.EmployeePersonId = (Int32)value;
                                         count++;
                                         break;
                                     }
                                 case 1:
                                     {
                                         empModel.FirstName = value.ToString();
                                         count++;
                                         break;
                                     }
                                 case 2:
                                     {
                                         empModel.LastName = value.ToString();
                                         count++;
                                         break;
                                     }
                                 case 3:
                                     {

                                         DateTime d = (DateTime)value;


                                         var D = d.Day;
                                         string? dt;
                                         if (D < 10)
                                         {
                                             dt = "0" + D.ToString();
                                         }
                                         else { dt = D.ToString(); }

                                         String mm = d.ToString("MMM");
                                         var y = d.Year;

                                         string finalDate = dt + "-" + mm + "-" + y.ToString();

                                         empModel.DOB = finalDate;
                                         count++;
                                         break;
                                     }
                                 case 4:
                                     {
                                         empModel.Gender = value.ToString();
                                         count++;
                                         break;
                                     }
                                 case 5:
                                     {
                                         var id = (Int32)value;

                                         var dept = context.departments.Where(x => x.DepartmentId == id).Single();
                                         empModel.DepartmentName = dept.DepartmentName;

                                         count++;
                                         break;
                                     }
                                 case 6:
                                     {

                                         var id = (Int32)value;

                                         var desg = context.designations.Where(x => x.DesignationId == id).Single();
                                         empModel.DesignationName = desg.DesignationName;
                                         count++;
                                         break;
                                     }
                                 case 7:
                                     {
                                         DateTime d = (DateTime)value;


                                         var D = d.Day;
                                         string? dt;
                                         if (D < 10)
                                         {
                                             dt = "0" + D.ToString();
                                         }
                                         else { dt = D.ToString(); }

                                         String mm = d.ToString("MMM");
                                         var y = d.Year;

                                         string finalDate = dt + "-" + mm + "-" + y.ToString();

                                         empModel.DOJ = finalDate;
                                         count++;
                                         break;
                                     }
                                 case 8:
                                     {
                                         empModel.Salary = (Int32)value;
                                         count++;
                                         break;
                                     }
                                 default:
                                     {
                                         string? v = value.ToString();
                                         string? str = v;
                                         str = str?.Remove(str.Length - 1, 1);
                                         empModel.skillConcat = str;

                                     }
                                     //empModel.EmployeeSkills = skillList;
                                     count++;
                                     break;
                             }


                         };

                         empMod.Add(empModel);
                     }

                     //EmployeePerson employeePerson = new EmployeePerson();





                     emp.EmpModelyoo1 = empMod;

                     //var mod = JsonConvert.SerializeObject(empMod);
                     HttpContext.Session.SetString("queryList", JsonConvert.SerializeObject(emp));
                     if (firstName != null)
                     {
                         HttpContext.Session.SetString("firstName", firstName);
                         employeePerson.FirstName = firstName;
                     }
                     if (lastName != null)
                     {
                         HttpContext.Session.SetString("lastName", lastName);
                         employeePerson.LastName = lastName;

                     }
                     if (gen != null)
                     {
                         HttpContext.Session.SetString("gen", gen);
                         employeePerson.Gender = gen;
                     }
                     if (depId != null)
                     {
                         HttpContext.Session.SetString("depId", depId.ToString());
                         emp.DepartmentId = depId;
                     }
                     if (desgId != null)
                     {
                         HttpContext.Session.SetString("desgId", desgId.ToString());
                         emp.DesignationId = desgId;
                     }

                     emp.EmployeePerson = employeePerson;

                     return View("Index", emp);




                 }


                 if (depId != 0)
                 {
                     // tot["DepartmentId"] = "depId";
                     if (quer == null)
                     {
                         quer = queryy + $" where e.DepartmentId={depId} ) as e ";
                     }
                     else
                     {
                         quer = quer + " UNION " + queryy + $" where e.DepartmentId={depId} ) as e ";
                     }



                 }
                 if (desgId != 0)
                 {
                     if (quer == null)
                     {
                         quer = queryy + $" where e.DesignationId={desgId} ) as e ";
                     }
                     else
                     {
                         quer = quer + " UNION " + queryy + $" where e.DesignationId={desgId} ) as e ";
                     }
                 }
                 if (gen != null)
                 {
                     if (quer == null)
                     {
                         quer = queryy + $" where e.Gender='{gen}' ) as e ";
                     }
                     else
                     {
                         quer = quer + " UNION " + queryy + $" where e.Gender='{gen}' ) as e ";
                     }
                 }
                 if (firstName != null)
                 {
                     if (quer == null)
                     {
                         //quer = queryy + " where e.FirstName={firstName} ) as e ).ToList()";
                         quer = queryy + $" where e.FirstName like '%{firstName}%' ) as e ";
                     }
                     else
                     {
                         quer = quer + " UNION " + queryy + $" where e.FirstName like '%{firstName}%' ) as e ";
                     }

                 }
                 if (lastName != null)
                 {
                     if (quer == null)
                     {
                         quer = queryy + $" where e.Lastname like '%{lastName}%' ) as e ";
                     }
                     else
                     {
                         quer = quer + " UNION " + queryy + $" where e.LastName like '%{lastName}%' ) as e ";
                     }
                 }

                 skii = context.skills.ToList();
                 Dept = context.departments.ToList();
                 Desg = context.designations.ToList();



                 emp.Department = Dept;
                 emp.Skill = skii;
                 emp.Designation = Desg;

                 //var empModel=context.EmpModelyoo.FromSqlInterpolated($"SELECT e.* FROM(SELECT DISTINCT e.*, (SELECT s.skillName + ',' AS[text()]FROM dbo.skills s join dbo.employeeSkills es on  es.SkillId = s.SkillId join dbo.employeePersons ep on ep.EmployeePersonId = es.EmployeePersonId WHERE ep.EmployeePersonId = e.EmployeePersonId FOR XML PATH(''), TYPE).value('text()[1]', 'nvarchar(max)') as skillConcat   FROM dbo.employeePersons e where e.FirstName={firstName}) as e").ToList();
                 //var empModel = context.EmpModelyoo.FromSqlInterpolated($"SELECT e.* FROM(SELECT DISTINCT e.*, (SELECT s.skillName + ',' AS[text()]FROM dbo.skills s join dbo.employeeSkills es on  es.SkillId = s.SkillId join dbo.employeePersons ep on ep.EmployeePersonId = es.EmployeePersonId WHERE ep.EmployeePersonId = e.EmployeePersonId FOR XML PATH(''), TYPE).value('text()[1]', 'nvarchar(max)') as skillConcat   FROM dbo.employeePersons e  where e.FirstName={firstName} ) as e ).ToList()");
                 //var emp1Model = context.EmpModelyoo.FromSqlRaw($"{quer}");
                 int s=0;
                 using (var command = context.Database.GetDbConnection().CreateCommand())
                 {

                     command.CommandText = $"{quer}";
                     if (quer != null) 
                     {
                         s = quer.Length;
                     }

                     context.Database.OpenConnection();
                     if (s > 6) 
                     {
                         using (var result = command.ExecuteReader())
                         {



                             while (result.Read())
                             {
                                 object[] values = new object[result.FieldCount];
                                 result.GetValues(values);
                                 em2.Add(values);
                             }

                         }

                     }



                 }


                 foreach (object[] item in em2)
                 {
                     EmpModelyoo1 empModel = new EmpModelyoo1();
                     int count = 0;
                     foreach (object value in item)
                     {
                         switch (count)
                         {
                             case 0:
                                 {
                                     empModel.EmployeePersonId = (Int32)value;
                                     count++;
                                     break;
                                 }
                             case 1:
                                 {
                                     empModel.FirstName = value.ToString();
                                     count++;
                                     break;
                                 }
                             case 2:
                                 {
                                     empModel.LastName = value.ToString();
                                     count++;
                                     break;
                                 }
                             case 3:
                                 {  

                                     DateTime d = (DateTime)value;


                                     var D = d.Day;
                                     string? dt;
                                     if (D < 10)
                                     {
                                         dt = "0" + D.ToString();
                                     }
                                     else { dt = D.ToString(); }

                                     String mm = d.ToString("MMM");
                                     var y = d.Year;

                                     string finalDate = dt + "-" + mm + "-" + y.ToString();

                                     empModel.DOB = finalDate;
                                     count++;
                                     break;
                                 }
                             case 4:
                                 {
                                     empModel.Gender = value.ToString();
                                     count++;
                                     break;
                                 }
                             case 5:
                                 {
                                     var id = (Int32)value;

                                     var dept = context.departments.Where(x => x.DepartmentId == id).Single();
                                     empModel.DepartmentName = dept.DepartmentName;

                                     count++;
                                     break;
                                 }
                             case 6:
                                 {

                                     var id = (Int32)value;

                                     var desg = context.designations.Where(x => x.DesignationId == id).Single();
                                     empModel.DesignationName = desg.DesignationName;
                                     count++;
                                     break;
                                 }
                             case 7:
                                 {
                                     DateTime d = (DateTime)value;


                                     var D = d.Day;
                                     string? dt;
                                     if (D < 10)
                                     {
                                         dt = "0" + D.ToString();
                                     }
                                     else { dt = D.ToString(); }

                                     String mm = d.ToString("MMM");
                                     var y = d.Year;

                                     string finalDate = dt + "-" + mm + "-" + y.ToString();

                                     empModel.DOJ = finalDate;
                                     count++;
                                     break;
                                 }
                             case 8:
                                 {
                                     empModel.Salary = (Int32)value;
                                     count++;
                                     break;
                                 }
                             default:
                                 {
                                     string? v = value.ToString();
                                     string? str = v;
                                     str = str?.Remove(str.Length - 1, 1);
                                     empModel.skillConcat = str;

                                 }
                                 //empModel.EmployeeSkills = skillList;
                                 count++;
                                 break;
                         }


                     };

                     empMod.Add(empModel);
                 }



             }

           //  EmployeePerson employeePerson = new EmployeePerson();





             emp.EmpModelyoo1 = empMod;

             //var mod = JsonConvert.SerializeObject(empMod);
             //HttpContext.Session.SetString("queryList", JsonConvert.SerializeObject(emp));
                HttpContext.Session.SetString("queryList", JsonConvert.SerializeObject(empMod));

             if(firstName != null)
             {
                 HttpContext.Session.SetString("firstName", firstName);
                 employeePerson.FirstName = firstName;
             }
             if(lastName != null)
             {
                 HttpContext.Session.SetString("lastName", lastName);
                 employeePerson.LastName = lastName;

             }
             if (gen != null)
             {
                 HttpContext.Session.SetString("gen", gen);
                 employeePerson.Gender = gen;
             }
             if(depId != null)
             {
                 HttpContext.Session.SetString("depId", depId.ToString());
                 emp.DepartmentId = depId;
             }
            if(desgId != null)
             {
                 HttpContext.Session.SetString("desgId", desgId.ToString());
                 emp.DesignationId = desgId;
             }

             emp.EmployeePerson = employeePerson;

             return View("Index",emp);



         }*/

/*        public IActionResult ExactSearch(EmpDepDesSki empDepDesSki, string Gender)
        {
            EmpDepDesSki emp = new EmpDepDesSki();
            var skii = new List<Skill>();
            var Dept = new List<Department>();
            var Desg = new List<Designation>();
            EmployeePerson employeePerson = new EmployeePerson();

            int depId = empDepDesSki.DepartmentId == 0 ? 0 : empDepDesSki.DepartmentId;
            int desgId = empDepDesSki.DesignationId == 0 ? 0 : empDepDesSki.DesignationId;
            string gen = Gender == null ? null : Gender;
            string firstName = empDepDesSki.EmployeePerson.FirstName == null ? null : empDepDesSki.EmployeePerson.FirstName;
            string lastName = empDepDesSki.EmployeePerson.LastName == null ? null : empDepDesSki.EmployeePerson.LastName;
            List<EmpModelyoo1> empMod = new List<EmpModelyoo1>();

            List<Object> em2 = new List<Object>();


            int i = 0;
            string quer = null;
            string queryy = "SELECT e.* FROM(SELECT DISTINCT e.*, (SELECT s.skillName + ',' AS[text()]FROM dbo.skills s join dbo.employeeSkills es on  es.SkillId = s.SkillId join dbo.employeePersons ep on ep.EmployeePersonId = es.EmployeePersonId WHERE ep.EmployeePersonId = e.EmployeePersonId FOR XML PATH(''), TYPE).value('text()[1]', 'nvarchar(max)') as skillConcat   FROM dbo.employeePersons e  where ";
            ;


            using (var context = new EmployeeContext())
            {

                if (depId == 0 && desgId == 0 && gen == null && firstName == null && lastName == null)
                {

                    skii = context.skills.ToList();
                    Dept = context.departments.ToList();
                    Desg = context.designations.ToList();


                    emp.Department = Dept;
                    emp.Skill = skii;
                    emp.Designation = Desg;

                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        //command.CommandText = "select  e.EmployeePersonId,e.FirstName,e.LastName,e.DOB,e.DOJ,e.DepartmentId,e.DesignationId,concat ( sk.SkillName, ',') as skills  from  dbo.employeePersons e   join dbo.employeeSkills  s on e.EmployeePersonId=s.EmployeePersonId join skills sk on s.SkillId = sk.SkillId  where e.FirstName like 'man%' ";

                        command.CommandText = $"SELECT e.*FROM(SELECT DISTINCT e.*,(SELECT s.skillName + ',' AS[text()]FROM dbo.skills s join dbo.employeeSkills es on  es.SkillId = s.SkillId join dbo.employeePersons ep on ep.EmployeePersonId = es.EmployeePersonId WHERE ep.EmployeePersonId = e.EmployeePersonId FOR XML PATH(''), TYPE ).value('text()[1]', 'nvarchar(max)') as skillConcat   FROM dbo.employeePersons e ) as e";
                        context.Database.OpenConnection();
                        using (var result = command.ExecuteReader())
                        {



                            while (result.Read())
                            {
                                object[] values = new object[result.FieldCount];
                                result.GetValues(values);
                                em2.Add(values);
                            }

                        }
                    }


                    foreach (object[] item in em2)
                    {
                        EmpModelyoo1 empModel = new EmpModelyoo1();
                        int count = 0;
                        foreach (object value in item)
                        {
                            switch (count)
                            {
                                case 0:
                                    {
                                        empModel.EmployeePersonId = (Int32)value;
                                        count++;
                                        break;
                                    }
                                case 1:
                                    {
                                        empModel.FirstName = value.ToString();
                                        count++;
                                        break;
                                    }
                                case 2:
                                    {
                                        empModel.LastName = value.ToString();
                                        count++;
                                        break;
                                    }
                                case 3:
                                    {

                                        DateTime d = (DateTime)value;


                                        var D = d.Day;
                                        string? dt;
                                        if (D < 10)
                                        {
                                            dt = "0" + D.ToString();
                                        }
                                        else { dt = D.ToString(); }

                                        String mm = d.ToString("MMM");
                                        var y = d.Year;

                                        string finalDate = dt + "-" + mm + "-" + y.ToString();

                                        empModel.DOB = finalDate;
                                        count++;
                                        break;
                                    }
                                case 4:
                                    {
                                        empModel.Gender = value.ToString();
                                        count++;
                                        break;
                                    }
                                case 5:
                                    {
                                        var id = (Int32)value;

                                        var dept = context.departments.Where(x => x.DepartmentId == id).Single();
                                        empModel.DepartmentName = dept.DepartmentName;

                                        count++;
                                        break;
                                    }
                                case 6:
                                    {

                                        var id = (Int32)value;

                                        var desg = context.designations.Where(x => x.DesignationId == id).Single();
                                        empModel.DesignationName = desg.DesignationName;
                                        count++;
                                        break;
                                    }
                                case 7:
                                    {
                                        DateTime d = (DateTime)value;


                                        var D = d.Day;
                                        string? dt;
                                        if (D < 10)
                                        {
                                            dt = "0" + D.ToString();
                                        }
                                        else { dt = D.ToString(); }

                                        String mm = d.ToString("MMM");
                                        var y = d.Year;

                                        string finalDate = dt + "-" + mm + "-" + y.ToString();

                                        empModel.DOJ = finalDate;
                                        count++;
                                        break;
                                    }
                                case 8:
                                    {
                                        empModel.Salary = (Int32)value;
                                        count++;
                                        break;
                                    }
                                default:
                                    {
                                        string? v = value.ToString();
                                        string? str = v;
                                        str = str?.Remove(str.Length - 1, 1);
                                        empModel.skillConcat = str;

                                    }
                                    //empModel.EmployeeSkills = skillList;
                                    count++;
                                    break;
                            }


                        };

                        empMod.Add(empModel);
                    }

                    //EmployeePerson employeePerson = new EmployeePerson();





                    emp.EmpModelyoo1 = empMod;

                    //var mod = JsonConvert.SerializeObject(empMod);
                    HttpContext.Session.SetString("queryList", JsonConvert.SerializeObject(emp));
                    if (firstName != null)
                    {
                        HttpContext.Session.SetString("firstName", firstName);
                        employeePerson.FirstName = firstName;
                    }
                    if (lastName != null)
                    {
                        HttpContext.Session.SetString("lastName", lastName);
                        employeePerson.LastName = lastName;

                    }
                    if (gen != null)
                    {
                        HttpContext.Session.SetString("gen", gen);
                        employeePerson.Gender = gen;
                    }
                    if (depId != null)
                    {
                        HttpContext.Session.SetString("depId", depId.ToString());
                        emp.DepartmentId = depId;
                    }
                    if (desgId != null)
                    {
                        HttpContext.Session.SetString("desgId", desgId.ToString());
                        emp.DesignationId = desgId;
                    }

                    emp.EmployeePerson = employeePerson;

                    return View("Index", emp);




                }



                if (depId != 0)
                {

                    if (quer == null)
                    {
                        quer = queryy + $"  e.DepartmentId={depId}  ";
                    }
                    else
                    {
                        quer = quer + $" AND e.DepartmentId={depId}   ";
                    }



                }
                if (desgId != 0)
                {
                    if (quer == null)
                    {
                        quer = queryy + $" e.DesignationId={desgId}  ";
                    }
                    else
                    {
                        quer = quer + $" AND e.DesignationId={desgId}  ";
                    }
                }
                if (gen != null)
                {
                    if (quer == null)
                    {
                        quer = queryy + $"  e.Gender='{gen}'  ";
                    }
                    else
                    {
                        quer = quer + $" AND e.Gender='{gen}'  ";
                    }
                }
                if (firstName != null)
                {
                    if (quer == null)
                    {

                        quer = queryy + $"  e.FirstName like '%{firstName}%'  ";
                    }
                    else
                    {
                        quer = quer + $" AND e.FirstName like '%{firstName}%'  ";
                    }

                }
                if (lastName != null)
                {
                    if (quer == null)
                    {
                        quer = queryy + $"  e.Lastname like'%{lastName}%'  ";
                    }
                    else
                    {
                        quer = quer + $" AND e.LastName like '%{lastName}%'  ";
                    }
                }

                quer = quer + ") as e";
                skii = context.skills.ToList();
                Dept = context.departments.ToList();
                Desg = context.designations.ToList();



                emp.Department = Dept;
                emp.Skill = skii;
                emp.Designation = Desg;
                int s;
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {

                    command.CommandText = $"{quer}";
                    context.Database.OpenConnection();
                    s = quer.Length;
                    if (s > 6)
                    {
                        using (var result = command.ExecuteReader())
                        {



                            while (result.Read())
                            {
                                object[] values = new object[result.FieldCount];
                                result.GetValues(values);
                                em2.Add(values);
                            }

                        }
                    }



                }


                foreach (object[] item in em2)
                {
                    EmpModelyoo1 empModel = new EmpModelyoo1();
                    int count = 0;
                    foreach (object value in item)
                    {
                        switch (count)
                        {
                            case 0:
                                {
                                    empModel.EmployeePersonId = (Int32)value;
                                    count++;
                                    break;
                                }
                            case 1:
                                {
                                    empModel.FirstName = value.ToString();
                                    count++;
                                    break;
                                }
                            case 2:
                                {
                                    empModel.LastName = value.ToString();
                                    count++;
                                    break;
                                }
                            case 3:
                                {
                                    DateTime d = (DateTime)value;


                                    var D = d.Day;
                                    string? dt;
                                    if (D < 10)
                                    {
                                        dt = "0" + D.ToString();
                                    }
                                    else { dt = D.ToString(); }

                                    String mm = d.ToString("MMM");
                                    var y = d.Year;

                                    string finalDate = dt + "-" + mm + "-" + y.ToString();

                                    empModel.DOB = finalDate;
                                    count++;
                                    break;
                                }
                            case 4:
                                {
                                    empModel.Gender = value.ToString();
                                    count++;
                                    break;
                                }
                            case 5:
                                {
                                    var id = (Int32)value;

                                    var dept = context.departments.Where(x => x.DepartmentId == id).Single();
                                    empModel.DepartmentName = dept.DepartmentName;

                                    count++;
                                    break;
                                }
                            case 6:
                                {

                                    var id = (Int32)value;

                                    var desg = context.designations.Where(x => x.DesignationId == id).Single();
                                    empModel.DesignationName = desg.DesignationName;
                                    count++;
                                    break;
                                }
                            case 7:
                                {
                                    DateTime d = (DateTime)value;


                                    var D = d.Day;
                                    string? dt;
                                    if (D < 10)
                                    {
                                        dt = "0" + D.ToString();
                                    }
                                    else { dt = D.ToString(); }

                                    String mm = d.ToString("MMM");
                                    var y = d.Year;

                                    string finalDate = dt + "-" + mm + "-" + y.ToString();

                                    empModel.DOJ = finalDate;
                                    count++;
                                    break;
                                }
                            case 8:
                                {
                                    empModel.Salary = (Int32)value;
                                    count++;
                                    break;
                                }
                            default:
                                {
                                    string? v = value.ToString();
                                    string? str = v;
                                    str = str?.Remove(str.Length - 1, 1);
                                    empModel.skillConcat = str;



                                }
                                //empModel.EmployeeSkills = skillList;
                                count++;
                                break;
                        }


                    };


                    empMod.Add(empModel);
                }



            }




            // EmployeePerson employeePerson = new EmployeePerson();





            emp.EmpModelyoo1 = empMod;

            //var mod = JsonConvert.SerializeObject(empMod);
            // HttpContext.Session.SetString("queryList", JsonConvert.SerializeObject(emp));
            HttpContext.Session.SetString("queryList", JsonConvert.SerializeObject(empMod));

            if (firstName != null)
            {
                HttpContext.Session.SetString("firstName", firstName);
                employeePerson.FirstName = firstName;
            }
            if (lastName != null)
            {
                HttpContext.Session.SetString("lastName", lastName);
                employeePerson.LastName = lastName;

            }
            if (gen != null)
            {
                HttpContext.Session.SetString("gen", gen);
                employeePerson.Gender = gen;
            }
            if (depId != null)
            {
                HttpContext.Session.SetString("depId", depId.ToString());
                emp.DepartmentId = depId;
            }
            if (desgId != null)
            {
                HttpContext.Session.SetString("desgId", desgId.ToString());
                emp.DesignationId = desgId;
            }

            emp.EmployeePerson = employeePerson;

            return View("Index", emp);



        }
*/






        public IActionResult ViewEmp(int empId, string prenex, int last) {

            var lastList = HttpContext.Session.GetString("queryList");

            List<EmpModelyoo1>? list1 = new List<EmpModelyoo1>();

            if (lastList != null)
            {
                var newList = JsonConvert.DeserializeObject<List<EmpModelyoo1>>(lastList);
                if(newList != null)
                {
                    list1 = newList;
                }
                
            }

            EmpModelyoo1 emp = new EmpModelyoo1();
            int current = -1;
            if (last != 0 && prenex == "prev" && (last - 1) > -1)
            {
                current = last - 1;
                if (list1 != null)
                {
                    emp = list1[current];
                }
            } else if (prenex == "prev" && last == 0)
            { if (list1 != null)
                {
                    current = list1.Count - 1;
                    emp = list1[current];
                }

            }
            int limit = -1;
            if (list1 != null)
            {
                limit = list1.Count;
            }


            if ((last == 0 && prenex == "next" && (last + 1) < limit) || (last != 0 && prenex == "next" && (last + 1) < limit))
            {
                current = last + 1;
                if (list1 != null)
                {
                    emp = list1[current];
                }
            }
            else if (prenex == "next" && last + 1 == limit)
            {
                if (list1 != null)
                {
                    current = 0;
                    emp = list1[current];
                }

            }


            if (list1 != null && empId != 0)
            {
                current = list1.FindIndex(a => a.EmployeePersonId == empId);
                emp = list1[current];
            }


            string[] sklList = emp.skillConcat?.Split(",");
            List<string> skillList = new List<string>();
            if (sklList != null)
            {
                foreach (var skl in sklList)
                {

                    skillList.Add(skl);

                }
            }

            emp.Skills = skillList;
            emp.Index = current;
            var ski = new List<Skill>();
            using (var context = new EmployeeContext())
            {
                ski = context.skills.ToList();
            }

            ViewBag.Skill = ski;
            // var mod = JsonConvert.SerializeObject(emp);
            ///////////////////////////////////////////////////////////////////////////////////////////








            /////////////////////////////////////////////////////////////////////////////////////////////
            return View(emp);
        }



        public IActionResult Back()
        {
            var lastList = HttpContext.Session.GetString("queryList");
            var firstName = HttpContext.Session.GetString("firstName");
            var lastName = HttpContext.Session.GetString("lastName");
            var gen = HttpContext.Session.GetString("gen");
            var depId = Convert.ToInt32(HttpContext.Session.GetString("depId"));
            var desgId = Convert.ToInt32(HttpContext.Session.GetString("desgId"));

            EmpDepDesSki emp = new EmpDepDesSki();
            List<EmpModelyoo1> empY=new List<EmpModelyoo1>();


            if (lastList != null)
            {
                var newList = JsonConvert.DeserializeObject<List<EmpModelyoo1>>(lastList);
                if (newList != null)
                {
                    empY = newList;
                }

            }
            emp.EmpModelyoo1= empY;
            EmployeePerson employeePerson = new EmployeePerson();
            employeePerson.FirstName = firstName;
            employeePerson.LastName = lastName;
            employeePerson.Gender = gen;
            if (depId != 0)
            {
                emp.DepartmentId = depId;
            }

            if (desgId != 0)
            {
                int desId = desgId;
                emp.DesignationId = desId;
            }
            var skii = new List<Skill>();
            var Dept = new List<Department>();
            var Desg = new List<Designation>();
            using (var context=new EmployeeContext())
            {
                skii = context.skills.ToList();
                Dept = context.departments.ToList();
                Desg = context.designations.ToList();


                emp.Department = Dept;
                emp.Skill = skii;
                emp.Designation = Desg;
            }


            emp.EmployeePerson = employeePerson;
            return View("Index", emp);


        }



        [HttpPost]
        public IActionResult Search(EmpDepDesSki empDepDesSki, string Gender)
        {
            EmpDepDesSki emp = new EmpDepDesSki();
            List<EmpModelyoo1> empMod = new List<EmpModelyoo1>();
            var skii = new List<Skill>();
            var Dept = new List<Department>();
            var Desg = new List<Designation>();
            EmployeePerson employeePerson = new EmployeePerson();
            int depId = 0; 
            if (empDepDesSki.DepartmentId != null)
            {
                 depId = (int)empDepDesSki.DepartmentId;
            }
            int desgId=0;
           if(empDepDesSki.DesignationId!=null) {
                desgId = (int)empDepDesSki.DesignationId;
            }
            
            string gen = Gender == null ? null : Gender;
            string firstName = empDepDesSki.EmployeePerson.FirstName == null ? null : empDepDesSki.EmployeePerson.FirstName;
            string lastName = empDepDesSki.EmployeePerson.LastName == null ? null : empDepDesSki.EmployeePerson.LastName;
           

            using (var context = new EmployeeContext())
            {

                skii = context.skills.ToList();
                Dept = context.departments.ToList();
                Desg = context.designations.ToList();


                emp.Department = Dept;
                emp.Skill = skii;
                emp.Designation = Desg;
               List< EmployeePerson> emp0=new List<EmployeePerson>();
                List<EmployeePerson> emp1 = new List<EmployeePerson>();
                List<EmployeePerson> emp2 = new List<EmployeePerson>();
                List<EmployeePerson> emp3 = new List<EmployeePerson>();
                List<EmployeePerson> emp4 = new List<EmployeePerson>();
                List<EmployeePerson> emp5 = new List<EmployeePerson>();


                List<EmployeePerson> empl = context.employeePersons.Include(s => s.Department).Include(s => s.Designation).Include(s => s.EmployeeSkills).ThenInclude(s => s.Skill).ToList();
              
                    if (depId != 0)
                    {
                        emp0 = empl.Where(s => s.DepartmentId == depId).ToList();
                        emp5 = emp5.Union(emp0).ToList();
                     
                    }
                    if (desgId != 0)
                    {
                         emp1 = empl.Where(s => s.DesignationId == desgId).ToList();
                        emp5 = emp5.Union(emp1).ToList();
                    /*  if(emp0 != null)
                     {
                     emp5 = emp0.Union(emp1).ToList();
                      }
                     else { emp5 = emp1; }*/

                }
                    if (gen != null)
                    {
                        emp2 = empl.Where(s => s.Gender.Contains(gen)).ToList();
                         emp5 = emp5.Union(emp2).ToList();
                    /* if(emp0!=null && emp1 == null) 
                      {
                       emp5=emp0.Union(emp2).ToList();
                      }else if(emp1!=null && emp0!=null)
                      {
                         emp5=emp5.Union(emp2).ToList();
                      }*/
                }    
                    if (firstName != null)
                    {
                    // empl = empl.Where(s => s.FirstName.Contains(firstName)).ToList();
                       emp3 = empl.Where(s => s.FirstName.ToUpper().Contains(firstName.ToUpper())).ToList();
                        emp5 = emp5.Union(emp3).ToList();


                }
                if (lastName != null)
                    {
                        emp4 = empl.Where(s => s.LastName.ToUpper().Contains(lastName.ToUpper())).ToList();
                        emp5 = emp5.Union(emp4).ToList();

                }
                if(emp5.Count>0)
                {
                    empl = emp5;
                }
                
                
                foreach(var em in empl)
                {
                    EmpModelyoo1 empM=new EmpModelyoo1();
                    empM.EmployeePersonId = em.EmployeePersonId;
                    empM.FirstName = em.FirstName;
                    empM.LastName= em.LastName;
                    empM.Gender= em.Gender;
                    empM.Salary= em.Salary;
                    empM.DepartmentName = em.Department.DepartmentName;
                    empM.DesignationName= em.Designation.DesignationName;
                    var d = em.DOB;
                    var D = d.Day;
                    string? dt;
                    if (D < 10)
                    {
                        dt = "0" + D.ToString();
                    }
                    else { dt = D.ToString(); }

                    String mm = d.ToString("MMM");
                    var y = d.Year;

                    string finalDate = dt + "-" + mm + "-" + y.ToString();

                    empM.DOB = finalDate;


                    var e = em.DOJ;
                    var f = e.Day;
                    string? dte;
                    if (f < 10)
                    {
                        dte = "0" + f.ToString();
                    }
                    else { dte = f.ToString(); }

                    String mmm = d.ToString("MMM");
                    var yy = d.Year;

                    string finalDatee = dte + "-" + mmm + "-" + yy.ToString();

                    empM.DOJ = finalDatee;

                    string s = null;
                    int i = 0;
                    foreach(var skill in em.EmployeeSkills)
                    {   if (i == 0)
                        {
                            s = skill.Skill.SkillName;
                                i=i+1;
                        }
                        else
                        {
                            s = s +","+ skill.Skill.SkillName;
                        }
                        
                    }

                    empM.skillConcat = s;

                    empMod.Add(empM);

                }

            }

            emp.EmpModelyoo1 = empMod;
            HttpContext.Session.Clear();
            HttpContext.Session.SetString("queryList", JsonConvert.SerializeObject(empMod));
            if (firstName != null)
            {
                HttpContext.Session.SetString("firstName", firstName);
                employeePerson.FirstName = firstName;
            }
            if (lastName != null)
            {
                HttpContext.Session.SetString("lastName", lastName);
                employeePerson.LastName = lastName;

            }
            if (gen != null)
            {
                HttpContext.Session.SetString("gen", gen);
                employeePerson.Gender = gen;
            }
            if (depId != 0)
            {
                HttpContext.Session.SetString("depId", depId.ToString());
                emp.DepartmentId = depId;
            }
            if (desgId != 0)
            {
                HttpContext.Session.SetString("desgId", desgId.ToString());
                emp.DesignationId = desgId;
            }

            emp.EmployeePerson = employeePerson;






            return View("Index",emp);



        }

        [HttpPost]
        public IActionResult ExactSearch(EmpDepDesSki empDepDesSki, string Gender)
        {
            EmpDepDesSki emp = new EmpDepDesSki();
            List<EmpModelyoo1> empMod = new List<EmpModelyoo1>();
            var skii = new List<Skill>();
            var Dept = new List<Department>();
            var Desg = new List<Designation>();
            EmployeePerson employeePerson = new EmployeePerson();

            /*int depId = empDepDesSki.DepartmentId == 0 ? 0 : empDepDesSki.DepartmentId;
            int desgId = empDepDesSki.DesignationId == 0 ? 0 : empDepDesSki.DesignationId;
            string gen = Gender == null ? null : Gender;
            string firstName = empDepDesSki.EmployeePerson.FirstName == null ? null : empDepDesSki.EmployeePerson.FirstName;
            string lastName = empDepDesSki.EmployeePerson.LastName == null ? null : empDepDesSki.EmployeePerson.LastName;*/



            using (var context = new EmployeeContext())
            {

                skii = context.skills.ToList();
                Dept = context.departments.ToList();
                Desg = context.designations.ToList();


                emp.Department = Dept;
                emp.Skill = skii;
                emp.Designation = Desg;

                var res = context.SearchModel.FromSqlInterpolated($"EXEC SearchedBy {empDepDesSki.EmployeePerson.FirstName}, {empDepDesSki.EmployeePerson.LastName}, {Gender}, {(empDepDesSki.DesignationId ?? (object)DBNull.Value)}, {(empDepDesSki.DepartmentId ?? (object)DBNull.Value)}").AsNoTracking().ToList();

                foreach( var val in res)
                {
                    EmpModelyoo1 em = new EmpModelyoo1();
                    em.EmployeePersonId = val.EmployeePersonId;
                    em.FirstName=val.FirstName;
                    em.LastName = val.LastName;
                    em.Gender=val.Gender;
                    em.skillConcat=val.skillConcat;
                    em.Salary=val.Salary;
                   
                    var dep = context.departments.Where(c => c.DepartmentId == val.DepartmentId).Single();
                    em.DepartmentName = dep.DepartmentName;
                    var des=context.designations.Where(c=>c.DesignationId==val.DesignationId).Single();
                    em.DesignationName = des.DesignationName;


                    var d = val.DOB;
                    var D = d.Day;
                    string? dt;
                    if (D < 10)
                    {
                        dt = "0" + D.ToString();
                    }
                    else { dt = D.ToString(); }

                    String mm = d.ToString("MMM");
                    var y = d.Year;

                    string finalDate = dt + "-" + mm + "-" + y.ToString();

                    em.DOB = finalDate;


                    var e = val.DOJ;
                    var f = e.Day;
                    string? dte;
                    if (f < 10)
                    {
                        dte = "0" + f.ToString();
                    }
                    else { dte = f.ToString(); }

                    String mmm = d.ToString("MMM");
                    var yy = d.Year;

                    string finalDatee = dte + "-" + mmm + "-" + yy.ToString();

                    em.DOJ = finalDatee;


                    empMod.Add(em);

                }



            }

            emp.EmpModelyoo1 = empMod;
            HttpContext.Session.Clear();

            HttpContext.Session.SetString("queryList", JsonConvert.SerializeObject(empMod));
            if (empDepDesSki.EmployeePerson.FirstName != null)
            {
                HttpContext.Session.SetString("firstName", empDepDesSki.EmployeePerson.FirstName);
                employeePerson.FirstName = empDepDesSki.EmployeePerson.FirstName;
            }
            if (empDepDesSki.EmployeePerson.LastName != null)
            {
                HttpContext.Session.SetString("lastName", empDepDesSki.EmployeePerson.LastName);
                employeePerson.LastName = empDepDesSki.EmployeePerson.LastName;

            }
            if (Gender != null)
            {
                HttpContext.Session.SetString("gen", Gender);
                employeePerson.Gender = Gender;
            }
            if (int.TryParse(empDepDesSki.DepartmentId.ToString(), out int result))
            {
                HttpContext.Session.SetString("depId", result.ToString());
                emp.DepartmentId = Convert.ToInt32(empDepDesSki.EmployeePerson.DepartmentId);
            }
          /*  if (empDepDesSki.EmployeePerson.DepartmentId != 0)
            {
                HttpContext.Session.SetString("depId", empDepDesSki.EmployeePerson.DepartmentId.ToString());
                emp.DepartmentId = Convert.ToInt32(empDepDesSki.EmployeePerson.DepartmentId);
            }*/

          /*  if (empDepDesSki.EmployeePerson.DesignationId != 0)
            {
                HttpContext.Session.SetString("desgId", empDepDesSki.EmployeePerson.DesignationId.ToString());
                emp.DesignationId = Convert.ToInt32(empDepDesSki.EmployeePerson.DesignationId);
            }*/

            if (int.TryParse(empDepDesSki.DesignationId.ToString(), out int resul))
            {
                HttpContext.Session.SetString("desgId", resul.ToString());
                emp.DesignationId = Convert.ToInt32(empDepDesSki.DesignationId);
            }

            emp.EmployeePerson = employeePerson;






            return View("Index", emp);



        }
    }

           


        }






            




