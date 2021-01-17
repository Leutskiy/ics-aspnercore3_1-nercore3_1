﻿using ICS.Domain.Entities;
using ICS.Domain.Entities.System;
using ICS.WebApplication.Commands.Read.Results;
using System.Collections.Generic;

namespace ICS.WebApplication.Commands.Converters
{
	public sealed class DomainEntityConverter
    {
        public static ProfileResult ConvertToResult(Profile profile)
        {
            return new ProfileResult
            {
                Id = profile.Id,
                Avatar = profile.Photo,
                WebPages = profile.WebPages
            };
        }

        public static ContactResult ConvertToResult(Contact contact)
        {
            return new ContactResult
            {
                Id = contact.Id,
                Email = contact.Email,
                Postcode = contact.Postcode,
                HomePhoneNumber = contact.HomePhoneNumber,
                WorkPhoneNumber = contact.WorkPhoneNumber,
                MobilePhoneNumber = contact.MobilePhoneNumber
            };
        }

        public static PassportResult ConvertToResult(Passport passport)
        {
            return new PassportResult
            {
                Id = passport.Id,
                NameRus = passport.NameRus,
                NameEng = passport.NameEng,
                SurnameRus = passport.SurnameRus,
                SurnameEng = passport.SurnameEng,
                PatronymicNameRus = passport.PatronymicNameRus,
                PatronymicNameEng = passport.PatronymicNameEng,
                BirthPlace = passport.BirthPlace,
                BirthCountry = passport.BirthCountry,
                Citizenship =  passport.Citizenship,
                Residence =  passport.Residence,
                ResidenceCountry =  passport.ResidenceCountry,
                ResidenceRegion =  passport.ResidenceRegion,
                IdentityDocument =  passport.IdentityDocument,
                IssuePlace =  passport.IssuePlace,
                DepartmentCode = passport.DepartmentCode,
                BirthDate = passport.BirthDate,
                IssueDate = passport.IssueDate,
                Gender = passport.Gender
            };
        }

        public static DocumentResult ConvertToResult(Document document)
        {
            return new DocumentResult
            {
                Id = document.Id,
                Name = document.Name,
                Content = document.Content,
                UpdateDate = document.UpdateDate,
                CreatedDate = document.CreatedDate,
                DocumentType = document.DocumentType
            };
        }

        public static VisitDetailResult ConvertToResult(VisitDetail visitDetail)
        {
            return new VisitDetailResult
            {
                Id = visitDetail.Id,
                Goal = visitDetail.Goal,
                Country = visitDetail.Country,
                VisaType = visitDetail.VisaType,
                VisaCity = visitDetail.VisaCity,
                VisaCountry = visitDetail.VisaCountry,
                VisitingPoints = visitDetail.VisitingPoints,
                VisaMultiplicity = visitDetail.VisaMultiplicity,
                PeriodInDays = visitDetail.PeriodDays,
                ArrivalDate = visitDetail.ArrivalDate,
                DepartureDate = visitDetail.DepartureDate,
            };
        }

        public static StateRegistrationResult ConvertToResult(StateRegistration stateRegistration)
        {
            return new StateRegistrationResult
            {
                Id = stateRegistration.Id,
                Inn = stateRegistration.Inn == null ? string.Empty : stateRegistration.Inn,
                Ogrnip = stateRegistration.Ogrnip == null ? string.Empty : stateRegistration.Ogrnip
            };
        }

        public static AlienResult ConvertToResult(
            Alien alien,
            ContactResult? contactResult,
            PassportResult? passportResult,
            OrganizationResult? organizationResult,
            StateRegistrationResult? stateRegistrationResult)
        {
            return new AlienResult
            {
                Id = alien.Id,
                Contact = contactResult,
                Passport = passportResult,
                Organization = organizationResult,
                StateRegistration = stateRegistrationResult,
                Position = alien.Position,
                WorkPlace = alien.WorkPlace,
                WorkAddress = alien.WorkAddress,
                StayAddress = alien.StayAddress
            };
        }

        public static EmployeeResult ConvertToResult(
            Employee employee,
            ContactResult? contactResult,
            PassportResult? passportResult,
            OrganizationResult? organizationResult,
            StateRegistrationResult? stateRegistrationResult)
        {
            return new EmployeeResult
            {
                Id = employee.Id,
                Contact = contactResult,
                Passport = passportResult,
                Organization = organizationResult,
                StateRegistration = stateRegistrationResult,
                ManagerId = employee.ManagerId,
                AcademicDegree = employee.AcademicDegree,
                AcademicRank = employee.AcademicRank,
                Education = employee.Education,
                Position = employee.Position,
                WorkPlace = employee.WorkPlace
            };
        }

        public static OrganizationResult ConvertToResult(
            Organization organization,
            StateRegistrationResult? stateRegistrationResult)
        {
            return new OrganizationResult
            {
                Id = organization.Id,
                Name = organization.Name,
                ShortName = organization.ShortName,
                StateRegistration = stateRegistrationResult,
                LegalAddress = organization.LegalAddress,
                ScientificActivity = organization.ScientificActivity
            };
        }

        public static ForeignParticipantResult ConvertToResult(ForeignParticipant foreignParticipant)
        {
            return new ForeignParticipantResult
            {
                Id = foreignParticipant.Id,
                Passport = foreignParticipant.Passport == null ? null : ConvertToResult(foreignParticipant.Passport)
            };
        }

        public static InvitationResult ConvertToResult(
            Invitation invitation,
            AlienResult? alienResult,
            EmployeeResult? employeeResult,
            VisitDetailResult? visitDetailResult,
            IEnumerable<ForeignParticipantResult>? foreignParticipantResultCollection)
        {
            return new InvitationResult
            {
                Id = invitation.Id,
                Alien = alienResult,
                Employee = employeeResult,
                VisitDetail = visitDetailResult,
                ForeignParticipants = foreignParticipantResultCollection
            };
        }
    }
}