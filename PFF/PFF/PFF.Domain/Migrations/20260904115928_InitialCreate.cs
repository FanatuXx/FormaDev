using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFF.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressePatient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rue = table.Column<string>(type: "NVARCHAR(256)", nullable: false),
                    Numéro = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    CodePostal = table.Column<int>(type: "INT", nullable: false),
                    Ville = table.Column<string>(type: "NVARCHAR(128)", nullable: false),
                    Pays = table.Column<string>(type: "NVARCHAR(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressePatient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Médicament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "NVARCHAR(128)", nullable: false),
                    MéthodePrise = table.Column<string>(type: "NVARCHAR(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Médicament", x => x.Id);
                    table.CheckConstraint("CK_Médicament_MethodePrise", "LEN(TRIM(Nom)) > 0");
                    table.CheckConstraint("CK_Médicament_Nom", "LEN(TRIM(Nom)) > 0");
                });

            migrationBuilder.CreateTable(
                name: "Pathologie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "NVARCHAR(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pathologie", x => x.Id);
                    table.CheckConstraint("CK_Pathologie_Nom", "LEN(TRIM(Nom)) > 0");
                });

            migrationBuilder.CreateTable(
                name: "Travailleur",
                columns: table => new
                {
                    SSIN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prénom = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Nom = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Genre = table.Column<string>(type: "NVARCHAR(30)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(256)", nullable: false),
                    NuméroTéléphone = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Fonction = table.Column<string>(type: "NVARCHAR(128)", nullable: false),
                    Rue = table.Column<string>(type: "NVARCHAR(256)", nullable: false),
                    Numéro = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    CodePostal = table.Column<int>(type: "INT", nullable: false),
                    Ville = table.Column<string>(type: "NVARCHAR(128)", nullable: false),
                    Pays = table.Column<string>(type: "NVARCHAR(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travailleur", x => x.SSIN);
                    table.CheckConstraint("CK_Travailleur_Email", "Email LIKE '%_@__%.__%'");
                    table.CheckConstraint("CK_Travailleur_Noms", "LEN(TRIM(Prénom)) > 0 AND LEN(TRIM(Nom)) > 0");
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NISS = table.Column<int>(type: "INT", nullable: false),
                    Prénom = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Nom = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Surnom = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Genre = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    NuméroTéléphone = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    DateInscription = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DateDernièreVisite = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    PatientAddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.CheckConstraint("CK_Patient_DernièreVisite", "DateDernièreVisite >= DateInscription");
                    table.CheckConstraint("CK_Patient_Identification", "LEN(Prénom) > 0 OR LEN(Nom) > 0 OR LEN(Surnom) > 0");
                    table.ForeignKey(
                        name: "FK_Patient_AddressePatient_PatientAddressId",
                        column: x => x.PatientAddressId,
                        principalTable: "AddressePatient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(256)", nullable: false),
                    PathologyId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultation", x => x.Id);
                    table.CheckConstraint("CK_Consultation_Date", "Date <= GETDATE()");
                    table.ForeignKey(
                        name: "FK_Consultation_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultations_Pathologies_JoinTable",
                columns: table => new
                {
                    ConsultationsId = table.Column<int>(type: "int", nullable: false),
                    PathologiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations_Pathologies_JoinTable", x => new { x.ConsultationsId, x.PathologiesId });
                    table.ForeignKey(
                        name: "FK_Consultations_Pathologies_JoinTable_Consultation_ConsultationsId",
                        column: x => x.ConsultationsId,
                        principalTable: "Consultation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultations_Pathologies_JoinTable_Pathologie_PathologiesId",
                        column: x => x.PathologiesId,
                        principalTable: "Pathologie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultations_Travailleurs_JoinTable",
                columns: table => new
                {
                    ConsultationsId = table.Column<int>(type: "int", nullable: false),
                    WorkersSSIN = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations_Travailleurs_JoinTable", x => new { x.ConsultationsId, x.WorkersSSIN });
                    table.ForeignKey(
                        name: "FK_Consultations_Travailleurs_JoinTable_Consultation_ConsultationsId",
                        column: x => x.ConsultationsId,
                        principalTable: "Consultation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultations_Travailleurs_JoinTable_Travailleur_WorkersSSIN",
                        column: x => x.WorkersSSIN,
                        principalTable: "Travailleur",
                        principalColumn: "SSIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParamètresVitaux",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FréquenceCardiaque = table.Column<int>(type: "INT", nullable: false),
                    PressionArtérielle = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Température = table.Column<decimal>(type: "DECIMAL(3,1)", nullable: false),
                    FréquenceRespiratoire = table.Column<int>(type: "INT", nullable: false),
                    Saturation = table.Column<int>(type: "INT", nullable: false),
                    ConsultationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamètresVitaux", x => x.Id);
                    table.CheckConstraint("CK_Paramètres_FréquenceCardiaque", "FréquenceCardiaque <= 220");
                    table.CheckConstraint("CK_Paramètres_FréquenceRespiratoire", "FréquenceRespiratoire >= 1 AND FréquenceRespiratoire <= 60");
                    table.CheckConstraint("CK_Paramètres_Saturation", "Saturation >= 1 AND Saturation <= 100");
                    table.CheckConstraint("CK_Paramètres_Température", "Température >= 30 AND Température <= 45");
                    table.ForeignKey(
                        name: "FK_ParamètresVitaux_Consultation_ConsultationId",
                        column: x => x.ConsultationId,
                        principalTable: "Consultation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDébut = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DateFin = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FréquencePrise = table.Column<string>(type: "NVARCHAR(128)", nullable: false),
                    ConsultationId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    WorkerSSIN = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.Id);
                    table.CheckConstraint("CK_Prescription_Dates", "DateDébut < DateFin");
                    table.ForeignKey(
                        name: "FK_Prescription_Consultation_ConsultationId",
                        column: x => x.ConsultationId,
                        principalTable: "Consultation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prescription_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prescription_Travailleur_WorkerSSIN",
                        column: x => x.WorkerSSIN,
                        principalTable: "Travailleur",
                        principalColumn: "SSIN");
                });

            migrationBuilder.CreateTable(
                name: "Médicaments_Prescriptions_JoinTable",
                columns: table => new
                {
                    MedicinesId = table.Column<int>(type: "int", nullable: false),
                    PrescriptionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Médicaments_Prescriptions_JoinTable", x => new { x.MedicinesId, x.PrescriptionsId });
                    table.ForeignKey(
                        name: "FK_Médicaments_Prescriptions_JoinTable_Médicament_MedicinesId",
                        column: x => x.MedicinesId,
                        principalTable: "Médicament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Médicaments_Prescriptions_JoinTable_Prescription_PrescriptionsId",
                        column: x => x.PrescriptionsId,
                        principalTable: "Prescription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_PatientId",
                table: "Consultation",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_Pathologies_JoinTable_PathologiesId",
                table: "Consultations_Pathologies_JoinTable",
                column: "PathologiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_Travailleurs_JoinTable_WorkersSSIN",
                table: "Consultations_Travailleurs_JoinTable",
                column: "WorkersSSIN");

            migrationBuilder.CreateIndex(
                name: "IX_Médicament_Nom",
                table: "Médicament",
                column: "Nom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Médicaments_Prescriptions_JoinTable_PrescriptionsId",
                table: "Médicaments_Prescriptions_JoinTable",
                column: "PrescriptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ParamètresVitaux_ConsultationId",
                table: "ParamètresVitaux",
                column: "ConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_Pathologie_Nom",
                table: "Pathologie",
                column: "Nom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_NISS",
                table: "Patient",
                column: "NISS",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PatientAddressId",
                table: "Patient",
                column: "PatientAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_ConsultationId",
                table: "Prescription",
                column: "ConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_PatientId",
                table: "Prescription",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_WorkerSSIN",
                table: "Prescription",
                column: "WorkerSSIN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultations_Pathologies_JoinTable");

            migrationBuilder.DropTable(
                name: "Consultations_Travailleurs_JoinTable");

            migrationBuilder.DropTable(
                name: "Médicaments_Prescriptions_JoinTable");

            migrationBuilder.DropTable(
                name: "ParamètresVitaux");

            migrationBuilder.DropTable(
                name: "Pathologie");

            migrationBuilder.DropTable(
                name: "Médicament");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Consultation");

            migrationBuilder.DropTable(
                name: "Travailleur");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "AddressePatient");
        }
    }
}
