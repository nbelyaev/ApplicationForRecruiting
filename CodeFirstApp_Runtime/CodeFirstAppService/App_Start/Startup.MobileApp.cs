using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using CodeFirstAppService.DataObjects;
using CodeFirstAppService.Models;
using Owin;

namespace CodeFirstAppService
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new CodeFirstAppInitializer());

            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer<CodeFirstAppContext>(null);

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }
            app.UseWebApi(config);
        }
    }

    public class CodeFirstAppInitializer : CreateDatabaseIfNotExists<CodeFirstAppContext>
    {
        protected override void Seed(CodeFirstAppContext context)
        {
            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
            };


            foreach (TodoItem todoItem in todoItems) {
                context.Set<TodoItem>().Add(todoItem);
            }

            List<Position> positons = new List<Position>
            {
                new Position { Id = Guid.NewGuid().ToString(), Name = "First position", Description="seeded" },
                new Position { Id = Guid.NewGuid().ToString(), Name = "Second position", Description="seeded" },
                new Position { Id = Guid.NewGuid().ToString(), Name = "Third position", Description="seeded" },
            };

            foreach (Position position in positons) {
                context.Set<Position>().Add(position);
            }



            
            List<Candidate> Candidates = new List<Candidate>
            {
                new Candidate { Id = Guid.NewGuid().ToString(), city="Chicago", candidateInfoNotes="ok candidate",
                    clearedBackgroundComments ="spoopy", firstName="Eric", lastName="Ruelas" },
                new Candidate { Id = Guid.NewGuid().ToString(), city="Chicago", candidateInfoNotes="ok candidate",
                    clearedBackgroundComments ="spoopy", firstName="Cristian", lastName="Pintedo" }, 
            };

            foreach (Candidate Candidate in Candidates) {
                context.Set<Candidate>().Add(Candidate);
            }

            

            List<Interview> Interviews = new List<Interview>
            {
                new Interview { Id = Guid.NewGuid().ToString(), InterviewCandidate=Candidates[0],
                    InterviewComments ="it was ok", InterviewRating=3.2, InterviewDateOfInterview=DateTime.Now },
            };

            foreach (Interview Interview in Interviews) {
                context.Set<Interview>().Add(Interview);
            }

            List<Role> Roles = new List<Role>
            {
                new Role { Id = Guid.NewGuid().ToString(), RoleName="Recruiter" },
                new Role { Id = Guid.NewGuid().ToString(), RoleName="HR" },
                new Role { Id = Guid.NewGuid().ToString(), RoleName="Other" },
            };

            foreach (Role Role in Roles) {
                context.Set<Role>().Add(Role);
            }

            List<Skill> Skills = new List<Skill>
            {
                new Skill { Id = Guid.NewGuid().ToString(), SkillName="Reading" },
                new Skill { Id = Guid.NewGuid().ToString(), SkillName=".Net" },
                new Skill { Id = Guid.NewGuid().ToString(), SkillName="Fencing" },
                new Skill { Id = Guid.NewGuid().ToString(), SkillName="Database Administration" },
            };

            foreach (Skill Skill in Skills) {
                context.Set<Skill>().Add(Skill);
            }


            List<Source> Sources = new List<Source>
            {
                new Source { Id = Guid.NewGuid().ToString(), SourceName="Careerbuilder.com"},
                new Source { Id = Guid.NewGuid().ToString(), SourceName="Monster.com"},
                new Source { Id = Guid.NewGuid().ToString(), SourceName="LinkedIn"},
                new Source { Id = Guid.NewGuid().ToString(), SourceName="Referral"},
            };

            foreach (Source Source in Sources) {
                context.Set<Source>().Add(Source);
            }




            List<State> States = new List<State>
            {
                new State { Id = Guid.NewGuid().ToString(), StateAbbreviation="IL"},

                new State { Id = Guid.NewGuid().ToString(), StateAbbreviation="AL"},
                new State { Id = Guid.NewGuid().ToString(), StateAbbreviation="NY"},
            };

            foreach (State State in States) {
                context.Set<State>().Add(State);
            }



            List<Status> Statuss = new List<Status>
            {
                new Status { Id = Guid.NewGuid().ToString(), StatusName="Awaiting Approval"},

                new Status { Id = Guid.NewGuid().ToString(), StatusName="Denied"},
                new Status { Id = Guid.NewGuid().ToString(), StatusName="Hired"},
                new Status { Id = Guid.NewGuid().ToString(), StatusName="Not Ready - contact later"},
            };

            foreach (Status Status in Statuss) {
                context.Set<Status>().Add(Status);
            }



            List<InterviewType> Types = new List<InterviewType>
            {
                new InterviewType { Id = Guid.NewGuid().ToString(), TypeName="Phone"},
                new InterviewType { Id = Guid.NewGuid().ToString(), TypeName="F2F"},
                new InterviewType { Id = Guid.NewGuid().ToString(), TypeName="Tech"},
                new InterviewType { Id = Guid.NewGuid().ToString(), TypeName="PhoneTech"},
            };

            foreach (InterviewType Type in Types) {
                context.Set<InterviewType>().Add(Type);
            }



            List<User> Users = new List<User>
            {
                new User { Id = Guid.NewGuid().ToString(), UserFirstName="Amanda", UserLastName="Hess"},
                new User { Id = Guid.NewGuid().ToString(), UserFirstName="Reginald", UserLastName="Miller"},
                new User { Id = Guid.NewGuid().ToString(), UserFirstName="Richard", UserLastName="Kimbel"},
            };

            foreach (User User in Users) {
                context.Set<User>().Add(User);
            }



            base.Seed(context);
        }
    }
}

