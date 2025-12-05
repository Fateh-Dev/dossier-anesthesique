using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Server.Net.DTOs.Anesthesia;
using Server.Net.DTOs.Antecedents;
using Server.Net.DTOs.Core;
using Server.Net.DTOs.DMSI;
using Server.Net.DTOs.Operations;
using Server.Net.Models.Anesthesia;
using Server.Net.Models.Antecedents;
using Server.Net.Models.DMSI;
using Server.Net.Models.Entities;
using Server.Net.Models.Operations;
using Server.Net.Models.System;

namespace Server.Net.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<DMSI_Dossiers_MedicauxDto, DMSI_Dossiers_Medicaux>();

            CreateMap<DMSI_ConduiteCreateOrUpdateDto, DMSI_Conduite>();
            CreateMap<DMSI_Conduite, DMSI_ConduiteCreateOrUpdateDto>();
            CreateMap<DMSI_EvolutionsCreateOrUpdateDto, DMSI_Evolutions>();
            CreateMap<DMSI_Evolutions, DMSI_EvolutionsCreateOrUpdateDto>();

            CreateMap<DMSI_Examins_CliniquesCreateOrUpdateDo, DMSI_Examins_Cliniques>();
            CreateMap<DMSI_Examins_Cliniques, DMSI_Examins_CliniquesCreateOrUpdateDo>();

            CreateMap<DMSI_Examins_ComplementairesCreateDto, DMSI_Examins_Complementaires>();
            CreateMap<DMSI_Examins_Complementaires, DMSI_Examins_ComplementairesCreateDto>();

            CreateMap<DMSI_Metrics_Admission, DMSI_Metrics_AdmissionCreateDto>();
            CreateMap<DMSI_Metrics_AdmissionCreateDto, DMSI_Metrics_Admission>();

            // Core DTOs
            CreateMap<AntecedentMedical, AntecedentMedicalReturnDto>();
            CreateMap<Consultation, ConsultationReturnDto>();
            CreateMap<Medecin, MedecinReturnDto>();
            CreateMap<PostOperationCreateDto, PostOperation>();
            CreateMap<DeroulementOperatoire, DeroulementOperatoireCreateDto>();
            CreateMap<DeroulementOperatoireCreateDto, DeroulementOperatoire>();
            CreateMap<AgentAnesthesique, AgentAnesthesiqueCreateDto>();
            CreateMap<ResumeOperationCreateDto, ResumeOperation>();
            CreateMap<ExaminClinique, ExaminCliniqueReturnDto>();
            CreateMap<ConsigneAnesthesique, ConsigneAnesthesiqueReturnDto>();
            CreateMap<AntecedentChirurgical, AntecedentChirurgicalReturnDto>();
            CreateMap<Patient, PatientReturnDto>()
                .ForMember(
                    destinationMember => destinationMember.AntecedentsMedicaux,
                    memberOptions =>
                        memberOptions.MapFrom(sourceMember =>
                            sourceMember
                                .AntecedentsMedicaux.OrderBy(o => o.TypeAntecedent)
                                .Where(u => u.Description != null && u.Description != "-")
                        )
                );
        }
    }
}
