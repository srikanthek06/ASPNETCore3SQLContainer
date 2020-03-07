using System.Collections.Generic;
using System.Linq;
using HealthAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HealthAPI.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<HealthContext>();
                context.Database.EnsureCreated();

                if (context.Ailments != null && context.Ailments.Any())
                    return;

                var ailments = DummyData.GetAilments().ToArray();
                context.Ailments.AddRange(ailments);
                context.SaveChanges();

                var medications = DummyData.GetMedications().ToArray();
                context.Medications.AddRange(medications);
                context.SaveChanges();

                var patients = DummyData.GetPatients(context).ToArray();
                context.Patients.AddRange(patients);
                context.SaveChanges();
            }
        }

        public static List<Ailment> GetAilments()
        {
            List<Ailment> ailments = new List<Ailment>()
            {
                new Ailment{Name="Head Ache"},
                new Ailment{Name="Stomach Pain"},
                new Ailment{Name="Fever"},
                new Ailment{Name="Cold"},
                new Ailment{Name="Allergy"}
            };
            return ailments;
        }

        public static List<Medication> GetMedications()
        {
            List<Medication> medications = new List<Medication>()
            {
                new Medication{Name="Tylenol", Doses="2"},
                new Medication{Name="Aspirin", Doses="4"},
                new Medication{Name="Advil", Doses="3"},
                new Medication{Name="Robaxin", Doses="2"},
                new Medication{Name="Voltaren", Doses="1"}
            };
            return medications;
        }

        public static List<Patient> GetPatients(HealthContext dbContext)
        {
            List<Patient> patients = new List<Patient>()
            {
                new Patient{Name="Allan Border"
                    , Ailments=new List<Ailment>(dbContext.Ailments.Take(2))
                    , Medications=new List<Medication>(dbContext.Medications.Take(2))},
                new Patient{Name="Tom Cruse"
                    , Ailments=new List<Ailment>(dbContext.Ailments.Take(1))
                    , Medications=new List<Medication>(dbContext.Medications.Take(2))},
                new Patient{Name="Steve Smith"
                    , Ailments=new List<Ailment>(dbContext.Ailments.Skip(2).Take(1))
                    , Medications=new List<Medication>(dbContext.Medications.Take(2))}
            };
            return patients;
        }
    }
}