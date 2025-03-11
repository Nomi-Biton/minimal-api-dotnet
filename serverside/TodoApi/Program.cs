using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Editing;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyModel;
using MySqlConnector;
using TodoApi;

    //בניית שירות ה api
    var builder = WebApplication.CreateBuilder(args);
    //הוספת  Services
    builder.Services.AddControllers();
    
    //swagger
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    //connectionString
    var connectionString="Server=localhost;user=root;password=NomiBiton1!;database=`app_78nwc04l`";
    // שנטען מהm ysql    DbContext  הוספה לשירות עצם מסוג 
    builder.Services.AddDbContext<ToDoDbContext>(option=>option.UseMySql(
        connectionString,ServerVersion.AutoDetect(connectionString)
    ));
    //cors
    builder.Services.AddCors(opt=>{
        opt.AddDefaultPolicy(PolicyBuilder=>
        {
            //מדיניות הרשאות 
            PolicyBuilder.WithOrigins("http://localhost:3000")
                .AllowAnyHeader() 
                .AllowAnyMethod();
                   
                   
        });
    });
    

    
   //הבניה והשימוש ממש
    var app = builder.Build();
     app.UseCors();
     app.UseSwagger();
     app.UseSwaggerUI();

    app.MapGet("/", () => "m");
    //הצגת כל המשימות
    // app.MapGet("/getAll",([FromServices] ToDoDbContext t)=>t.Items);
    // //הוספת משימה
    // app.MapPost("/add/{name}", (string name,[FromServices]ToDoDbContext t)=>{
    // var it = new Item
    // {
    //     Name = name,
    //     IsComplete = false
    // };
       
    // t.Items.AddAsync(it);
    // t.SaveChanges();

       
    // return ;
        
    // });
    // //עדכון משימה
    // app.MapPut("/update/{id}/{isC}",(int id,bool isC ,[FromServices]ToDoDbContext t)=>{
          
    // foreach (var ii in t.Items)
    // {
    //     if(ii.Id==id){
    //         ii.IsComplete=isC;
    //     }
    // }
    // t.SaveChanges();      
        
    
    // });
    // //מחיקת משימה מהמערכת
    // app.MapDelete("/del/{id}",([FromServices]ToDoDbContext t,int id)=>
    // {
    //     bool flag=false;

    // foreach (var ii in t.Items)
    // {
    //     if(ii.Id==id)
    // {
    //         flag=true;

    // t.Items.Remove(ii);
    
    // }
    // } 
    // if(flag==true){ 
    //     t.SaveChanges();
    //     return Results.Ok(t.Items);
    //     }
    // else
    // {
    //     return Results.NotFound();} 

        
    // }


    // );

//הרצה
app.Run();
   