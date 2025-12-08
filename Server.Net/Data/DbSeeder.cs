using Microsoft.AspNetCore.Identity;
using Server.Net.Models.System;
using Server.Net.Models.Reference;

namespace Server.Net.Data;

public static class DbSeeder
{
    public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
    {
        //Seed Roles
        var userManager = service.GetService<UserManager<ApplicationUser>>();
        var roleManager = service.GetService<RoleManager<IdentityRole>>();

        if (roleManager == null || userManager == null)
            return;

        await roleManager.CreateAsync(new IdentityRole("Admin"));
        await roleManager.CreateAsync(new IdentityRole("User"));

        // Creating Admin User
        var user = new ApplicationUser
        {
            UserName = "admin@gmail.com",
            Email = "admin@gmail.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
        var userInDb = await userManager.FindByEmailAsync(user.Email);
        if (userInDb == null)
        {
            await userManager.CreateAsync(user, "Admin@123");
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
    public static async Task SeedReferenceDataAsync(ApplicationDbContext context)
    {
        // Seed Specialites
        if (!context.Specialites.Any())
        {
            var items = new List<Specialite>
            {
                new Specialite("Anesthésie", "Anesth", 1),
                new Specialite("Chirurgie Générale", "Chir Gen", 2),
                new Specialite("Cardiologie", "Cardio", 3),
                new Specialite("Pédiatrie", "Ped", 4),
                new Specialite("Urgence", "Urg", 5),
                new Specialite("Orthopédie", "Ortho", 6),
                new Specialite("Gynécologie", "Gynéco", 7),
                new Specialite("Neurochirurgie", "Neuro", 8)
            };
            
            foreach(var item in items) { item.Description = item.Label; }
            context.Specialites.AddRange(items);
            await context.SaveChangesAsync();
        }

        // Seed TypesAnesthesies
        if (!context.TypesAnesthesies.Any())
        {
            var items = new List<TypeAnesthesie>
            {
                new TypeAnesthesie("Anesthésie Générale", "AG", 1),
                new TypeAnesthesie("Anesthésie Locorégionale", "ALR", 2),
                new TypeAnesthesie("Sédation", "Sed", 3),
                new TypeAnesthesie("Rachianesthésie", "Rachi", 4),
                new TypeAnesthesie("Péridurale", "APD", 5),
                new TypeAnesthesie("Bloc Nerveux", "Bloc", 6)
            };
            
            foreach(var item in items) { item.Description = item.Label; }
            context.TypesAnesthesies.AddRange(items);
            await context.SaveChangesAsync();
        }

        // Seed GradesScientifiques
        if (!context.GradesScientifiques.Any())
        {
            var items = new List<GradeScientifique>
            {
                new GradeScientifique("Professeur", "Pr", 1),
                new GradeScientifique("Maître de Conférence A", "MCA", 2),
                new GradeScientifique("Maître de Conférence B", "MCB", 3),
                new GradeScientifique("Assistant", "Ass", 4),
                new GradeScientifique("Spécialiste", "Spec", 5),
                new GradeScientifique("Résident", "Res", 6),
                new GradeScientifique("Médecin Généraliste", "MG", 7)
            };
            
            foreach(var item in items) { item.Description = item.Label; }
            context.GradesScientifiques.AddRange(items);
            await context.SaveChangesAsync();
        }

        // Seed Respirateurs
        if (!context.Respirateurs.Any())
        {
            var items = new List<Respirateur>
            {
                new Respirateur("Dräger Zeus", "Zeus", 1),
                new Respirateur("GE Avance CS2", "Avance", 2),
                new Respirateur("Maquet Flow-i", "Flow-i", 3),
                new Respirateur("Mindray A7", "A7", 4),
                new Respirateur("Datex-Ohmeda", "Datex", 5),
                new Respirateur("Léon Plus", "Léon", 6)
            };
            
            foreach(var item in items) { item.Description = item.Label; }
            context.Respirateurs.AddRange(items);
            await context.SaveChangesAsync();
        }

        // Seed Agents (Anesthésiques)
        if (!context.Agents.Any())
        {
            var items = new List<Agent>
            {
                // Hypnotiques
                new Agent("Propofol", "Propofol", 1),
                new Agent("Etomidate", "Etomidate", 2),
                new Agent("Ketamine", "Ketamine", 3),
                new Agent("Thiopental", "Penthotal", 4),
                
                // Opioides
                new Agent("Fentanyl", "Fenta", 5),
                new Agent("Sufentanil", "Sufenta", 6),
                new Agent("Remifentanil", "Remi", 7),
                new Agent("Morphine", "Morphine", 8),
                
                // Curares
                new Agent("Rocuronium", "Esmeron", 9),
                new Agent("Cisatracurium", "Nimbex", 10),
                new Agent("Succinylcholine", "Celocurine", 11),
                
                // Halogenes
                new Agent("Sevoflurane", "Sevo", 12),
                new Agent("Desflurane", "Des", 13),
                new Agent("Isoflurane", "Iso", 14),
                
                // Vasopresseurs
                new Agent("Ephedrine", "Ephedrine", 15),
                new Agent("Phenylephrine", "Phenylephrine", 16),
                new Agent("Noradrenaline", "Noradre", 17),
                new Agent("Atropine", "Atropine", 18)
            };
            
            foreach(var item in items) { item.Description = item.Label; }
            context.Agents.AddRange(items);
            await context.SaveChangesAsync();
        }
    }
}
