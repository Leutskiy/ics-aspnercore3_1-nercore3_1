using ICS.Domain.Entities;
using ICS.Domain.Entities.System;
using ICS.Shared;
using ICS.WebApplication.Commands.Read.Results;
using System.Collections.Generic;

namespace ICS.WebApplication.Commands.Converters
{
    public sealed class DomainEntityConverter
    {
        public static ProfileResult ConvertToResult(Profile profile)
        {
            Contract.Argument.IsNotNull(profile, nameof(profile));

            return new ProfileResult
            {
                Id = profile.Id,
                UserId = profile.UserId,
                Avatar = profile.Photo,
                WebPages = profile.WebPages
            };
        }

        public static ContactResult ConvertToResult(Contact contact)
        {
            Contract.Argument.IsNotNull(contact, nameof(contact));

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
            Contract.Argument.IsNotNull(passport, nameof(passport));

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
                Citizenship = passport.Citizenship,
                Residence = passport.Residence,
                ResidenceCountry = passport.ResidenceCountry,
                ResidenceRegion = passport.ResidenceRegion,
                IdentityDocument = passport.IdentityDocument,
                IssuePlace = passport.IssuePlace,
                DepartmentCode = passport.DepartmentCode,
                BirthDate = passport.BirthDate,
                IssueDate = passport.IssueDate,
                Gender = passport.Gender
            };
        }

        public static DocumentResult ConvertToResult(Document document)
        {
            Contract.Argument.IsNotNull(document, nameof(document));

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
            Contract.Argument.IsNotNull(visitDetail, nameof(visitDetail));

            return new VisitDetailResult
            {
                Id = visitDetail.Id,
                InvitationId = visitDetail.InvitationId,
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
            Contract.Argument.IsNotNull(stateRegistration, nameof(stateRegistration));

            return new StateRegistrationResult
            {
                Id = stateRegistration.Id,
                Inn = stateRegistration.Inn,
                Ogrnip = stateRegistration.Ogrnip
            };
        }

        public static AlienResult ConvertToResult(
            Alien alien,
            ContactResult contactResult,
            PassportResult passportResult,
            OrganizationResult organizationResult,
            StateRegistrationResult stateRegistrationResult)
        {
            Contract.Argument.IsNotNull(alien, nameof(alien));
            Contract.Argument.IsNotNull(contactResult, nameof(contactResult));
            Contract.Argument.IsNotNull(passportResult, nameof(passportResult));
            Contract.Argument.IsNotNull(organizationResult, nameof(organizationResult));
            Contract.Argument.IsNotNull(stateRegistrationResult, nameof(stateRegistrationResult));

            return new AlienResult
            {
                Id = alien.Id,
                InvitationId = alien.InvitationId,
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
            ContactResult contactResult,
            PassportResult passportResult,
            OrganizationResult organizationResult,
            StateRegistrationResult stateRegistrationResult)
        {
            Contract.Argument.IsNotNull(employee, nameof(employee));

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
            StateRegistrationResult stateRegistrationResult)
        {
            Contract.Argument.IsNotNull(organization, nameof(organization));
            Contract.Argument.IsNotNull(stateRegistrationResult, nameof(stateRegistrationResult));

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

        public static ForeignParticipantResult ConvertToResult(
            ForeignParticipant foreignParticipant,
            PassportResult passportResult)
        {
            Contract.Argument.IsNotNull(foreignParticipant, nameof(foreignParticipant));
            Contract.Argument.IsNotNull(passportResult, nameof(passportResult));

            return new ForeignParticipantResult
            {
                Id = foreignParticipant.Id,
                AlienId = foreignParticipant.AlienId,
                InvitationId = foreignParticipant.InvitationId,
                Passport = passportResult
            };
        }

        public static InvitationResult ConvertToResult(
            Invitation invitation,
            AlienResult alienResult,
            EmployeeResult employeeResult,
            VisitDetailResult visitDetailResult,
            IEnumerable<ForeignParticipantResult> foreignParticipantResultCollection)
        {
            Contract.Argument.IsNotNull(invitation, nameof(invitation));
            Contract.Argument.IsNotNull(alienResult, nameof(alienResult));
            Contract.Argument.IsNotNull(employeeResult, nameof(employeeResult));
            Contract.Argument.IsNotNull(visitDetailResult, nameof(visitDetailResult));
            Contract.Argument.IsNotNull(foreignParticipantResultCollection, nameof(foreignParticipantResultCollection));

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