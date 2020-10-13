using ICS.Domain.Enums;
using System;

namespace ICS.Domain.Entities
{
    /// <summary>
    /// Паспорт
    /// </summary>
    public class Passport
    {
        protected Passport()
        {

        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// Имя (по-русски)
        /// </summary>
        public virtual string NameRus { get; protected set; }

        /// <summary>
        /// Имя (по-английски)
        /// </summary>
        public virtual string NameEng { get; protected set; }

        /// <summary>
        /// Фамилия (по-русски)
        /// </summary>
        public virtual string SurnameRus { get; protected set; }

        /// <summary>
        /// Фамилия (по-английски)
        /// </summary>
        public virtual string SurnameEng { get; protected set; }

        /// <summary>
        /// Отчество (по-русски)
        /// </summary>
        public virtual string PatronymicNameRus { get; protected set; }

        /// <summary>
        /// Отчество (по-ангийски)
        /// </summary>
        public virtual string PatronymicNameEng { get; protected set; }

        /// <summary>
        /// Место рождения
        /// </summary>
        public virtual string BirthPlace { get; protected set; }

        /// <summary>
        /// Страна рождения
        /// </summary>
        public virtual string BirthCountry { get; protected set; }

        /// <summary>
        /// Гражданство (подданство)
        /// </summary>
        public virtual string Citizenship { get; protected set; }

        /// <summary>
        /// Местожительство
        /// </summary>
        public virtual string Residence { get; protected set; }

        /// <summary>
        /// Страна постоянного проживания
        /// </summary>
        public virtual string ResidenceCountry { get; protected set; }

        /// <summary>
        /// Регион в стране постоянного проживания
        /// </summary>
        public virtual string ResidenceRegion { get; protected set; }

        /// <summary>
        /// Документ удостоверяющий личность
        /// </summary>
        public virtual string IdentityDocument { get; protected set; }

        /// <summary>
        /// Место выдачи документа удостоверяющего личность
        /// </summary>
        public virtual string IssuePlace { get; protected set; }

        /// <summary>
        /// Код подразделения выдававшего документ
        /// </summary>
        public virtual string DepartmentCode { get; protected set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public virtual DateTime? BirthDate { get; protected set; }

        /// <summary>
        /// Дата выдачи документа удостоверяющего личность
        /// </summary>
        public virtual DateTime? IssueDate { get; protected set; }

        /// <summary>
        /// Пол
        /// </summary>
        public virtual Sex? Gender { get; protected set; }

        /// <summary>
        /// Инициализировать паспорт
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="nameRus">Имя по-русски</param>
        /// <param name="surnameRus">Фмаилия по-русски</param>
        /// <param name="nameEng">Имя по-английски</param>
        /// <param name="surnameEng">Фамилия по-английски</param>
        /// <param name="patronymicNameRus">Отчество по-русски</param>
        /// <param name="patronymicNameEng">Отчество по-английски</param>
        /// <param name="birthPlace">Место рождения</param>
        /// <param name="birthCountry">Страна рождения</param>
        /// <param name="departmentCode">Код подразделения</param>
        /// <param name="citizenship">Гражданство (подданство)</param>
        /// <param name="identityDocument">Документ идентицирующий личность</param>
        /// <param name="residence">Местожительство</param>
        /// <param name="residenceCountry">Страна проживания</param>
        /// <param name="residenceRegion">Регион проживания</param>
        /// <param name="issuePlace">Место выда документа идентифицирующего личность</param>
        /// <param name="birthDate">Дата рождения</param>
        /// <param name="issueDate">Дата выдачи документа идентифицирующего личность</param>
        /// <param name="gender">Пол</param>
        internal void Initialize(
            Guid id,
            string nameRus,
            string surnameRus,
            string nameEng,
            string surnameEng,
            string patronymicNameRus,
            string patronymicNameEng,
            string birthPlace,
            string birthCountry,
            string departmentCode,
            string citizenship,
            string identityDocument,
            string residence,
            string residenceCountry,
            string residenceRegion,
            string issuePlace,
            DateTime? birthDate,
            DateTime? issueDate,
            Sex? gender)
        {
            /*
            Contract.Argument.IsValidIf(Id != id, $"{Id} (current) != {id} (new)");
            Contract.Argument.IsNotEmptyGuid(id, nameof(id));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(nameRus, nameof(nameRus));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(nameEng, nameof(nameEng));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(surnameRus, nameof(surnameRus));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(surnameEng, nameof(surnameEng));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(patronymicNameRus, nameof(patronymicNameRus));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(patronymicNameEng, nameof(patronymicNameEng));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(birthPlace, nameof(birthPlace));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(birthCountry, nameof(birthCountry));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(departmentCode, nameof(departmentCode));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(citizenship, nameof(citizenship));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(identityDocument, nameof(identityDocument));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(residence, nameof(residence));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(residenceCountry, nameof(residenceCountry));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(residenceRegion, nameof(residenceRegion));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(issuePlace, nameof(issuePlace));
            */

            Id = id;

            SetNameRus(nameRus);
            SetNameEng(nameEng);
            SetSurnameRus(surnameRus);
            SetSurnameEng(surnameEng);
            SetPatronymicNameRus(patronymicNameRus);
            SetPatronymicNameEng(patronymicNameEng);
            SetBirthPlace(birthPlace);
            SetBirthCountry(birthCountry);
            SetCitizenship(citizenship);
            SetResidence(residence);
            SetResidenceCountry(residenceCountry);
            SetResidenceRegion(residenceRegion);
            SetIdentityDocument(identityDocument);
            SetIssuePlace(issuePlace);
            SetDepartmentCode(departmentCode);
            SetBirthDate(birthDate);
            SetIssueDate(issueDate);
            SetGender(gender);
        }

        /// <summary>
        /// Задать имя по-русски
        /// </summary>
        /// <param name="nameRus">Имя по-русски</param>
        public void SetNameRus(string nameRus)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(nameRus, nameof(nameRus));

            if (NameRus == nameRus)
            {
                return;
            }

            NameRus = nameRus;
        }

        /// <summary>
        /// Задать имя по-английски
        /// </summary>
        /// <param name="nameEng">Имя по-английски</param>
        public void SetNameEng(string nameEng)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(nameEng, nameof(nameEng));

            if (NameEng == nameEng)
            {
                return;
            }

            NameEng = nameEng;
        }

        /// <summary>
        /// Задать фамилия по-русски
        /// </summary>
        /// <param name="surnameRus">Фамилия по-русски</param>
        public void SetSurnameRus(string surnameRus)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(surnameRus, nameof(surnameRus));

            if (SurnameRus == surnameRus)
            {
                return;
            }

            SurnameRus = surnameRus;
        }

        /// <summary>
        /// Задать фамилия по-английски
        /// </summary>
        public void SetSurnameEng(string surnameEng)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(surnameEng, nameof(surnameEng));

            if (SurnameEng == surnameEng)
            {
                return;
            }

            SurnameEng = surnameEng;
        }

        /// <summary>
        /// Задать отчество по-русски
        /// </summary>
        /// <param name="patronymicNameRus">Отчество по-русски</param>
        public void SetPatronymicNameRus(string patronymicNameRus)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(patronymicNameRus, nameof(patronymicNameRus));

            if (PatronymicNameRus == patronymicNameRus)
            {
                return;
            }

            PatronymicNameRus = patronymicNameRus;
        }

        /// <summary>
        /// Задать отчество по-английски
        /// </summary>
        /// <param name="patronymicNameEng">Отчство по-английски</param>
        public void SetPatronymicNameEng(string patronymicNameEng)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(patronymicNameEng, nameof(patronymicNameEng));

            if (PatronymicNameEng == patronymicNameEng)
            {
                return;
            }

            PatronymicNameEng = patronymicNameEng;
        }

        /// <summary>
        /// Задать место рождения
        /// </summary>
        /// <param name="birthPlace">Место рождения</param>
        public void SetBirthPlace(string birthPlace)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(birthPlace, nameof(birthPlace));

            if (BirthPlace == birthPlace)
            {
                return;
            }

            BirthPlace = birthPlace;
        }

        /// <summary>
        /// Задать страну рождения
        /// </summary>
        /// <param name="birthCountry">Страна рождения</param>
        public void SetBirthCountry(string birthCountry)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(birthCountry, nameof(birthCountry));

            if (BirthCountry == birthCountry)
            {
                return;
            }

            BirthCountry = birthCountry;
        }

        /// <summary>
        /// Задать гражданство (подданство)
        /// </summary>
        /// <param name="citizenship">Гражданство (подданство)</param>
        public void SetCitizenship(string citizenship)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(citizenship, nameof(citizenship));

            if (Citizenship == citizenship)
            {
                return;
            }

            Citizenship = citizenship;
        }

        /// <summary>
        /// Задать местожительство
        /// </summary>
        /// <param name="residence">Местожительство</param>
        public void SetResidence(string residence)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(residence, nameof(residence));

            if (Residence == residence)
            {
                return;
            }

            Residence = residence;
        }

        /// <summary>
        /// Задать страну проживания
        /// </summary>
        /// <param name="residenceCountry">Страна проживания</param>
        public void SetResidenceCountry(string residenceCountry)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(residenceCountry, nameof(residenceCountry));

            if (ResidenceCountry == residenceCountry)
            {
                return;
            }

            ResidenceCountry = residenceCountry;
        }

        /// <summary>
        /// Задать регион проживания
        /// </summary>
        /// <param name="residenceRegion">Регион проживания</param>
        public void SetResidenceRegion(string residenceRegion)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(residenceRegion, nameof(residenceRegion));

            if (ResidenceRegion == residenceRegion)
            {
                return;
            }

            ResidenceRegion = residenceRegion;
        }

        /// <summary>
        /// Задать документ идентифицирующий личность
        /// </summary>
        /// <param name="identityDocument">Документ идентифицирующий личность</param>
        public void SetIdentityDocument(string identityDocument)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(identityDocument, nameof(identityDocument));

            if (IdentityDocument == identityDocument)
            {
                return;
            }

            IdentityDocument = identityDocument;
        }

        /// <summary>
        /// Задать место выдачи документа идентифицирующего личность
        /// </summary>
        /// <param name="issuePlace">Место выдачи документа идентифицирующего личность</param>
        public void SetIssuePlace(string issuePlace)
        {
            //Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(issuePlace, nameof(issuePlace));

            if (IssuePlace == issuePlace)
            {
                return;
            }

            IssuePlace = issuePlace;
        }

        /// <summary>
        /// Задать код подразделения выдававшего документ идентифицирующего личность
        /// </summary>
        /// <param name="departmentCode">Код подразделения выдававшего документ идентифицирующего личность</param>
        public void SetDepartmentCode(string departmentCode)
        {
            /*Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(departmentCode, nameof(departmentCode));*/

            if (DepartmentCode == departmentCode)
            {
                return;
            }

            DepartmentCode = departmentCode;
        }

        /// <summary>
        /// Задать дату рождения
        /// </summary>
        /// <param name="birthDate">Дата рождения</param>
        public void SetBirthDate(DateTime? birthDate)
        {
            if (BirthDate == birthDate)
            {
                return;
            }

            BirthDate = birthDate;
        }

        /// <summary>
        /// Задать дату выдачи документа идентифицирующего личность
        /// </summary>
        /// <param name="issueDate">Дата выдачи документа идентифицирующего личность</param>
        public void SetIssueDate(DateTime? issueDate)
        {
            if (IssueDate == issueDate)
            {
                return;
            }

            IssueDate = issueDate;
        }

        /// <summary>
        /// Задать пол
        /// </summary>
        /// <param name="gender">Пол</param>
        public void SetGender(Sex? gender)
        {
            if (Gender == gender)
            {
                return;
            }

            Gender = gender;
        }

        /// <summary>
        /// Инициализировать паспорт
        /// </summary>
        /// <param name="nameRus">Имя по-русски</param>
        /// <param name="surnameRus">Фмаилия по-русски</param>
        /// <param name="nameEng">Имя по-английски</param>
        /// <param name="surnameEng">Фамилия по-английски</param>
        /// <param name="patronymicNameRus">Отчество по-русски</param>
        /// <param name="patronymicNameEng">Отчество по-английски</param>
        /// <param name="birthPlace">Место рождения</param>
        /// <param name="birthCountry">Страна рождения</param>
        /// <param name="departmentCode">Код подразделения</param>
        /// <param name="citizenship">Гражданство (подданство)</param>
        /// <param name="identityDocument">Документ идентицирующий личность</param>
        /// <param name="residence">Местожительство</param>
        /// <param name="residenceCountry">Страна проживания</param>
        /// <param name="residenceRegion">Регион проживания</param>
        /// <param name="issuePlace">Место выда документа идентифицирующего личность</param>
        /// <param name="birthDate">Дата рождения</param>
        /// <param name="issueDate">Дата выдачи документа идентифицирующего личность</param>
        /// <param name="gender">Пол</param>
        public void Update(
            string nameRus,
            string surnameRus,
            string nameEng,
            string surnameEng,
            string patronymicNameRus,
            string patronymicNameEng,
            string birthPlace,
            string birthCountry,
            string departmentCode,
            string citizenship,
            string identityDocument,
            string residence,
            string residenceCountry,
            string residenceRegion,
            string issuePlace,
            DateTime? birthDate,
            DateTime? issueDate,
            Sex? gender)
        {
            /*
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(nameRus, nameof(nameRus));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(nameEng, nameof(nameEng));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(surnameRus, nameof(surnameRus));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(surnameEng, nameof(surnameEng));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(patronymicNameRus, nameof(patronymicNameRus));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(patronymicNameEng, nameof(patronymicNameEng));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(birthPlace, nameof(birthPlace));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(birthCountry, nameof(birthCountry));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(departmentCode, nameof(departmentCode));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(citizenship, nameof(citizenship));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(identityDocument, nameof(identityDocument));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(residence, nameof(residence));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(residenceCountry, nameof(residenceCountry));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(residenceRegion, nameof(residenceRegion));
            Contract.Argument.IsNotNullOrEmptyOrWhiteSpace(issuePlace, nameof(issuePlace));
            */

            SetNameRus(nameRus);
            SetNameEng(nameEng);
            SetSurnameRus(surnameRus);
            SetSurnameEng(surnameEng);
            SetPatronymicNameRus(patronymicNameRus);
            SetPatronymicNameEng(patronymicNameEng);
            SetBirthPlace(birthPlace);
            SetBirthCountry(birthCountry);
            SetCitizenship(citizenship);
            SetResidence(residence);
            SetResidenceCountry(residenceCountry);
            SetResidenceRegion(residenceRegion);
            SetIdentityDocument(identityDocument);
            SetIssuePlace(issuePlace);
            SetDepartmentCode(departmentCode);
            SetBirthDate(birthDate);
            SetIssueDate(issueDate);
            SetGender(gender);
        }
    }
}