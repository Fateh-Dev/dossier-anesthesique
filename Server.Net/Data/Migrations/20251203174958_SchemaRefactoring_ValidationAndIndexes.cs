using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Net.Data.Migrations
{
    /// <inheritdoc />
    public partial class SchemaRefactoring_ValidationAndIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Abreviation = table.Column<string>(type: "TEXT", nullable: false),
                    Label = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserIds = table.Column<int>(type: "INTEGER", nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: false),
                    DataTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    NotificationName = table.Column<string>(type: "TEXT", nullable: false),
                    Distination = table.Column<string>(type: "TEXT", nullable: false),
                    Payload = table.Column<string>(type: "TEXT", nullable: false),
                    ExcludedUserIds = table.Column<string>(type: "TEXT", nullable: false),
                    EntityTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    Read = table.Column<bool>(type: "INTEGER", nullable: false),
                    Severity = table.Column<int>(type: "INTEGER", nullable: false),
                    EntityId = table.Column<Guid>(type: "TEXT", nullable: true),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AppName = table.Column<string>(type: "TEXT", nullable: false),
                    IdUnite = table.Column<Guid>(type: "TEXT", nullable: true),
                    Children = table.Column<string>(type: "TEXT", nullable: true),
                    AnneeScolaire = table.Column<string>(type: "TEXT", nullable: false),
                    IsFakeDb = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Armes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Abreviation = table.Column<string>(type: "TEXT", nullable: false),
                    Label = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalEntities",
                columns: table => new
                {
                    ServerName = table.Column<string>(type: "TEXT", nullable: false),
                    ServerUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Port = table.Column<int>(type: "INTEGER", nullable: false),
                    Access_Token = table.Column<string>(type: "TEXT", nullable: false),
                    Expires_in = table.Column<int>(type: "INTEGER", nullable: false),
                    Token_type = table.Column<string>(type: "TEXT", nullable: false),
                    Refresh_token = table.Column<string>(type: "TEXT", nullable: false),
                    Scope = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    DefaultUser = table.Column<string>(type: "TEXT", nullable: false),
                    DefaultPassword = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalEntities", x => x.ServerName);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Label = table.Column<string>(type: "TEXT", nullable: false),
                    Abreviation = table.Column<string>(type: "TEXT", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradesScientifiques",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Abreviation = table.Column<string>(type: "TEXT", nullable: false),
                    Label = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradesScientifiques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medecins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nom = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Nationnalite = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Sexe = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Specialite = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    NumeroTel = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    NumeroTel2 = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    GradeActuel = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    GradeScientifique = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Matricule = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Observation = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    MetaData = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Thumbnail = table.Column<byte[]>(type: "BLOB", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medecins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nom = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Nationnalite = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SituationFamilliale = table.Column<int>(type: "INTEGER", nullable: false),
                    NombreEnfant = table.Column<int>(type: "INTEGER", nullable: true),
                    NomAr = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PrenomAr = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    AdresseAr = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    PrenomPereAr = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    NomMereAr = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    NumeroTel = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    NumeroTel2 = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    GradeActuel = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Taille = table.Column<double>(type: "REAL", nullable: true),
                    Poids = table.Column<double>(type: "REAL", nullable: true),
                    Sexe = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Matricule = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LieuNaissance = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Groupage = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Adresse = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    PrenomPere = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    NomMere = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Observation = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    MetaData = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Thumbnail = table.Column<byte[]>(type: "BLOB", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Respirateurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Abreviation = table.Column<string>(type: "TEXT", nullable: false),
                    Label = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respirateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Abreviation = table.Column<string>(type: "TEXT", nullable: false),
                    Label = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesAnesthesies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Abreviation = table.Column<string>(type: "TEXT", nullable: false),
                    Label = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesAnesthesies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AntecedentsChirurgicaux",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    PatientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecedentsChirurgicaux", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AntecedentsChirurgicaux_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AntecedentsMedicaux",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TypeAntecedent = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    TypeAntecedentLabel = table.Column<string>(type: "TEXT", nullable: false),
                    PatientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecedentsMedicaux", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AntecedentsMedicaux_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DescriptionConsultation = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    PatientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateConsultation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateInterventionPrevu = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MedecinId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Urgence = table.Column<bool>(type: "INTEGER", nullable: false),
                    Poids = table.Column<double>(type: "REAL", nullable: true),
                    BMI = table.Column<double>(type: "REAL", nullable: true),
                    Taille = table.Column<double>(type: "REAL", nullable: true),
                    S_c = table.Column<double>(type: "REAL", nullable: true),
                    TraitementActuel = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    TraitementAPoursuivre = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    ConclusionExamin = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    PrevisionCG = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    PrevisionPF = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    PrevisionPlaquette = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    TypeAnesthesie = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Asa = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultations_Medecins_MedecinId",
                        column: x => x.MedecinId,
                        principalTable: "Medecins",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Consultations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DMSI_Dossiers_Medicaux",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PatientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MedecinId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: true),
                    Provenance = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    MotifAdmission = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    DateAdmission = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateSortie = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModeSortie = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CaractereUrgent = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    PersonneAJoindreTel = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    AvoirCovid = table.Column<bool>(type: "INTEGER", nullable: false),
                    VaccinationCovid = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    HistoireDuMalade = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMSI_Dossiers_Medicaux", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DMSI_Dossiers_Medicaux_Medecins_MedecinId",
                        column: x => x.MedecinId,
                        principalTable: "Medecins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DMSI_Dossiers_Medicaux_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsignesAnesthesiques",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ConsultationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsignesAnesthesiques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsignesAnesthesiques_Consultations_ConsultationId",
                        column: x => x.ConsultationId,
                        principalTable: "Consultations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExaminsCliniques",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    TypeExamin = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeExaminLabel = table.Column<string>(type: "TEXT", nullable: false),
                    ConsultationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminsCliniques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminsCliniques_Consultations_ConsultationId",
                        column: x => x.ConsultationId,
                        principalTable: "Consultations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interventions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DureeIntervention = table.Column<double>(type: "REAL", nullable: false),
                    DureeAnesthesie = table.Column<double>(type: "REAL", nullable: false),
                    ConsultationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Urgence = table.Column<bool>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<string>(type: "TEXT", nullable: false),
                    EndTime = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MonitorageVoieArt = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    MonitorageAutres = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    TypeAnesthesie = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Asa = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SVesicale = table.Column<bool>(type: "INTEGER", nullable: false),
                    STemp = table.Column<bool>(type: "INTEGER", nullable: false),
                    MatChauf = table.Column<bool>(type: "INTEGER", nullable: false),
                    SGast = table.Column<bool>(type: "INTEGER", nullable: false),
                    Position = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Intubation = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    AutreIntubation = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Circuit = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Respirateur = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    PatientId = table.Column<Guid>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interventions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interventions_Consultations_ConsultationId",
                        column: x => x.ConsultationId,
                        principalTable: "Consultations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interventions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DMSI_Antecedents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DMSI_Dossiers_MedicauxId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMSI_Antecedents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DMSI_Antecedents_DMSI_Dossiers_Medicaux_DMSI_Dossiers_MedicauxId",
                        column: x => x.DMSI_Dossiers_MedicauxId,
                        principalTable: "DMSI_Dossiers_Medicaux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DMSI_Conduites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdDossier = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModeVentilatoire = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    SiVsDebitO2 = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SiCpapDebitO2 = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SiBipapFiO2 = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SiBipapPep = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SiBipapAi = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SiBipapTrigger = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SiBipapPente = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SiBipapTriggerExp = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SiBipapTiMax = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SiVaciFr = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SiVaciVt = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SiVaciIe = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SiVaciFio2 = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SiVaciPep = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DebitInsp = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PlanRespAutre = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    PauseTeleinsp = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Pa = table.Column<string>(type: "TEXT", nullable: false),
                    Fc = table.Column<string>(type: "TEXT", nullable: false),
                    Ic = table.Column<string>(type: "TEXT", nullable: false),
                    Ves = table.Column<string>(type: "TEXT", nullable: false),
                    Rvs = table.Column<string>(type: "TEXT", nullable: false),
                    Nad = table.Column<string>(type: "TEXT", nullable: false),
                    Ad = table.Column<string>(type: "TEXT", nullable: false),
                    Dobutamine = table.Column<string>(type: "TEXT", nullable: false),
                    PlanCardioAutre = table.Column<string>(type: "TEXT", nullable: false),
                    Echocardio = table.Column<string>(type: "TEXT", nullable: false),
                    Diurese = table.Column<string>(type: "TEXT", nullable: false),
                    ClearanceCreat = table.Column<string>(type: "TEXT", nullable: false),
                    Remplissage = table.Column<string>(type: "TEXT", nullable: false),
                    OptimisationHd = table.Column<string>(type: "TEXT", nullable: false),
                    Diuretique = table.Column<string>(type: "TEXT", nullable: false),
                    DialCritere = table.Column<string>(type: "TEXT", nullable: false),
                    HeuresDialyse = table.Column<string>(type: "TEXT", nullable: false),
                    Atb = table.Column<string>(type: "TEXT", nullable: false),
                    Atc = table.Column<string>(type: "TEXT", nullable: false),
                    Sedation = table.Column<string>(type: "TEXT", nullable: false),
                    Nutrition = table.Column<string>(type: "TEXT", nullable: false),
                    AutreTrait = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMSI_Conduites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DMSI_Conduites_DMSI_Dossiers_Medicaux_IdDossier",
                        column: x => x.IdDossier,
                        principalTable: "DMSI_Dossiers_Medicaux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DMSI_Evolutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DMSI_Dossiers_MedicauxId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Medecin_1Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    Medecin_2Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    Avis = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMSI_Evolutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DMSI_Evolutions_DMSI_Dossiers_Medicaux_DMSI_Dossiers_MedicauxId",
                        column: x => x.DMSI_Dossiers_MedicauxId,
                        principalTable: "DMSI_Dossiers_Medicaux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DMSI_Evolutions_Medecins_Medecin_1Id",
                        column: x => x.Medecin_1Id,
                        principalTable: "Medecins",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DMSI_Evolutions_Medecins_Medecin_2Id",
                        column: x => x.Medecin_2Id,
                        principalTable: "Medecins",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DMSI_Examins_Cliniques",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Ex_General = table.Column<string>(type: "TEXT", nullable: false),
                    Ex_Neurologique = table.Column<string>(type: "TEXT", nullable: false),
                    Ex_Cardiovasculaire = table.Column<string>(type: "TEXT", nullable: false),
                    Pleuro_Pulmonaire = table.Column<string>(type: "TEXT", nullable: false),
                    Ex_Uro_Nephrologie = table.Column<string>(type: "TEXT", nullable: false),
                    Ex_Gastro_intestinal = table.Column<string>(type: "TEXT", nullable: false),
                    Evaluation_EVA = table.Column<string>(type: "TEXT", nullable: false),
                    Evaluation_EOC = table.Column<string>(type: "TEXT", nullable: false),
                    Evaluation_DN4 = table.Column<string>(type: "TEXT", nullable: false),
                    Autres = table.Column<string>(type: "TEXT", nullable: false),
                    DossierId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMSI_Examins_Cliniques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DMSI_Examins_Cliniques_DMSI_Dossiers_Medicaux_DossierId",
                        column: x => x.DossierId,
                        principalTable: "DMSI_Dossiers_Medicaux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DMSI_Examins_Complementaires",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DossierId = table.Column<Guid>(type: "TEXT", nullable: true),
                    HB = table.Column<string>(type: "TEXT", nullable: false),
                    GR = table.Column<string>(type: "TEXT", nullable: false),
                    PLQ = table.Column<string>(type: "TEXT", nullable: false),
                    GB = table.Column<string>(type: "TEXT", nullable: false),
                    HT = table.Column<string>(type: "TEXT", nullable: false),
                    GLY = table.Column<string>(type: "TEXT", nullable: false),
                    HBA = table.Column<string>(type: "TEXT", nullable: false),
                    Uree = table.Column<string>(type: "TEXT", nullable: false),
                    Creatinine = table.Column<string>(type: "TEXT", nullable: false),
                    Clairance = table.Column<string>(type: "TEXT", nullable: false),
                    Na = table.Column<string>(type: "TEXT", nullable: false),
                    K = table.Column<string>(type: "TEXT", nullable: false),
                    Ca = table.Column<string>(type: "TEXT", nullable: false),
                    Mg = table.Column<string>(type: "TEXT", nullable: false),
                    TG = table.Column<string>(type: "TEXT", nullable: false),
                    CHOL_TTL = table.Column<string>(type: "TEXT", nullable: false),
                    LDL = table.Column<string>(type: "TEXT", nullable: false),
                    HDL = table.Column<string>(type: "TEXT", nullable: false),
                    ALAT = table.Column<string>(type: "TEXT", nullable: false),
                    ASAT = table.Column<string>(type: "TEXT", nullable: false),
                    GGT = table.Column<string>(type: "TEXT", nullable: false),
                    PAL = table.Column<string>(type: "TEXT", nullable: false),
                    T_Protides = table.Column<string>(type: "TEXT", nullable: false),
                    Electrophorese_Proteines = table.Column<string>(type: "TEXT", nullable: false),
                    Albumine = table.Column<string>(type: "TEXT", nullable: false),
                    TP = table.Column<string>(type: "TEXT", nullable: false),
                    TCK = table.Column<string>(type: "TEXT", nullable: false),
                    INR = table.Column<string>(type: "TEXT", nullable: false),
                    Sintrom_Dose = table.Column<string>(type: "TEXT", nullable: false),
                    CRP = table.Column<string>(type: "TEXT", nullable: false),
                    VS = table.Column<string>(type: "TEXT", nullable: false),
                    Fibrinogene = table.Column<string>(type: "TEXT", nullable: false),
                    Ferritinemie = table.Column<string>(type: "TEXT", nullable: false),
                    Troponine_T = table.Column<string>(type: "TEXT", nullable: false),
                    NT_Pro_BNP = table.Column<string>(type: "TEXT", nullable: false),
                    D_Dimeres = table.Column<string>(type: "TEXT", nullable: false),
                    CPK_MB = table.Column<string>(type: "TEXT", nullable: false),
                    PH = table.Column<string>(type: "TEXT", nullable: false),
                    PaCO2 = table.Column<string>(type: "TEXT", nullable: false),
                    PaO2 = table.Column<string>(type: "TEXT", nullable: false),
                    HCO3 = table.Column<string>(type: "TEXT", nullable: false),
                    FIO2 = table.Column<string>(type: "TEXT", nullable: false),
                    LACTATES = table.Column<string>(type: "TEXT", nullable: false),
                    PaO2_FiO2 = table.Column<string>(type: "TEXT", nullable: false),
                    Commentaire = table.Column<string>(type: "TEXT", nullable: false),
                    Radiographie_Thorax = table.Column<string>(type: "TEXT", nullable: false),
                    ECG = table.Column<string>(type: "TEXT", nullable: false),
                    Echographie_Cardiaque = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMSI_Examins_Complementaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DMSI_Examins_Complementaires_DMSI_Dossiers_Medicaux_DossierId",
                        column: x => x.DossierId,
                        principalTable: "DMSI_Dossiers_Medicaux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DMSI_Metrics_Admission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Poids = table.Column<string>(type: "TEXT", nullable: false),
                    Taille = table.Column<string>(type: "TEXT", nullable: false),
                    BMI = table.Column<string>(type: "TEXT", nullable: false),
                    Temperature = table.Column<string>(type: "TEXT", nullable: false),
                    FreqRes = table.Column<string>(type: "TEXT", nullable: false),
                    SpO2_SansO2 = table.Column<string>(type: "TEXT", nullable: false),
                    SpO2SousO2 = table.Column<string>(type: "TEXT", nullable: false),
                    ScoreGlasgow = table.Column<string>(type: "TEXT", nullable: false),
                    OY = table.Column<string>(type: "TEXT", nullable: false),
                    RV = table.Column<string>(type: "TEXT", nullable: false),
                    RM = table.Column<string>(type: "TEXT", nullable: false),
                    Pupilles = table.Column<string>(type: "TEXT", nullable: false),
                    DeficitMoteur = table.Column<string>(type: "TEXT", nullable: false),
                    PA = table.Column<string>(type: "TEXT", nullable: false),
                    Pouls = table.Column<string>(type: "TEXT", nullable: false),
                    Diurese = table.Column<string>(type: "TEXT", nullable: false),
                    Etat = table.Column<string>(type: "TEXT", nullable: false),
                    DossierId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMSI_Metrics_Admission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DMSI_Metrics_Admission_DMSI_Dossiers_Medicaux_DossierId",
                        column: x => x.DossierId,
                        principalTable: "DMSI_Dossiers_Medicaux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DMSI_Traitements_Encours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    DossierId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMSI_Traitements_Encours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DMSI_Traitements_Encours_DMSI_Dossiers_Medicaux_DossierId",
                        column: x => x.DossierId,
                        principalTable: "DMSI_Dossiers_Medicaux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActeursIntervenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MedecinId = table.Column<Guid>(type: "TEXT", nullable: false),
                    InterventionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActeursIntervenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActeursIntervenants_Interventions_InterventionId",
                        column: x => x.InterventionId,
                        principalTable: "Interventions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgentsAnesthesiques",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Agent = table.Column<string>(type: "TEXT", nullable: true),
                    Dose = table.Column<string>(type: "TEXT", nullable: true),
                    temps = table.Column<string>(type: "TEXT", nullable: true),
                    InterventionId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentsAnesthesiques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentsAnesthesiques_Interventions_InterventionId",
                        column: x => x.InterventionId,
                        principalTable: "Interventions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BilanInOut",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    InterventionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BilanInOut", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BilanInOut_Interventions_InterventionId",
                        column: x => x.InterventionId,
                        principalTable: "Interventions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeroulementsOperatoire",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Temps = table.Column<string>(type: "TEXT", nullable: false),
                    InterventionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Temperature = table.Column<int>(type: "INTEGER", nullable: true),
                    FrequenceCardiaque = table.Column<int>(type: "INTEGER", nullable: true),
                    PressionArterielleMin = table.Column<int>(type: "INTEGER", nullable: true),
                    PressionArterielleMax = table.Column<int>(type: "INTEGER", nullable: true),
                    Diurese = table.Column<int>(type: "INTEGER", nullable: true),
                    Saignement = table.Column<int>(type: "INTEGER", nullable: true),
                    TempsOperatoire = table.Column<string>(type: "TEXT", nullable: false),
                    Agent = table.Column<string>(type: "TEXT", nullable: false),
                    AgentValue = table.Column<double>(type: "REAL", nullable: true),
                    ApportsCG = table.Column<bool>(type: "INTEGER", nullable: true),
                    ApportsPFC = table.Column<bool>(type: "INTEGER", nullable: true),
                    ApportsPlasm = table.Column<bool>(type: "INTEGER", nullable: true),
                    ApportsGluc = table.Column<bool>(type: "INTEGER", nullable: true),
                    ApportsSale = table.Column<bool>(type: "INTEGER", nullable: true),
                    PO2 = table.Column<string>(type: "TEXT", nullable: false),
                    PCO2 = table.Column<string>(type: "TEXT", nullable: false),
                    PH = table.Column<string>(type: "TEXT", nullable: false),
                    HCO3 = table.Column<string>(type: "TEXT", nullable: false),
                    Sat = table.Column<string>(type: "TEXT", nullable: false),
                    Ht = table.Column<string>(type: "TEXT", nullable: false),
                    FIO2 = table.Column<string>(type: "TEXT", nullable: false),
                    N2O = table.Column<string>(type: "TEXT", nullable: false),
                    Air = table.Column<string>(type: "TEXT", nullable: false),
                    V = table.Column<string>(type: "TEXT", nullable: false),
                    Vt = table.Column<string>(type: "TEXT", nullable: false),
                    F = table.Column<string>(type: "TEXT", nullable: false),
                    Sevo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeroulementsOperatoire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeroulementsOperatoire_Interventions_InterventionId",
                        column: x => x.InterventionId,
                        principalTable: "Interventions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostsOperation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    InterventionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConsignsParticuliersReveil = table.Column<string>(type: "TEXT", nullable: false),
                    AnalogiqueReveil = table.Column<string>(type: "TEXT", nullable: false),
                    AutreReveil = table.Column<string>(type: "TEXT", nullable: false),
                    FlaconBloc = table.Column<string>(type: "TEXT", nullable: false),
                    DatePrescription = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AntiCoagulants = table.Column<string>(type: "TEXT", nullable: false),
                    Antalogique = table.Column<string>(type: "TEXT", nullable: false),
                    Antibiotique = table.Column<string>(type: "TEXT", nullable: false),
                    Autres = table.Column<string>(type: "TEXT", nullable: false),
                    RealPostop = table.Column<string>(type: "TEXT", nullable: false),
                    Surveillance = table.Column<string>(type: "TEXT", nullable: false),
                    Bilan = table.Column<string>(type: "TEXT", nullable: false),
                    SortieAutorise = table.Column<string>(type: "TEXT", nullable: false),
                    DateBilan = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostsOperation_Interventions_InterventionId",
                        column: x => x.InterventionId,
                        principalTable: "Interventions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProblemesPreOperatoire",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    InterventionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemesPreOperatoire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProblemesPreOperatoire_Interventions_InterventionId",
                        column: x => x.InterventionId,
                        principalTable: "Interventions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeOperation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    InterventionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Induction = table.Column<string>(type: "TEXT", nullable: false),
                    Intubation = table.Column<string>(type: "TEXT", nullable: false),
                    Ventilation = table.Column<string>(type: "TEXT", nullable: false),
                    Entretien = table.Column<string>(type: "TEXT", nullable: false),
                    Reveil = table.Column<string>(type: "TEXT", nullable: false),
                    Extubation = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeOperation_Interventions_InterventionId",
                        column: x => x.InterventionId,
                        principalTable: "Interventions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActeursIntervenants_InterventionId",
                table: "ActeursIntervenants",
                column: "InterventionId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentsAnesthesiques_InterventionId",
                table: "AgentsAnesthesiques",
                column: "InterventionId");

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentsChirurgicaux_PatientId",
                table: "AntecedentsChirurgicaux",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentsMedicaux_PatientId",
                table: "AntecedentsMedicaux",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BilanInOut_InterventionId",
                table: "BilanInOut",
                column: "InterventionId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsignesAnesthesiques_ConsultationId",
                table: "ConsignesAnesthesiques",
                column: "ConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_DateConsultation",
                table: "Consultations",
                column: "DateConsultation");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_MedecinId",
                table: "Consultations",
                column: "MedecinId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_PatientId",
                table: "Consultations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DeroulementsOperatoire_InterventionId",
                table: "DeroulementsOperatoire",
                column: "InterventionId");

            migrationBuilder.CreateIndex(
                name: "IX_DMSI_Antecedents_DMSI_Dossiers_MedicauxId",
                table: "DMSI_Antecedents",
                column: "DMSI_Dossiers_MedicauxId");

            migrationBuilder.CreateIndex(
                name: "IX_DMSI_Conduites_IdDossier",
                table: "DMSI_Conduites",
                column: "IdDossier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DMSI_Dossiers_Medicaux_DateAdmission",
                table: "DMSI_Dossiers_Medicaux",
                column: "DateAdmission");

            migrationBuilder.CreateIndex(
                name: "IX_DMSI_Dossiers_Medicaux_MedecinId",
                table: "DMSI_Dossiers_Medicaux",
                column: "MedecinId");

            migrationBuilder.CreateIndex(
                name: "IX_DMSI_Dossiers_Medicaux_PatientId",
                table: "DMSI_Dossiers_Medicaux",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DMSI_Evolutions_DMSI_Dossiers_MedicauxId",
                table: "DMSI_Evolutions",
                column: "DMSI_Dossiers_MedicauxId");

            migrationBuilder.CreateIndex(
                name: "IX_DMSI_Evolutions_Medecin_1Id",
                table: "DMSI_Evolutions",
                column: "Medecin_1Id");

            migrationBuilder.CreateIndex(
                name: "IX_DMSI_Evolutions_Medecin_2Id",
                table: "DMSI_Evolutions",
                column: "Medecin_2Id");

            migrationBuilder.CreateIndex(
                name: "IX_DMSI_Examins_Cliniques_DossierId",
                table: "DMSI_Examins_Cliniques",
                column: "DossierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DMSI_Examins_Complementaires_DossierId",
                table: "DMSI_Examins_Complementaires",
                column: "DossierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DMSI_Metrics_Admission_DossierId",
                table: "DMSI_Metrics_Admission",
                column: "DossierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DMSI_Traitements_Encours_DossierId",
                table: "DMSI_Traitements_Encours",
                column: "DossierId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminsCliniques_ConsultationId",
                table: "ExaminsCliniques",
                column: "ConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_Interventions_ConsultationId",
                table: "Interventions",
                column: "ConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_Interventions_Date",
                table: "Interventions",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Interventions_Date_Status",
                table: "Interventions",
                columns: new[] { "Date", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_Interventions_PatientId",
                table: "Interventions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Matricule",
                table: "Patients",
                column: "Matricule",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostsOperation_InterventionId",
                table: "PostsOperation",
                column: "InterventionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemesPreOperatoire_InterventionId",
                table: "ProblemesPreOperatoire",
                column: "InterventionId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeOperation_InterventionId",
                table: "ResumeOperation",
                column: "InterventionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActeursIntervenants");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "AgentsAnesthesiques");

            migrationBuilder.DropTable(
                name: "AntecedentsChirurgicaux");

            migrationBuilder.DropTable(
                name: "AntecedentsMedicaux");

            migrationBuilder.DropTable(
                name: "AppNotifications");

            migrationBuilder.DropTable(
                name: "AppSettings");

            migrationBuilder.DropTable(
                name: "Armes");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BilanInOut");

            migrationBuilder.DropTable(
                name: "ConsignesAnesthesiques");

            migrationBuilder.DropTable(
                name: "DeroulementsOperatoire");

            migrationBuilder.DropTable(
                name: "DMSI_Antecedents");

            migrationBuilder.DropTable(
                name: "DMSI_Conduites");

            migrationBuilder.DropTable(
                name: "DMSI_Evolutions");

            migrationBuilder.DropTable(
                name: "DMSI_Examins_Cliniques");

            migrationBuilder.DropTable(
                name: "DMSI_Examins_Complementaires");

            migrationBuilder.DropTable(
                name: "DMSI_Metrics_Admission");

            migrationBuilder.DropTable(
                name: "DMSI_Traitements_Encours");

            migrationBuilder.DropTable(
                name: "ExaminsCliniques");

            migrationBuilder.DropTable(
                name: "ExternalEntities");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "GradesScientifiques");

            migrationBuilder.DropTable(
                name: "PostsOperation");

            migrationBuilder.DropTable(
                name: "ProblemesPreOperatoire");

            migrationBuilder.DropTable(
                name: "Respirateurs");

            migrationBuilder.DropTable(
                name: "ResumeOperation");

            migrationBuilder.DropTable(
                name: "Specialites");

            migrationBuilder.DropTable(
                name: "TypesAnesthesies");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DMSI_Dossiers_Medicaux");

            migrationBuilder.DropTable(
                name: "Interventions");

            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "Medecins");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
